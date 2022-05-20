using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PostgreSQL_Restore_DB
{
    public class ToolRestore : ITool
    {
        private ToolRestoreUI toolUI;

        public IToolRuner ToolRuner { get; set; }

        public string Caption { get => "Database Restore Tool"; }

        public bool ButtonNextEnable { get => true; }

        public UserControl MainContainer
        {
            get
            {
                if (toolUI == null) toolUI = new ToolRestoreUI(this);
                return toolUI;
            }
        }

        public DatabaseService DatabaseService { get; } = new DatabaseService();

        public DatabaseParams DatabaseParams { get; } = new DatabaseParams();

        public ToolRestore(IToolRuner toolRuner)
        {
            ToolRuner = toolRuner;
        }

        public void ButtonNextClick()
        {
            if (!DatabaseParams.ValidParams)
            {
                MessageBox.Show("Please complete all fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Action<IBusyBox> action = async (IBusyBox busyBox) =>
            {
                if (await DatabaseService.doRestore(DatabaseParams) != 0)
                {
                    busyBox.Close();
                    MessageBox.Show("Restore operation error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    busyBox.Close();
                    MessageBox.Show("Restore operation have been completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            };

            new LoadingForm(action).ShowDialog();
        }
    }
}
