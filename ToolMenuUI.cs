﻿using System;
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
    }
}
