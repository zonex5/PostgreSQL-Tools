using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PGTools
{
    public partial class ToolUsers : UserControl, ITool
    {
        public IToolRuner ToolRuner { get; set; }

        public UserControl MainContainer { get { return this; } }

        public string Caption { get => "User Management Tool"; }

        public DatabaseService DatabaseService { get; } = new DatabaseService();

        public DatabaseParams DatabaseParams { get; } = new DatabaseParams();
        public ToolUsers(IToolRuner toolRuner)
        {
            InitializeComponent();
            ToolRuner = toolRuner;
        }

        public ITool ParentTool { get; set; }


    }
}
