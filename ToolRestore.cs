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
    public partial class ToolRestore : UserControl, ITool
    {
        public IToolRuner ToolRuner { get; set; }

        public UserControl MainContainer { get { return this; } }

        public string Caption { get => "Database Restore Tool"; }

        public DatabaseService DatabaseService { get; } = new DatabaseService();

        public DatabaseParams DatabaseParams { get; } = new DatabaseParams();

        public ToolRestore(IToolRuner toolRuner)
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

        private void btDumpLocation_Click(object sender, EventArgs e)
        {
            if (cbFormat.SelectedIndex == -1)
            {
                MessageBox.Show("Please select dump format first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                if (cbFormat.SelectedIndex == 1)
            {
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    tbPath.Text = dialog.SelectedPath;
                }
            }
            else
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = getFilter(cbFormat.SelectedIndex);
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    tbPath.Text = dialog.FileName;
                }
            }
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

        async private void cbDatabase_DropDown(object sender, EventArgs e)
        {
            if (DatabaseParams.ValidBaseParams)
            {
                ToolRuner.SetCursor(Cursors.WaitCursor);
                cbDatabase.DataSource = await DatabaseService.getDatabaseList(DatabaseParams);
                ToolRuner.SetCursor(Cursors.Default);
            }
        }

        private void cbDatabase_DropDownClosed(object sender, EventArgs e)
        {
            ToolRuner.SetCursor(Cursors.Default);
        }

        private void btNext_Click(object sender, EventArgs e)
        {
            if (!DatabaseParams.ValidParams)
            {
                MessageBox.Show("Please complete all fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Action<IBusyBox> action = async (IBusyBox busyBox) =>
            {
                if (await DatabaseService.doRestore(DatabaseParams) != 0)
                {
                    busyBox.Close();
                    MessageBox.Show("Restore operation error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    busyBox.Close();
                    MessageBox.Show("Restore operation have been completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            };

            new LoadingForm(action).ShowDialog();
        }
    }
}
