namespace PGTools
{
    partial class ToolTransfer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToolTransfer));
            this.label5 = new System.Windows.Forms.Label();
            this.tbPassSrc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbUserSrc = new System.Windows.Forms.TextBox();
            this.cbDatabaseSrc = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbPortSrc = new System.Windows.Forms.TextBox();
            this.cbHostSrc = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbHostDest = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbPassDest = new System.Windows.Forms.TextBox();
            this.tbPortDest = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbUserDest = new System.Windows.Forms.TextBox();
            this.btNext = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 40;
            this.label5.Text = "Password";
            // 
            // tbPassSrc
            // 
            this.tbPassSrc.Location = new System.Drawing.Point(90, 92);
            this.tbPassSrc.Name = "tbPassSrc";
            this.tbPassSrc.Size = new System.Drawing.Size(397, 20);
            this.tbPassSrc.TabIndex = 39;
            this.tbPassSrc.Text = "postgres";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 38;
            this.label4.Text = "User";
            // 
            // tbUserSrc
            // 
            this.tbUserSrc.Location = new System.Drawing.Point(90, 59);
            this.tbUserSrc.Name = "tbUserSrc";
            this.tbUserSrc.Size = new System.Drawing.Size(397, 20);
            this.tbUserSrc.TabIndex = 37;
            this.tbUserSrc.Text = "postgres";
            // 
            // cbDatabaseSrc
            // 
            this.cbDatabaseSrc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDatabaseSrc.FormattingEnabled = true;
            this.cbDatabaseSrc.Location = new System.Drawing.Point(90, 125);
            this.cbDatabaseSrc.Name = "cbDatabaseSrc";
            this.cbDatabaseSrc.Size = new System.Drawing.Size(397, 21);
            this.cbDatabaseSrc.TabIndex = 36;
            this.cbDatabaseSrc.DropDown += new System.EventHandler(this.cbDatabaseSrc_DropDown);
            this.cbDatabaseSrc.DropDownClosed += new System.EventHandler(this.cbDatabaseSrc_DropDownClosed);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Database";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(387, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 32;
            this.label6.Text = "Port";
            // 
            // tbPortSrc
            // 
            this.tbPortSrc.Location = new System.Drawing.Point(419, 26);
            this.tbPortSrc.Name = "tbPortSrc";
            this.tbPortSrc.Size = new System.Drawing.Size(68, 20);
            this.tbPortSrc.TabIndex = 31;
            // 
            // cbHostSrc
            // 
            this.cbHostSrc.FormattingEnabled = true;
            this.cbHostSrc.Location = new System.Drawing.Point(90, 25);
            this.cbHostSrc.Name = "cbHostSrc";
            this.cbHostSrc.Size = new System.Drawing.Size(273, 21);
            this.cbHostSrc.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Host name";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbHostSrc);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbPassSrc);
            this.groupBox1.Controls.Add(this.tbPortSrc);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tbUserSrc);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbDatabaseSrc);
            this.groupBox1.Location = new System.Drawing.Point(13, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(510, 159);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data Source";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbHostDest);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.tbPassDest);
            this.groupBox2.Controls.Add(this.tbPortDest);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.tbUserDest);
            this.groupBox2.Location = new System.Drawing.Point(13, 168);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(510, 118);
            this.groupBox2.TabIndex = 42;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Data Destination";
            // 
            // cbHostDest
            // 
            this.cbHostDest.FormattingEnabled = true;
            this.cbHostDest.Location = new System.Drawing.Point(90, 23);
            this.cbHostDest.Name = "cbHostDest";
            this.cbHostDest.Size = new System.Drawing.Size(273, 21);
            this.cbHostDest.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 40;
            this.label3.Text = "Password";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "Host name";
            // 
            // tbPassDest
            // 
            this.tbPassDest.Location = new System.Drawing.Point(90, 86);
            this.tbPassDest.Name = "tbPassDest";
            this.tbPassDest.Size = new System.Drawing.Size(397, 20);
            this.tbPassDest.TabIndex = 39;
            this.tbPassDest.Text = "postgres";
            // 
            // tbPortDest
            // 
            this.tbPortDest.Location = new System.Drawing.Point(419, 24);
            this.tbPortDest.Name = "tbPortDest";
            this.tbPortDest.Size = new System.Drawing.Size(68, 20);
            this.tbPortDest.TabIndex = 31;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(23, 59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 38;
            this.label8.Text = "User";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(387, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(26, 13);
            this.label9.TabIndex = 32;
            this.label9.Text = "Port";
            // 
            // tbUserDest
            // 
            this.tbUserDest.Location = new System.Drawing.Point(90, 55);
            this.tbUserDest.Name = "tbUserDest";
            this.tbUserDest.Size = new System.Drawing.Size(397, 20);
            this.tbUserDest.TabIndex = 37;
            this.tbUserDest.Text = "postgres";
            // 
            // btNext
            // 
            this.btNext.Image = ((System.Drawing.Image)(resources.GetObject("btNext.Image")));
            this.btNext.Location = new System.Drawing.Point(437, 292);
            this.btNext.Name = "btNext";
            this.btNext.Size = new System.Drawing.Size(86, 26);
            this.btNext.TabIndex = 43;
            this.btNext.Text = "Run";
            this.btNext.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btNext.UseVisualStyleBackColor = true;
            this.btNext.Click += new System.EventHandler(this.btNext_Click);
            // 
            // ToolTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btNext);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ToolTransfer";
            this.Size = new System.Drawing.Size(535, 330);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbPassSrc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbUserSrc;
        private System.Windows.Forms.ComboBox cbDatabaseSrc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbPortSrc;
        private System.Windows.Forms.ComboBox cbHostSrc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbHostDest;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbPassDest;
        private System.Windows.Forms.TextBox tbPortDest;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbUserDest;
        private System.Windows.Forms.Button btNext;
    }
}
