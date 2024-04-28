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
    public partial class ToolDatabase : UserControl, ITool
    {
        public IToolRuner ToolRuner { get; set; }

        public UserControl MainContainer { get { return this; } }

        public string Caption { get => "Database Tool"; }

        public DatabaseService DatabaseService { get; } = new DatabaseService();

        public DatabaseParams DatabaseParams { get; } = new DatabaseParams();

        public ToolDatabase(IToolRuner toolRuner)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            ToolRuner = toolRuner;

            cbHost.DataSource = DatabaseService.GetStoredHosts();

            tbPort.DataBindings.Add("Text", DatabaseParams, "Port", false, DataSourceUpdateMode.OnPropertyChanged);
            cbHost.DataBindings.Add("Text", DatabaseParams, "Host", false, DataSourceUpdateMode.OnPropertyChanged);
            tbUser.DataBindings.Add("Text", DatabaseParams, "User", false, DataSourceUpdateMode.OnPropertyChanged);
            tbPass.DataBindings.Add("Text", DatabaseParams, "Password", false, DataSourceUpdateMode.OnPropertyChanged);

            DatabaseParams.Port = "5432";
            DatabaseParams.User = "postgres";
            DatabaseParams.Password = "postgres";
        }

        private async void LoadData()
        {
            grid.AutoGenerateColumns = false;
            var list = await DatabaseService.GetDatabaseList(DatabaseParams);
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
            LoadData();
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
                DatabaseParams.Database = item.Value;

                async void action(IBusyBox busyBox)
                {
                    if (await DatabaseService.DoDelete(DatabaseParams) != 0)
                    {
                        busyBox.Close();
                        MessageBox.Show("Database delete operation error. Please see application logs.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        LoadData();
                        busyBox.Close();
                        MessageBox.Show("Database delete operation have been completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                new LoadingForm(action).ShowDialog();
            }
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            if (!DatabaseParams.ValidBaseParams)
            {
                MessageBox.Show("Please complete all fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var form = new NewDatabaseForm();
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                async void action(IBusyBox busyBox)
                {
                    DatabaseParams.Database = form.DatabaseName;
                    if (await DatabaseService.DoCreate(DatabaseParams) != 0)
                    {
                        busyBox.Close();
                        MessageBox.Show("Database create operation error. Please see application logs.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        LoadData();
                        busyBox.Close();
                        MessageBox.Show("Database create operation have been completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
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
