﻿using System;
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
    public partial class ToolUsersUI : UserControl, IToolUI
    {
        public ToolUsersUI(ITool parentTool)
        {
            InitializeComponent();
            ParentTool = parentTool;
        }

        public ITool ParentTool { get; set; }


    }
}
