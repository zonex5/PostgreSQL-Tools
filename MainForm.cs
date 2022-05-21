using EzSmb;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PGTools
{
    public partial class MainForm : Form
    {
        private static string HostFile = "hosts.ini";

        private string argCompressoin;
        private string extension;
        private string jobs;

        private string host;
        private string port;
        private string user;
        private string format;
        private string db;
        private string pass;
        private string path;
 

        public MainForm()
        {
            InitializeComponent();

            tbDumpLocation.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            List<DumpFormat> items = new List<DumpFormat>();
            items.Add(new DumpFormat('c', "Custom"));
            items.Add(new DumpFormat('d', "Directory"));
            items.Add(new DumpFormat('p', "Plain"));
            items.Add(new DumpFormat('t', "Tar atchive"));

            cbDumpDumpFormat.DataSource = items;
            cbDumpDumpFormat.ValueMember = "Format";
            cbDumpDumpFormat.DisplayMember = "FullFormat";
            cbDumpDumpFormat.SelectedIndex = 0;
            cbRestoreFormat.DataSource = items;
            cbRestoreFormat.ValueMember = "Format";
            cbRestoreFormat.DisplayMember = "FullFormat";
            cbRestoreFormat.SelectedIndex = 0;

            if (File.Exists(HostFile))
            {
                cbDumpHost.Items.Clear();
                cbDumpHost.DataSource = File.ReadAllLines(HostFile);
                cbRestoreHost.Items.Clear();
                cbRestoreHost.DataSource = File.ReadAllLines(HostFile);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            //process.StartInfo.WorkingDirectory = @"c:\\";
            process.StartInfo.Arguments = "";
            process.StartInfo.FileName = "test.bat";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.StandardOutputEncoding = Encoding.GetEncoding(866);
            process.StartInfo.StandardErrorEncoding = Encoding.GetEncoding(866);
            //process.ErrorDataReceived += Build_ErrorDataReceived;
            //process.OutputDataReceived += Build_OutputDataReceived;
            process.Exited += Process_Exited;
            process.EnableRaisingEvents = true;
            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            //process.WaitForExit();             
        }

        private void Process_Exited(object sender, EventArgs e)
        {
            // tbConcole.Text += "*** PROCESS EXIT ***";
        }

        async private void button2_Click(object sender, EventArgs e)
        {
            var folder = await Node.GetNode(@"192.168.0.5\public");
            //var folder = await Node.GetNode(@"192.168.0.5\private", "zonex5", "123123Secret!");

            // List items
            var nodes = await folder.GetList();
            /*foreach (var node in nodes)
            {
                Console.WriteLine($"Name: {node.Name}, Type: {node.Type}, LastAccessed: {node.LastAccessed:yyyy-MM-dd HH:mm:ss}");
            }*/

            WebClient client = new WebClient();
            client.DownloadFile(@"\\192.168.0.5\public\=Другое=\local.sql", @"d:\file.sql");

            MessageBox.Show("ok");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var versionInfo = FileVersionInfo.GetVersionInfo("d:\\psql.exe");
            string version = versionInfo.FileVersion;
        }

        async private Task<List<string>> getDatabaseList()
        {
            List<string> list = await executeQuerySelect($"SELECT datname FROM pg_database");
            return list.Count > 0 ? list.GetRange(2, list.Count - 5).Where(db => !db.Trim().StartsWith("template") && !db.Trim().Equals("postgres")).Select(db => db.Trim()).ToList() : list;
        }

        private bool checkDumpInputData()
        {
            return tbDumpLocation.Text.Length > 0
                && cbDumpHost.Text.Length > 0
                && tbDumpPort.Text.Length > 0
                && cbDumpDatabase.Text.Length > 0
                && cbDumpDumpFormat.Text.Length > 0
                && tbDumpUser.Text.Length > 0
                && tbDumpPass.Text.Length > 0;
        }

        private bool checkRestoreInputData()
        {
            return tbRestoreLocation.Text.Length > 0
                && cbRestoreHost.Text.Length > 0
                && tbRestorePort.Text.Length > 0
                && tbRestoreDatabase.Text.Length > 0
                && cbRestoreFormat.Text.Length > 0
                && tbRestoreUser.Text.Length > 0
                && tbRestoreUser.Text.Length > 0;
        }

        private async void btDumoRun_Click(object sender, EventArgs e)
        {
            if (!checkDumpInputData())
            {
                MessageBox.Show("Please complete all fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            UpdateDumpValues();

            if (await doDump() != 0)
            {
                MessageBox.Show("Dump operation error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Dump operation have been completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btDumpLocation_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                tbDumpLocation.Text = dialog.SelectedPath;
            }
        }

        async private Task<int> doCommand(string execFile, string args, Action<string> onData = null, Action<string> onError = null, bool showErrors = true)
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
                //process.StartInfo.StandardOutputEncoding = Encoding.GetEncoding(866);
                //process.StartInfo.StandardErrorEncoding = Encoding.GetEncoding("WINDOWS-1251");
                if (showErrors)
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

        private void cbDumpDumpFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbDumpDumpFormat.SelectedIndex)
            {
                case 0:
                    argCompressoin = "--compress=9";
                    extension = ".dump";
                    jobs = "";
                    break;
                case 1:
                    argCompressoin = "--compress=9";
                    extension = "";
                    jobs = "--jobs=10";
                    break;
                case 2:
                    argCompressoin = "";
                    extension = ".sql";
                    jobs = "";
                    break;
                case 3:
                    argCompressoin = "";
                    extension = ".tar";
                    jobs = "";
                    break;
            }
        }

        private async void btDumpRefresh_Click(object sender, EventArgs e)
        {
            if (cbDumpHost.Text.Length == 0 || tbDumpUser.Text.Length == 0 || tbDumpPass.Text.Length == 0) return;

            UpdateDumpValues();

            cbDumpDatabase.DataSource = null;
            cbDumpDatabase.Items.Clear();
            cbDumpDatabase.Text = string.Empty;
            cbDumpDatabase.DataSource = await getDatabaseList();
        }

        private void tbDumpPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cbRestoreFormat_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        async private void btRestoreRun_Click(object sender, EventArgs e)
        {
            if (!checkRestoreInputData())
            {
                MessageBox.Show("Please complete all fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbRestoreFormat.SelectedIndex == 1 && !File.GetAttributes(tbRestoreLocation.Text).HasFlag(FileAttributes.Directory))
            {
                MessageBox.Show("Please select directory on \"Dump Location\" for format \"d\".", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UpdateRestoreValues();

            await executeQuery($"select pg_terminate_backend(pid) from pg_stat_activity where datname = '{db}'", db, false);
            if (await executeQuery($"drop database if exists {db}") == 0
                    && await executeQuery($"create database {db}") == 0
                    && await doRestore() == 0
               )
            {
                MessageBox.Show($"Database '{db}' have been restored!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Database '{db}' have not been restored!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<int> executeQuery(string query, string db = null, bool showErrors = true)
        {
            var dbPart = db != null ? $"-d {db}" : "";
            return await doCommand(@".\psql\psql.exe", $"-h {host} -p {port} -U {user} {dbPart} -c \"{query};\"", logInfo, logError, showErrors);
        }

        private async Task<List<string>> executeQuerySelect(string query)
        {
            var result = new List<string>();
            var exitCode = await doCommand(@".\psql\psql.exe", $"-h {host} -p {port} -U {user} -c \"{query};\"", (data) => { result.Add(data); });
            return exitCode == 0 ? result : new List<string>();
        }

        private async Task<int> doRestore()
        {
            logInfo($"Database '{db}' have been restored");
            return await doCommand(@".\psql\pg_restore.exe", $"-h {host} -p {port} -U {user} -d {db} \"{path}\"", logInfo, logError);
        }

        private async Task<int> doDump()
        {
            var fileName = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            logInfo($"Database '{db}' have been dumped"); 
            return await doCommand(@".\psql\pg_dump.exe", $"-h {host} -p {port} {jobs} {argCompressoin} -O -U {user} -f \"{path}\\{db}_{fileName}{extension}\" --blobs --format={format} {db}", logInfo, logError);
        }

        private void UpdateRestoreValues()
        {
            host = cbRestoreHost.Text;
            port = tbRestorePort.Text;
            user = tbRestoreUser.Text;
            db = tbRestoreDatabase.Text;
            pass = tbRestorePass.Text;
            path = tbRestoreLocation.Text;
        }

        private void UpdateDumpValues()
        {
            host = cbDumpHost.Text;
            port = tbDumpPort.Text;
            user = tbDumpUser.Text;
            db = cbDumpDatabase.Text;
            pass = tbDumpPass.Text;
            path = tbDumpLocation.Text;
            format = cbDumpDumpFormat.SelectedValue.ToString();
        }

        private string getFilter(int selectedIndex)
        {
            switch (selectedIndex)
            {
                case 0: return "Database Backup|*.dump|All files|*.*";
                case 2: return "Plain SQL|*.sql|All files|*.*";
                case 3: return "TAR File|*.tar|All files|*.*";
                default: return "";
            }
        }

        private void btRestoreLocation_Click(object sender, EventArgs e)
        {
            if (cbRestoreFormat.SelectedIndex == 1)
            {
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    tbRestoreLocation.Text = dialog.SelectedPath;
                }
            }
            else
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = getFilter(cbRestoreFormat.SelectedIndex);
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    tbRestoreLocation.Text = dialog.FileName;
                }
            }
        }

        private void logInfo(string text)
        {
            rbConsole.BeginInvoke(new Action(() =>
            {
                rbConsole.AppendText("Info: ");
                rbConsole.AppendText(Encoding.UTF8.GetString(Encoding.Default.GetBytes(text)) + Environment.NewLine);
            }));
        }

        private void logError(string text)
        {
            rbConsole.BeginInvoke(new Action(() =>
            {
                rbConsole.AppendText("Error: ");
                rbConsole.AppendText(Encoding.UTF8.GetString(Encoding.Default.GetBytes(text)) + Environment.NewLine);
            }));
        }

        private void tbDumpLocation_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
