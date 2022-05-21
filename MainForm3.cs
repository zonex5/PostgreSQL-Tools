using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PGTools
{
    public partial class MainForm3 : Form, IToolRuner
    {
        private ITool previousTool = null;
        private ITool curentTool = null;

        public MainForm3()
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
            btBack.Enabled = true;
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

        private void btLogs_Click(object sender, EventArgs e)
        {
            var logsFile = "logs.log";
            if (!File.Exists(logsFile))
                File.AppendAllText(logsFile, "");
            Process.Start(logsFile);
        }
    }
}
