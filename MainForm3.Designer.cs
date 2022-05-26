namespace PGTools
{
    partial class MainForm3
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm3));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.container = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btBack = new System.Windows.Forms.Button();
            this.btLogs = new System.Windows.Forms.Button();
            this.lbCaption = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(130, 325);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.container);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(1, 47);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(670, 330);
            this.panel1.TabIndex = 5;
            // 
            // container
            // 
            this.container.Location = new System.Drawing.Point(134, 1);
            this.container.Name = "container";
            this.container.Size = new System.Drawing.Size(535, 330);
            this.container.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.btBack);
            this.panel2.Controls.Add(this.btLogs);
            this.panel2.Controls.Add(this.lbCaption);
            this.panel2.Location = new System.Drawing.Point(0, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(670, 40);
            this.panel2.TabIndex = 6;
            // 
            // btBack
            // 
            this.btBack.Enabled = false;
            this.btBack.FlatAppearance.BorderSize = 0;
            this.btBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBack.Image = ((System.Drawing.Image)(resources.GetObject("btBack.Image")));
            this.btBack.Location = new System.Drawing.Point(3, 2);
            this.btBack.Name = "btBack";
            this.btBack.Size = new System.Drawing.Size(41, 35);
            this.btBack.TabIndex = 8;
            this.btBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btBack.UseVisualStyleBackColor = true;
            this.btBack.Click += new System.EventHandler(this.btBack_Click);
            // 
            // btLogs
            // 
            this.btLogs.FlatAppearance.BorderSize = 0;
            this.btLogs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btLogs.Image = ((System.Drawing.Image)(resources.GetObject("btLogs.Image")));
            this.btLogs.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btLogs.Location = new System.Drawing.Point(638, 8);
            this.btLogs.Name = "btLogs";
            this.btLogs.Size = new System.Drawing.Size(25, 23);
            this.btLogs.TabIndex = 9;
            this.toolTip1.SetToolTip(this.btLogs, "View Logs");
            this.btLogs.UseVisualStyleBackColor = true;
            this.btLogs.Click += new System.EventHandler(this.btLogs_Click);
            // 
            // lbCaption
            // 
            this.lbCaption.AutoSize = true;
            this.lbCaption.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbCaption.Location = new System.Drawing.Point(43, 8);
            this.lbCaption.Name = "lbCaption";
            this.lbCaption.Size = new System.Drawing.Size(137, 21);
            this.lbCaption.TabIndex = 0;
            this.lbCaption.Text = "PostgreSQL Tools";
            // 
            // MainForm3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(672, 382);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm3";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PGTools 0.1";
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
        private System.Windows.Forms.Button btBack;
        private System.Windows.Forms.Button btLogs;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}