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
    public partial class ToolDumpUI : UserControl, IToolUI
    {
        public ITool ParentTool { get; set; }

        public ToolDumpUI(ITool parentTool)
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

        async private void cbDumpDatabase_DropDown(object sender, EventArgs e)
        {
            if (ParentTool.DatabaseParams.ValidBaseParams)
            {
                ParentTool.ToolRuner.SetCursor(Cursors.WaitCursor);
                cbDatabase.DataSource = await ParentTool.DatabaseService.getDatabaseList(ParentTool.DatabaseParams);
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

        private void btNext_Click(object sender, EventArgs e)
        {
            if (!DatabaseParams.ValidParams)
            {
                MessageBox.Show("Please complete all fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Action<IBusyBox> action = async (IBusyBox busyBox) =>
            {
                if (await DatabaseService.doDump(DatabaseParams) != 0)
                {
                    busyBox.Close();
                    MessageBox.Show("Dump operation error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    busyBox.Close();
                    MessageBox.Show("Dump operation have been completed. Suka", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            };

            new LoadingForm(action).ShowDialog();
        }
    }
}
