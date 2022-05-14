using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PostgreSQL_Restore_DB
{
    internal class ToolMenu : ITool
    {
        private ToolMenuUI menuUI;

        public IToolRuner ToolRuner { get; }

        public string Caption => "PostgreSQL Tools";

        public UserControl MainContainer
        {
            get
            {
                if (menuUI == null) menuUI = new ToolMenuUI(this);
                return menuUI;
            }
        }

        public ToolMenu(IToolRuner toolRuner)
        {
            ToolRuner = toolRuner;
        }
    }
}
