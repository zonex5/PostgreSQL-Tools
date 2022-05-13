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
    public partial class MainForm2 : Form, IToolRuner
    {
        public MainForm2()
        {
            InitializeComponent();

            runTool(new ToolMenu(this));
        }

        public void runTool(ITool tool)
        {
            if (tool == null) return;

            lbCaption.Text = tool.Caption;
            container.Controls.Clear();
            container.Controls.Add(tool.MainContainer);
        }
    }
}
