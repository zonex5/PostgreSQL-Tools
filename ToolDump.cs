using System;
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

        public UserControl MainContainer
        {
            get
            {
                if (toolDumpUI == null) toolDumpUI = new ToolDumpUI(this);
                return toolDumpUI;
            }
        }

        public ToolDump(IToolRuner toolRuner)
        {
            ToolRuner = toolRuner;
        }
    }
}
