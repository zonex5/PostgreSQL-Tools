using System;
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
    public partial class ToolDumpUI : UserControl, IToolUI
    {
        public ITool ParetntTool { get; set; }

        public ToolDumpUI(ITool parentTool)
        {
            InitializeComponent();
            ParetntTool = parentTool;
        }
    }
}
