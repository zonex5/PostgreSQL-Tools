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
    public partial class ToolCreateUI : UserControl, IToolUI
    {
        public ITool ParentTool { get; set; }

        public ToolCreateUI(ITool parentTool)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            ParentTool = parentTool;

            cbHost.DataSource = ParentTool.DatabaseService.GetStoredHosts();

            tbPort.DataBindings.Add("Text", ParentTool.DatabaseParams, "Port", false, DataSourceUpdateMode.OnPropertyChanged);
            cbHost.DataBindings.Add("Text", ParentTool.DatabaseParams, "Host", false, DataSourceUpdateMode.OnPropertyChanged);
            tbUser.DataBindings.Add("Text", ParentTool.DatabaseParams, "User", false, DataSourceUpdateMode.OnPropertyChanged);
            tbPass.DataBindings.Add("Text", ParentTool.DatabaseParams, "Password", false, DataSourceUpdateMode.OnPropertyChanged);
            tbDatabase.DataBindings.Add("Text", ParentTool.DatabaseParams, "Database", false, DataSourceUpdateMode.OnPropertyChanged);

            ParentTool.DatabaseParams.Port = "5432";
            ParentTool.DatabaseParams.User = "postgres";
            ParentTool.DatabaseParams.Password = "postgres";
        }
    }
}
