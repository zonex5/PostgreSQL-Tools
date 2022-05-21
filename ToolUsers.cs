using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PostgreSQL_Restore_DB
{
    public class ToolUsers : ITool
    {
        private ToolUsersUI toolUI;

        public IToolRuner ToolRuner { get; set; }

        public string Caption { get => "User Management Tool"; }

        public bool ButtonNextEnable { get => true; }

        public UserControl MainContainer
        {
            get
            {
                if (toolUI == null) toolUI = new ToolUsersUI(this);
                return toolUI;
            }
        }

        public DatabaseService DatabaseService { get; } = new DatabaseService();

        public DatabaseParams DatabaseParams { get; } = new DatabaseParams();

        public ToolUsers(IToolRuner toolRuner)
        {
            ToolRuner = toolRuner;
        }

        async public void ButtonNextClick()
        {
            if (!DatabaseParams.ValidParams)
            {
                MessageBox.Show("Please complete all fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            /*if (await DatabaseService.doRestore(DatabaseParams) != 0)
            {
                MessageBox.Show("Restore operation error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Restore operation have been completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }*/
        }
    }
}
