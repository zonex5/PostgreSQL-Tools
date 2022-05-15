using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PostgreSQL_Restore_DB
{
    public class ToolRestore : ITool
    {
        private ToolDumpUI toolDumpUI;

        public IToolRuner ToolRuner { get; set; }

        public string Caption { get => "Database Restore Tool"; }

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

        public ToolRestore(IToolRuner toolRuner)
        {
            ToolRuner = toolRuner;
        }

        public void ButtonNextClick()
        {

            MessageBox.Show("ok restore");
        }
    }
}
