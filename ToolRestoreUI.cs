using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PostgreSQL_Restore_DB
{
    public partial class ToolRestoreUI : UserControl, IToolUI
    {
        public ITool ParentTool { get; set; }

        public ToolRestoreUI(ITool parentTool)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            ParentTool = parentTool;

            cbHost.DataSource = ParentTool.DatabaseService.GetStoredHosts();
            cbFormat.DataSource = ParentTool.DatabaseService.GetFormats();
            cbFormat.DisplayMember = "FullFormat";
            cbFormat.ValueMember = "Format";

            tbPort.DataBindings.Add("Text", ParentTool.DatabaseParams, "Port", false, DataSourceUpdateMode.OnPropertyChanged);
            cbHost.DataBindings.Add("Text", ParentTool.DatabaseParams, "Host", false, DataSourceUpdateMode.OnPropertyChanged);
            tbUser.DataBindings.Add("Text", ParentTool.DatabaseParams, "User", false, DataSourceUpdateMode.OnPropertyChanged);
            tbPass.DataBindings.Add("Text", ParentTool.DatabaseParams, "Password", false, DataSourceUpdateMode.OnPropertyChanged);
            cbDatabase.DataBindings.Add("Text", ParentTool.DatabaseParams, "Database", false, DataSourceUpdateMode.OnPropertyChanged);
            tbPath.DataBindings.Add("Text", ParentTool.DatabaseParams, "Path", false, DataSourceUpdateMode.OnPropertyChanged);
            cbFormat.DataBindings.Add("SelectedValue", ParentTool.DatabaseParams, "Format", false, DataSourceUpdateMode.OnPropertyChanged);

            ParentTool.DatabaseParams.Port = "5432";
            ParentTool.DatabaseParams.User = "postgres";
            ParentTool.DatabaseParams.Password = "postgres";
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
            if (ParentTool.DatabaseParams.ValidBaseParams)
            {
                ParentTool.ToolRuner.SetCursor(Cursors.WaitCursor);
                cbDatabase.DataSource = await ParentTool.DatabaseService.getDatabaseList(ParentTool.DatabaseParams);
                ParentTool.ToolRuner.SetCursor(Cursors.Default);
            }
        }

        private void cbDatabase_DropDownClosed(object sender, EventArgs e)
        {
            ParentTool.ToolRuner.SetCursor(Cursors.Default);
        }
    }
}
