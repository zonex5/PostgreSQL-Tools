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
    public partial class ToolDumpUI : UserControl, IToolUI
    {
        public ITool ParentTool { get; set; }

        private DatabaseService service = new DatabaseService();

        private DatabaseParams dbParams = new DatabaseParams();

        public ToolDumpUI(ITool parentTool)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            ParentTool = parentTool;

            ParentTool.ToolRuner.OnClickNext += ToolRuner_OnClickNext;

            cbHost.DataSource = service.GetStoredHosts();
            cbFormat.DataSource = service.GetFormats();
            cbFormat.DisplayMember = "FullFormat";
            cbFormat.ValueMember = "Format";

            tbPort.DataBindings.Add("Text", dbParams, "Port", false, DataSourceUpdateMode.OnPropertyChanged);
            cbHost.DataBindings.Add("Text", dbParams, "Host", false, DataSourceUpdateMode.OnPropertyChanged);
            tbUser.DataBindings.Add("Text", dbParams, "User", false, DataSourceUpdateMode.OnPropertyChanged);
            tbPass.DataBindings.Add("Text", dbParams, "Password", false, DataSourceUpdateMode.OnPropertyChanged);
            cbDatabase.DataBindings.Add("Text", dbParams, "Database", false, DataSourceUpdateMode.OnPropertyChanged);
            tbPath.DataBindings.Add("Text", dbParams, "Path", false, DataSourceUpdateMode.OnPropertyChanged);
            cbFormat.DataBindings.Add("SelectedValue", dbParams, "Format", false, DataSourceUpdateMode.OnPropertyChanged);

            dbParams.Port = "5432";
            dbParams.User = "postgres";
            dbParams.Password = "postgres";
        }

        private async void ToolRuner_OnClickNext()
        {
            if (!dbParams.ValidParams)
            {
                MessageBox.Show("Please complete all fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (await service.doDump(dbParams) != 0)
            {
                MessageBox.Show("Dump operation error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Dump operation have been completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        async private void cbDumpDatabase_DropDown(object sender, EventArgs e)
        {
            if (dbParams.ValidBaseParams)
            {
                ParentTool.ToolRuner.SetCursor(Cursors.WaitCursor);
                cbDatabase.DataSource = await service.getDatabaseList(dbParams);
                ParentTool.ToolRuner.SetCursor(Cursors.Default);
            }
        }

        private void cbDumpDatabase_DropDownClosed(object sender, EventArgs e)
        {
            ParentTool.ToolRuner.SetCursor(Cursors.Default);
        }

        private void btDumpLocation_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                tbPath.Text = dialog.SelectedPath;
            }
        }
    }
}
