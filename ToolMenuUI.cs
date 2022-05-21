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
    public partial class ToolMenuUI : UserControl, IToolUI
    {
        public ITool ParentTool { get; set; }

        public ToolMenuUI(ITool parentTool)
        {
            InitializeComponent();
            ParentTool = parentTool;
        }

        private void btMainDump_Click(object sender, EventArgs e)
        {
            ParentTool.ToolRuner.RunTool(new ToolDump(ParentTool.ToolRuner));
        }

        private void btRestore_Click(object sender, EventArgs e)
        {
            ParentTool.ToolRuner.RunTool(new ToolRestore(ParentTool.ToolRuner));
        }

        private void btCreate_Click(object sender, EventArgs e)
        {
            ParentTool.ToolRuner.RunTool(new ToolCreate(ParentTool.ToolRuner));
        }

        private void btUser_Click(object sender, EventArgs e)
        {
            ParentTool.ToolRuner.RunTool(new ToolUsers(ParentTool.ToolRuner));
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            ParentTool.ToolRuner.RunTool(new ToolDatabase(ParentTool.ToolRuner));
        }

        private void btTransfer_Click(object sender, EventArgs e)
        {
            Action<IBusyBox> action = (IBusyBox busyBox) =>
            {
                //busyBox.Close();
            };

            new LoadingForm(action).ShowDialog();
        }
    }
}
