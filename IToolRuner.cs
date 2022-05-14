using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PostgreSQL_Restore_DB
{
    public interface IToolRuner
    {
        event Action OnClickNext;

        void RunTool(ITool tool);

        void SetCursor(Cursor cursor);
    }
}
