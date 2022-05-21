using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PostgreSQL_Restore_DB
{
    public class ToolCreate : ITool
    {
        private ToolCreateUI toolUI;

        public IToolRuner ToolRuner { get; set; }

        public string Caption { get => "Create Database Tool"; }

        public bool ButtonNextEnable { get => true; }

        public UserControl MainContainer
        {
            get
            {
                if (toolUI == null) toolUI = new ToolCreateUI(this);
                return toolUI;
            }
        }

        public DatabaseService DatabaseService { get; } = new DatabaseService();

        public DatabaseParams DatabaseParams { get; } = new DatabaseParams();

        public ToolCreate(IToolRuner toolRuner)
        {
            ToolRuner = toolRuner;
        }

        public void ButtonNextClick()
        {
            if (!DatabaseParams.ValidBaseParams || string.IsNullOrEmpty(DatabaseParams.Database))
            {
                MessageBox.Show("Please complete all fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Action<IBusyBox> action = async (IBusyBox busyBox) =>
            {
                if (await DatabaseService.doCreate(DatabaseParams) != 0)
                {
                    busyBox.Close();
                    MessageBox.Show("Create database operation error. See application logs.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    busyBox.Close();
                    MessageBox.Show("Create database operation have been completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            };

            new LoadingForm(action).ShowDialog();
        }
    }
}
