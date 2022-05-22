using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PGTools
{
    public partial class ToolDump : UserControl, ITool
    {
        public IToolRuner ToolRuner { get; set; }

        public UserControl MainContainer { get { return this; } }

        public string Caption { get => "Database Dump Tool"; }

        public DatabaseService DatabaseService { get; } = new DatabaseService();

        public DatabaseParams DatabaseParams { get; } = new DatabaseParams();

        public ToolDump(IToolRuner toolRuner)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            ToolRuner = toolRuner;

            cbHost.DataSource = DatabaseService.GetStoredHosts();
            cbFormat.DataSource = DatabaseService.GetFormats();
            cbFormat.DisplayMember = "FullFormat";
            cbFormat.ValueMember = "Format";

            tbPort.DataBindings.Add("Text", DatabaseParams, "Port", false, DataSourceUpdateMode.OnPropertyChanged);
            cbHost.DataBindings.Add("Text", DatabaseParams, "Host", false, DataSourceUpdateMode.OnPropertyChanged);
            tbUser.DataBindings.Add("Text", DatabaseParams, "User", false, DataSourceUpdateMode.OnPropertyChanged);
            tbPass.DataBindings.Add("Text", DatabaseParams, "Password", false, DataSourceUpdateMode.OnPropertyChanged);
            cbDatabase.DataBindings.Add("Text", DatabaseParams, "Database", false, DataSourceUpdateMode.OnPropertyChanged);
            tbPath.DataBindings.Add("Text", DatabaseParams, "Path", false, DataSourceUpdateMode.OnPropertyChanged);
            cbFormat.DataBindings.Add("SelectedValue", DatabaseParams, "Format", false, DataSourceUpdateMode.OnPropertyChanged);

            DatabaseParams.Port = "5432";
            DatabaseParams.User = "postgres";
            DatabaseParams.Password = "postgres";
        }

        async private void cbDumpDatabase_DropDown(object sender, EventArgs e)
        {
            if (DatabaseParams.ValidBaseParams)
            {
                ToolRuner.SetCursor(Cursors.WaitCursor);
                cbDatabase.DataSource = await DatabaseService.GetDatabaseList(DatabaseParams);
                ToolRuner.SetCursor(Cursors.Default);
            }
        }

        private void cbDumpDatabase_DropDownClosed(object sender, EventArgs e)
        {
            ToolRuner.SetCursor(Cursors.Default);
        }

        private void btDumpLocation_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                tbPath.Text = dialog.SelectedPath;
            }
        }

        private void btNext_Click(object sender, EventArgs e)
        {
            if (!DatabaseParams.ValidParams)
            {
                MessageBox.Show("Please complete all fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            async void action(IBusyBox busyBox)
            {
                if (await DatabaseService.DoDump(DatabaseParams) != 0)
                {
                    busyBox.Close();
                    MessageBox.Show("Dump operation error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    busyBox.Close();
                    MessageBox.Show("Dump operation have been completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            new LoadingForm(action).ShowDialog();
        }
    }
}
