namespace PostgreSQL_Restore_DB
{
    partial class MainForm2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm2));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.container = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbCaption = new System.Windows.Forms.Label();
            this.btNext = new System.Windows.Forms.Button();
            this.btBack = new System.Windows.Forms.Button();
            this.btLogs = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-1, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(136, 302);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.container);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(1, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(669, 304);
            this.panel1.TabIndex = 5;
            // 
            // container
            // 
            this.container.Location = new System.Drawing.Point(134, 1);
            this.container.Name = "container";
            this.container.Size = new System.Drawing.Size(535, 300);
            this.container.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.lbCaption);
            this.panel2.Location = new System.Drawing.Point(0, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(670, 39);
            this.panel2.TabIndex = 6;
            // 
            // lbCaption
            // 
            this.lbCaption.AutoSize = true;
            this.lbCaption.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbCaption.Location = new System.Drawing.Point(17, 8);
            this.lbCaption.Name = "lbCaption";
            this.lbCaption.Size = new System.Drawing.Size(137, 21);
            this.lbCaption.TabIndex = 0;
            this.lbCaption.Text = "PostgreSQL Tools";
            // 
            // btNext
            // 
            this.btNext.Enabled = false;
            this.btNext.Image = ((System.Drawing.Image)(resources.GetObject("btNext.Image")));
            this.btNext.Location = new System.Drawing.Point(578, 359);
            this.btNext.Name = "btNext";
            this.btNext.Size = new System.Drawing.Size(82, 26);
            this.btNext.TabIndex = 7;
            this.btNext.Text = "Next ";
            this.btNext.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btNext.UseVisualStyleBackColor = true;
            this.btNext.Click += new System.EventHandler(this.btNext_Click);
            // 
            // btBack
            // 
            this.btBack.Enabled = false;
            this.btBack.Image = ((System.Drawing.Image)(resources.GetObject("btBack.Image")));
            this.btBack.Location = new System.Drawing.Point(489, 359);
            this.btBack.Name = "btBack";
            this.btBack.Size = new System.Drawing.Size(82, 26);
            this.btBack.TabIndex = 8;
            this.btBack.Text = "Back";
            this.btBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btBack.UseVisualStyleBackColor = true;
            this.btBack.Click += new System.EventHandler(this.btBack_Click);
            // 
            // btLogs
            // 
            this.btLogs.Image = ((System.Drawing.Image)(resources.GetObject("btLogs.Image")));
            this.btLogs.Location = new System.Drawing.Point(12, 359);
            this.btLogs.Name = "btLogs";
            this.btLogs.Size = new System.Drawing.Size(82, 26);
            this.btLogs.TabIndex = 9;
            this.btLogs.Text = "View Logs";
            this.btLogs.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btLogs.UseVisualStyleBackColor = true;
            this.btLogs.Click += new System.EventHandler(this.btLogs_Click);
            // 
            // MainForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(670, 392);
            this.Controls.Add(this.btLogs);
            this.Controls.Add(this.btBack);
            this.Controls.Add(this.btNext);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PostgreSQL Tool";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbCaption;
        private System.Windows.Forms.Panel container;
        private System.Windows.Forms.Button btNext;
        private System.Windows.Forms.Button btBack;
        private System.Windows.Forms.Button btLogs;
    }
}