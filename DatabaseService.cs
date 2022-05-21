using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGTools
{
    public class DatabaseService
    {
        private static string HostFile = "hosts.ini";

        async public Task<List<string>> getUserList(DatabaseParams prms)
        {
            List<string> list = await executeQuerySelect(prms.Host, prms.Port, prms.User, prms.Password, $"SELECT usename AS role_name FROM pg_catalog.pg_user ORDER BY role_name desc;");
            return list.Count > 0 ? list.GetRange(2, list.Count - 3).Select(db => db.Trim()).ToList() : list;
        }

        async public Task<List<string>> getDatabaseList(string host, string port, string user, string password)
        {
            List<string> list = await executeQuerySelect(host, port, user, password, $"SELECT datname FROM pg_database");
            if (list == null)
                return null;
            else
                return list.Count > 0 ? list.Where(db => !db.Trim().StartsWith("template")
                                                    && !db.Trim().Equals("postgres")
                                                    && !db.Trim().Equals("datname")
                                                    && !db.Trim().StartsWith("---")
                                                    && !db.Trim().StartsWith("(")
                                                  ).Select(db => db.Trim()).ToList() : list;
        }

        async public Task<List<string>> getDatabaseList(DatabaseParams prms)
        {
            return await getDatabaseList(prms.Host, prms.Port, prms.User, prms.Password);
        }

        async public Task<int> executeQuery(string host, string port, string user, string password, string query, string db = null)
        {
            var dbPart = db != null ? $"-d {db}" : "";
            return await doCommand(@".\psql\psql.exe", $"-h {host} -p {port} -U {user} {dbPart} -c \"{query};\"", password);
        }

        async public Task<List<string>> executeQuerySelect(string host, string port, string user, string password, string query)
        {
            var result = new List<string>();
            var exitCode = await doCommand(@".\psql\psql.exe", $"-h {host} -p {port} -U {user} -c \"{query};\"", password, (data) => result.Add(data), (msg) => logError(msg));
            return exitCode == 0 ? result : null;
        }

        async public Task<int> doRestore(string host, string port, string user, string password, string db, string path)
        {
            // can work with errors
            await doCommand(@".\psql\psql.exe", $"-h {host} -p {port} -U {user} -c \"select pg_terminate_backend(pid) from pg_stat_activity where datname = '{db}';\"", password, null, (msg) => logError(msg));

            return
                await doCommand(@".\psql\psql.exe", $"-h {host} -p {port} -U {user} -c \"drop database if exists {db};\"", password, null, (msg) => logError(msg)) == 0
                && await doCommand(@".\psql\psql.exe", $"-h {host} -p {port} -U {user} -c \"create database {db};\"", password, null, (msg) => logError(msg)) == 0
                && await doCommand(@".\psql\pg_restore.exe", $"-h {host} -p {port} -U {user} -d {db} \"{path}\"", password) == 0
                ? 0 : 1;
        }

        async public Task<int> doRestore(DatabaseParams prms)
        {
            return await doRestore(prms.Host, prms.Port, prms.User, prms.Password, prms.Database, prms.Path);
        }

        async public Task<int> doDump(string host, string port, string user, string password, char format, string db, string path)
        {
            var fileName = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            var jobs = GetJobsByFormat(format);
            var compressoin = GetCompressoinByFormat(format);
            var extension = GetextEnsionByFormat(format);
            return await doCommand(@".\psql\pg_dump.exe", $"-h {host} -p {port} {jobs} {compressoin} -O -U {user} -f \"{path}\\{db}_{fileName}{extension}\" --blobs --format={format} {db}", password);
        }

        async public Task<int> doDump(DatabaseParams prms)
        {
            return await doDump(prms.Host, prms.Port, prms.User, prms.Password, prms.Format, prms.Database, prms.Path);
        }

        async public Task<int> doCreate(DatabaseParams prms)
        {
            return await doCommand(@".\psql\psql.exe", $"-h {prms.Host} -p {prms.Port} -U {prms.User} -c \"create database {prms.Database};\"", prms.Password, null, (msg) => logError(msg));
        }

        async public Task<int> doDelete(DatabaseParams prms)
        {
            return await doCommand(@".\psql\psql.exe", $"-h {prms.Host} -p {prms.Port} -U {prms.User} -c \"drop database if exists {prms.Database};\"", prms.Password, null, (msg) => logError(msg));
        }

        public void logError(string error)
        {
            File.AppendAllText("logs.log", DateTime.Now.ToString() + ": " + error + Environment.NewLine, Encoding.Default);
        }

        public List<string> GetStoredHosts()
        {
            if (File.Exists(HostFile))
            {
                return new List<string>(File.ReadAllLines(HostFile));
            }
            else
                return new List<string>();
        }

        public List<DumpFormat> GetFormats()
        {
            var items = new List<DumpFormat>();
            items.Add(new DumpFormat('c', "Custom"));
            items.Add(new DumpFormat('d', "Directory"));
            items.Add(new DumpFormat('p', "Plain"));
            items.Add(new DumpFormat('t', "Tar atchive"));
            return items;
        }

        async private Task<int> doCommand(string execFile, string args, string pass, Action<string> onData = null, Action<string> onError = null)
        {
            int exitCode = -1;
            await Task.Run(() =>
            {
                Process process = new Process();
                process.StartInfo.Arguments = args;
                process.StartInfo.FileName = execFile;
                process.StartInfo.EnvironmentVariables.Add("PGPASSWORD", pass);
                process.StartInfo.WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.CreateNoWindow = true;
                process.ErrorDataReceived += (sender, e) => { if (!string.IsNullOrEmpty(e.Data)) onError?.Invoke(e.Data); };
                process.OutputDataReceived += (sender, e) => { if (!string.IsNullOrEmpty(e.Data)) onData?.Invoke(e.Data); };
                process.EnableRaisingEvents = true;
                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                process.WaitForExit();
                exitCode = process.ExitCode;
            });
            return exitCode;
        }

        private string GetJobsByFormat(char format)
        {
            switch (format)
            {
                case 'd': return "--jobs=10";
                default: return "";
            }
        }

        private string GetCompressoinByFormat(char format)
        {
            switch (format)
            {
                case 'c':
                case 'd': return "--compress=9";
                default: return "";
            }
        }

        private string GetextEnsionByFormat(char format)
        {
            switch (format)
            {
                case 'c': return ".dump";
                case 'p': return ".sql";
                case 't': return ".tar";
                default: return "";
            }
        }
    }
}
