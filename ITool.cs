using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PGTools
{
    public interface ITool
    {
        string Caption { get; }

        UserControl MainContainer { get; }

        IToolRuner ToolRuner { get; }

        DatabaseParams DatabaseParams { get; }

        DatabaseService DatabaseService { get; }
    }
}
