﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PGTools
{
    public interface IToolRuner
    {
        void RunTool(ITool tool);

        void SetCursor(Cursor cursor);
    }
}
