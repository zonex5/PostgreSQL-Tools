using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PGTools
{
    internal class ToolMenu : ITool
    {
        private ToolMenuUI menuUI;

        public IToolRuner ToolRuner { get; }

        public string Caption => "PostgreSQL Tools";

        public bool ButtonNextEnable { get => false; }

        public UserControl MainContainer
        {
            get
            {
                if (menuUI == null) menuUI = new ToolMenuUI(this);
                return menuUI;
            }
        }

        public DatabaseService DatabaseService { get; }

        public DatabaseParams DatabaseParams { get; }

        public ToolMenu(IToolRuner toolRuner)
        {
            ToolRuner = toolRuner;
        }

        public void ButtonNextClick() { }
    }
}
