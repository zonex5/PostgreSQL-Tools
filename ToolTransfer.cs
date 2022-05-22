using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PGTools
{
    public partial class ToolTransfer : UserControl, ITool
    {
        public IToolRuner ToolRuner { get; set; }

        public UserControl MainContainer { get { return this; } }

        public string Caption { get => "Data Transfer Tool"; }

        public DatabaseService DatabaseService { get; } = new DatabaseService();

        private DatabaseParams paramsSource { get; } = new DatabaseParams();
        private DatabaseParams paramsDestination { get; } = new DatabaseParams();

        public ToolTransfer(IToolRuner toolRuner)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            ToolRuner = toolRuner;

            cbHostSrc.DataSource = DatabaseService.GetStoredHosts();
            cbHostDest.DataSource = DatabaseService.GetStoredHosts();

            tbPortSrc.DataBindings.Add("Text", paramsSource, "Port", false, DataSourceUpdateMode.OnPropertyChanged);
            cbHostSrc.DataBindings.Add("Text", paramsSource, "Host", false, DataSourceUpdateMode.OnPropertyChanged);
            tbUserSrc.DataBindings.Add("Text", paramsSource, "User", false, DataSourceUpdateMode.OnPropertyChanged);
            tbPassSrc.DataBindings.Add("Text", paramsSource, "Password", false, DataSourceUpdateMode.OnPropertyChanged);
            cbDatabaseSrc.DataBindings.Add("Text", paramsSource, "Database", false, DataSourceUpdateMode.OnPropertyChanged);

            tbPortDest.DataBindings.Add("Text", paramsDestination, "Port", false, DataSourceUpdateMode.OnPropertyChanged);
            cbHostDest.DataBindings.Add("Text", paramsDestination, "Host", false, DataSourceUpdateMode.OnPropertyChanged);
            tbUserDest.DataBindings.Add("Text", paramsDestination, "User", false, DataSourceUpdateMode.OnPropertyChanged);
            tbPassDest.DataBindings.Add("Text", paramsDestination, "Password", false, DataSourceUpdateMode.OnPropertyChanged);

            paramsSource.Port = "5432";
            paramsSource.User = "postgres";
            paramsSource.Password = "postgres";
            paramsDestination.Port = "5432";
            paramsDestination.User = "postgres";
            paramsDestination.Password = "postgres";
        }

        private async void cbDatabaseSrc_DropDown(object sender, EventArgs e)
        {
            if (paramsSource.ValidBaseParams)
            {
                ToolRuner.SetCursor(Cursors.WaitCursor);
                cbDatabaseSrc.DataSource = await DatabaseService.GetDatabaseList(paramsSource);
                ToolRuner.SetCursor(Cursors.Default);
            }
        }

        private void cbDatabaseSrc_DropDownClosed(object sender, EventArgs e)
        {
            ToolRuner.SetCursor(Cursors.Default);
        }

        private void btNext_Click(object sender, EventArgs e)
        {
            if (!(paramsSource.ValidBaseParams && paramsDestination.ValidBaseParams) || string.IsNullOrEmpty(paramsSource.Database))
            {
                MessageBox.Show("Please complete all fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (paramsSource.Host == paramsDestination.Host)
            {
                MessageBox.Show("Database transfer can be made only between different hosts.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            async void action(IBusyBox busyBox)
            {
                if (await DatabaseService.DoTransfer(paramsSource, paramsDestination) == 0)
                {
                    busyBox.Close();
                    MessageBox.Show("Database create operation have been completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    busyBox.Close();
                    MessageBox.Show("Database transfer operation error. Please see application logs.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            new LoadingForm(action).ShowDialog();
        }
    }
}
