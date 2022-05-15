﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PostgreSQL_Restore_DB
{
    public class ToolDump : ITool
    {
        private ToolDumpUI toolDumpUI;

        public IToolRuner ToolRuner { get; set; }

        public string Caption { get => "Database Dump Tool"; }

        public bool ButtonNextEnable { get => true; }

        public UserControl MainContainer
        {
            get
            {
                if (toolDumpUI == null) toolDumpUI = new ToolDumpUI(this);
                return toolDumpUI;
            }
        }

        public DatabaseService DatabaseService { get; } = new DatabaseService();

        public DatabaseParams DatabaseParams { get; } = new DatabaseParams();

        public ToolDump(IToolRuner toolRuner)
        {
            ToolRuner = toolRuner;
        }

        async public void ButtonNextClick()
        {
            if (!DatabaseParams.ValidParams)
            {
                MessageBox.Show("Please complete all fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (await DatabaseService.doDump(DatabaseParams) != 0)
            {
                MessageBox.Show("Dump operation error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Dump operation have been completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
