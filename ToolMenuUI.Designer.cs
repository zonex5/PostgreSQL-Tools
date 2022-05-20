namespace PostgreSQL_Restore_DB
{
    partial class ToolMenuUI
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToolMenuUI));
            this.btDelete = new System.Windows.Forms.Button();
            this.btRestore = new System.Windows.Forms.Button();
            this.btMainDump = new System.Windows.Forms.Button();
            this.btTransfer = new System.Windows.Forms.Button();
            this.btUser = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btDelete
            // 
            this.btDelete.FlatAppearance.BorderSize = 0;
            this.btDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDelete.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btDelete.Image = ((System.Drawing.Image)(resources.GetObject("btDelete.Image")));
            this.btDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDelete.Location = new System.Drawing.Point(12, 155);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(200, 40);
            this.btDelete.TabIndex = 8;
            this.btDelete.Text = "   Database Management";
            this.btDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // btRestore
            // 
            this.btRestore.FlatAppearance.BorderSize = 0;
            this.btRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btRestore.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btRestore.Image = ((System.Drawing.Image)(resources.GetObject("btRestore.Image")));
            this.btRestore.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btRestore.Location = new System.Drawing.Point(12, 59);
            this.btRestore.Name = "btRestore";
            this.btRestore.Size = new System.Drawing.Size(200, 40);
            this.btRestore.TabIndex = 6;
            this.btRestore.Text = "   Restore Database Tool";
            this.btRestore.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btRestore.UseVisualStyleBackColor = true;
            this.btRestore.Click += new System.EventHandler(this.btRestore_Click);
            // 
            // btMainDump
            // 
            this.btMainDump.FlatAppearance.BorderSize = 0;
            this.btMainDump.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btMainDump.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btMainDump.Image = ((System.Drawing.Image)(resources.GetObject("btMainDump.Image")));
            this.btMainDump.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btMainDump.Location = new System.Drawing.Point(12, 11);
            this.btMainDump.Name = "btMainDump";
            this.btMainDump.Size = new System.Drawing.Size(200, 40);
            this.btMainDump.TabIndex = 5;
            this.btMainDump.Text = "   Dump Database Tool";
            this.btMainDump.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btMainDump.UseVisualStyleBackColor = true;
            this.btMainDump.Click += new System.EventHandler(this.btMainDump_Click);
            // 
            // btTransfer
            // 
            this.btTransfer.FlatAppearance.BorderSize = 0;
            this.btTransfer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btTransfer.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btTransfer.Image = ((System.Drawing.Image)(resources.GetObject("btTransfer.Image")));
            this.btTransfer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btTransfer.Location = new System.Drawing.Point(12, 107);
            this.btTransfer.Name = "btTransfer";
            this.btTransfer.Size = new System.Drawing.Size(200, 40);
            this.btTransfer.TabIndex = 7;
            this.btTransfer.Text = "   Data Transfer Tool";
            this.btTransfer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btTransfer.UseVisualStyleBackColor = true;
            this.btTransfer.Click += new System.EventHandler(this.btTransfer_Click);
            // 
            // btUser
            // 
            this.btUser.Enabled = false;
            this.btUser.FlatAppearance.BorderSize = 0;
            this.btUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btUser.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btUser.Image = ((System.Drawing.Image)(resources.GetObject("btUser.Image")));
            this.btUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btUser.Location = new System.Drawing.Point(12, 203);
            this.btUser.Name = "btUser";
            this.btUser.Size = new System.Drawing.Size(200, 40);
            this.btUser.TabIndex = 10;
            this.btUser.Text = "   Users And Roles Tool";
            this.btUser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btUser.UseVisualStyleBackColor = true;
            this.btUser.Click += new System.EventHandler(this.btUser_Click);
            // 
            // ToolMenuUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btUser);
            this.Controls.Add(this.btDelete);
            this.Controls.Add(this.btRestore);
            this.Controls.Add(this.btMainDump);
            this.Controls.Add(this.btTransfer);
            this.Name = "ToolMenuUI";
            this.Size = new System.Drawing.Size(667, 305);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.Button btRestore;
        private System.Windows.Forms.Button btMainDump;
        private System.Windows.Forms.Button btTransfer;
        private System.Windows.Forms.Button btUser;
    }
}
