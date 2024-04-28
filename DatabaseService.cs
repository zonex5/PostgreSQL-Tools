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
        private const string HostFile = "hosts.ini";

        private readonly Action<string> LogError = (error) => File.AppendAllText("logs.log", DateTime.Now.ToString() + ": " + error + Environment.NewLine, Encoding.Default);

        public async Task<List<string>> GetUserList(DatabaseParams prms)
        {
            List<string> list = await ExecuteQuerySelect(prms.Host, prms.Port, prms.User, prms.Password, $"SELECT usename AS role_name FROM pg_catalog.pg_user ORDER BY role_name desc;");
            return list.Count > 0 ? list.GetRange(2, list.Count - 3).Select(db => db.Trim()).ToList() : list;
        }

        public async Task<List<string>> GetDatabaseList(DatabaseParams prms)
        {
            List<string> list = await ExecuteQuerySelect(prms.Host, prms.Port, prms.User, prms.Password, $"SELECT datname FROM pg_database");
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

        public async Task<int> ExecuteQuery(string host, string port, string user, string password, string query, string db = null)
        {
            var dbPart = db != null ? $"-d {db}" : "";
            return await DoCommand(@".\psql\psql.exe", $"-h {host} -p {port} -U {user} {dbPart} -c \"{query};\"", password);
        }

        public async Task<List<string>> ExecuteQuerySelect(string host, string port, string user, string password, string query)
        {
            var result = new List<string>();
            var exitCode = await DoCommand(@".\psql\psql.exe", $"-h {host} -p {port} -U {user} -c \"{query};\"", password, (data) => result.Add(data), LogError);
            return exitCode == 0 ? result : null;
        }

        public async Task<int> DoRestore(DatabaseParams prms)
        {
            return await DoDelete(prms) == 0 && await DoCreate(prms) == 0
                && await DoCommand(@".\psql\pg_restore.exe", $"--no-owner -h {prms.Host} -p {prms.Port} -U {prms.User} -d {prms.Database} \"{prms.Path}\"", prms.Password, null, LogError) == 0 ? 0 : 1;
        }

        public async Task<int> DoDump(DatabaseParams prms)
        {
            return await DoCommand(@".\psql\pg_dump.exe", $"--no-owner --no-privileges -h {prms.Host} -p {prms.Port} {prms.Jobs} {prms.Compressoin} -O -U {prms.User} -f \"{prms.Path}\\{prms.DumpFileName}\" --blobs --format={prms.Format} {prms.Database}", prms.Password, null, LogError);
        }

        public async Task<int> DoTransfer(DatabaseParams prmsSrc, DatabaseParams prmsDest)
        {
            prmsSrc.Format = 'c';
            prmsSrc.Path = Path.GetTempPath();
            prmsDest.Database = prmsSrc.Database;
            prmsDest.Format = prmsSrc.Format;
            prmsDest.NameSufix = prmsSrc.NameSufix;
            prmsDest.Path = prmsSrc.Path + prmsDest.DumpFileName;
            return await DoDump(prmsSrc) == 0 && await DoRestore(prmsDest) == 0 ? 0 : 1;
        }

        public async Task<int> DoCreate(DatabaseParams prms)
        {
            return await DoCommand(@".\psql\psql.exe", $"-h {prms.Host} -p {prms.Port} -U {prms.User} -c \"create database {prms.Database} with encoding='UTF8' LC_CTYPE='en_US.UTF-8' LC_COLLATE='en_US.UTF-8' TEMPLATE=template0;\"", prms.Password, null, LogError);
        }

        public async Task<int> DoKillSession(DatabaseParams prms)
        {
            return await DoCommand(@".\psql\psql.exe", $"-h {prms.Host} -p {prms.Port} -U {prms.User} -c \"select pg_terminate_backend(pid) from pg_stat_activity where datname = '{prms.Database}';\"", prms.Password, null, LogError);
        }

        public async Task<int> DoDelete(DatabaseParams prms)
        {
            var code = await DoKillSession(prms);
            return
                code >= 0 &&
                await DoCommand(@".\psql\psql.exe", $"-h {prms.Host} -p {prms.Port} -U {prms.User} -c \"drop database if exists {prms.Database};\"", prms.Password, null, LogError) == 0
                ? 0 : 1;
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
            var items = new List<DumpFormat>
            {
                new DumpFormat('c', "Custom"),
                new DumpFormat('d', "Directory"),
                new DumpFormat('p', "Plain"),
                new DumpFormat('t', "Tar atchive")
            };
            return items;
        }

        private async Task<int> DoCommand(string execFile, string args, string pass, Action<string> onData = null, Action<string> onError = null)
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


    }
}
