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
    public partial class NewDatabaseForm : Form
    {
        public string DatabaseName { get; set; }

        public NewDatabaseForm()
        {
            InitializeComponent();

            tbName.DataBindings.Add("Text", this, "DatabaseName", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btCreate_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
