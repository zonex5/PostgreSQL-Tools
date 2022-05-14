using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PostgreSQL_Restore_DB
{
    public interface ITool
    {
        string Caption { get; }

        IToolRuner ToolRuner { get; }

        UserControl MainContainer { get; }
    }
}
