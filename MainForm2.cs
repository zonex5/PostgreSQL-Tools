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
        private ITool previousTool = null;
        private ITool curentTool = null;

        public MainForm2()
        {
            InitializeComponent();

            RunTool(new ToolMenu(this));
            btBack.Enabled = false;
        }

        public void RunTool(ITool tool)
        {
            if (tool == null) return;

            previousTool = curentTool;
            curentTool = tool;

            lbCaption.Text = tool.Caption;
            container.Controls.Clear();
            container.Controls.Add(tool.MainContainer);
            btNext.Enabled = tool.ButtonNextEnable;
            btBack.Enabled = true;
        }

        private void btNext_Click(object sender, EventArgs e)
        {
            if (curentTool != null)
                curentTool.ButtonNextClick();
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            RunTool(previousTool);
            previousTool = null;
            btBack.Enabled = false;
        }

        public void SetCursor(Cursor cursor)
        {
            Cursor = cursor;
        }
    }
}
