using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostgreSQL_Restore_DB
{
    public interface IToolUI
    {
        ITool ParentTool { get; }
    }
}
