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
        private ToolDatabaseUI toolUI;

        public IToolRuner ToolRuner { get; set; }

        public string Caption { get => "Database Restore Tool"; }

        public bool ButtonNextEnable { get => true; }

        public UserControl MainContainer
        {
            get
            {
                if (toolUI == null) toolUI = new ToolDatabaseUI(this);
                return toolUI;
            }
        }

        public ToolRestore(IToolRuner toolRuner)
        {
            ToolRuner = toolRuner;

            toolRuner.OnClickNext += ToolRuner_OnClickNext;
        }

        private void ToolRuner_OnClickNext()
        {

        }
    }
}
