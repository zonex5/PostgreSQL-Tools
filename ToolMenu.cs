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
    public partial class ToolMenu : UserControl, ITool
    {
        public IToolRuner ToolRuner { get; }

        public UserControl MainContainer { get { return this; } }

        public string Caption => "PostgreSQL Tools";

        public DatabaseService DatabaseService { get; }

        public DatabaseParams DatabaseParams { get; }

        public ToolMenu(IToolRuner toolRuner)
        {
            InitializeComponent();
            ToolRuner = toolRuner;
        }

        private void btMainDump_Click(object sender, EventArgs e)
        {
            ToolRuner.RunTool(new ToolDump(ToolRuner));
        }

        private void btRestore_Click(object sender, EventArgs e)
        {
            ToolRuner.RunTool(new ToolRestore(ToolRuner));
        }

        private void btUser_Click(object sender, EventArgs e)
        {
            ToolRuner.RunTool(new ToolUsers(ToolRuner));
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            ToolRuner.RunTool(new ToolDatabase(ToolRuner));
        }

        private void btTransfer_Click(object sender, EventArgs e)
        {
            //Action<IBusyBox> action = (IBusyBox busyBox) =>
            //{
            //    //busyBox.Close();
            //};

            //new LoadingForm(action).ShowDialog();
        }
    }
}
