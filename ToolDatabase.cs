using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PGTools
{
    internal class ToolDatabase : ITool
    {
        private ToolDatabaseUI toolUI;

        public IToolRuner ToolRuner { get; set; }

        public string Caption { get => "Database Tool"; }

        public bool ButtonNextEnable { get => false; }

        public UserControl MainContainer
        {
            get
            {
                if (toolUI == null) toolUI = new ToolDatabaseUI(this);
                return toolUI;
            }
        }

        public DatabaseService DatabaseService { get; } = new DatabaseService();

        public DatabaseParams DatabaseParams { get; } = new DatabaseParams();

        public ToolDatabase(IToolRuner toolRuner)
        {
            ToolRuner = toolRuner;
        }

        public void ButtonNextClick() { }
    }
}
