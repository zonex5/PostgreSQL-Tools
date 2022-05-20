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
    public partial class LoadingForm : Form, IBusyBox
    {
        private Action<IBusyBox> worker;

        public LoadingForm(Action<IBusyBox> worker)
        {
            InitializeComponent();
            this.worker = worker;
        }

        private void LoadingForm_Load(object sender, EventArgs e)
        {
            if (worker != null)
            {
                worker(this);
            }
            else
                DialogResult = DialogResult.Cancel;
        }

        private void LoadingForm_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.LightGray, ButtonBorderStyle.Solid);
        }

        private void LoadingForm_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = e.Alt && e.KeyCode == Keys.F4;
        }
    }
}
