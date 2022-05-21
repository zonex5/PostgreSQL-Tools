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
    public partial class ToolDatabaseUI : UserControl, IToolUI
    {
        public ITool ParentTool { get; set; }

        public event Action<string> OnAddClick = delegate { };
        public event Action<string> OnDeleteClick = delegate { };

        public ToolDatabaseUI(ITool parentTool)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            ParentTool = parentTool;

            cbHost.DataSource = ParentTool.DatabaseService.GetStoredHosts();

            tbPort.DataBindings.Add("Text", ParentTool.DatabaseParams, "Port", false, DataSourceUpdateMode.OnPropertyChanged);
            cbHost.DataBindings.Add("Text", ParentTool.DatabaseParams, "Host", false, DataSourceUpdateMode.OnPropertyChanged);
            tbUser.DataBindings.Add("Text", ParentTool.DatabaseParams, "User", false, DataSourceUpdateMode.OnPropertyChanged);
            tbPass.DataBindings.Add("Text", ParentTool.DatabaseParams, "Password", false, DataSourceUpdateMode.OnPropertyChanged);

            ParentTool.DatabaseParams.Port = "5432";
            ParentTool.DatabaseParams.User = "postgres";
            ParentTool.DatabaseParams.Password = "postgres";
        }

        async private void loadData()
        {
            grid.AutoGenerateColumns = false;
            var list = await ParentTool.DatabaseService.getDatabaseList(ParentTool.DatabaseParams);
            if (list != null)
            {
                grid.DataSource = list.Select(x => new KeyValuePair<string, string>("", x)).ToList();
            }
            else
            {
                MessageBox.Show("Operation error. Please see application logs.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btLoad_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void grid_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            grid.Rows[e.RowIndex].Cells[0].Value = e.RowIndex + 1;
        }

        private void grid_SelectionChanged(object sender, EventArgs e)
        {
            btRemove.Enabled = false;

            if (grid.SelectedRows.Count > 0)
            {
                btRemove.Enabled = true;
            }
        }

        private void btRemove_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete selected database?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var item = (KeyValuePair<string, string>)grid.SelectedRows[0].DataBoundItem;
                ParentTool.DatabaseParams.Database = item.Value;

                Action<IBusyBox> action = async (IBusyBox busyBox) =>
                {
                    if (await ParentTool.DatabaseService.doDelete(ParentTool.DatabaseParams) != 0)
                    {
                        busyBox.Close();
                        MessageBox.Show("Database delete operation error. Please see application logs.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        loadData();
                        busyBox.Close();
                        MessageBox.Show("Database delete operation have been completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                };
                new LoadingForm(action).ShowDialog();
            }
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            if (!ParentTool.DatabaseParams.ValidBaseParams)
            {
                MessageBox.Show("Please complete all fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var form = new NewDatabaseForm();
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                Action<IBusyBox> action = async (IBusyBox busyBox) =>
                {
                    ParentTool.DatabaseParams.Database = form.DatabaseName;
                    if (await ParentTool.DatabaseService.doCreate(ParentTool.DatabaseParams) != 0)
                    {
                        busyBox.Close();
                        MessageBox.Show("Database create operation error. Please see application logs.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        loadData();
                        busyBox.Close();
                        MessageBox.Show("Database create operation have been completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                };
                new LoadingForm(action).ShowDialog();
            }
        }

        private void cbHost_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbHost.Text))
            {
                btLoad.Enabled = false;
            }
            else
            {
                btLoad.Enabled = true;
            }
        }
    }
}
