namespace PGTools
{
    partial class MainForm
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.tbConcole = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btDumpRefresh = new System.Windows.Forms.Button();
            this.cbDumpDatabase = new System.Windows.Forms.ComboBox();
            this.btDumpRun = new System.Windows.Forms.Button();
            this.btDumpLocation = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tbDumpLocation = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbDumpPort = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbDumpPass = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbDumpUser = new System.Windows.Forms.TextBox();
            this.cbDumpDumpFormat = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbDumpHost = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label13 = new System.Windows.Forms.Label();
            this.tbRestorePass = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tbRestoreUser = new System.Windows.Forms.TextBox();
            this.btRestoreRun = new System.Windows.Forms.Button();
            this.tbRestoreDatabase = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbRestorePort = new System.Windows.Forms.TextBox();
            this.cbRestoreHost = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btRestoreLocation = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.tbRestoreLocation = new System.Windows.Forms.TextBox();
            this.cbRestoreFormat = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.rbConsole = new System.Windows.Forms.RichTextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(886, 248);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(805, 248);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "smb";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(967, 248);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "version";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tbConcole
            // 
            this.tbConcole.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbConcole.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbConcole.Location = new System.Drawing.Point(706, 320);
            this.tbConcole.Multiline = true;
            this.tbConcole.Name = "tbConcole";
            this.tbConcole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbConcole.Size = new System.Drawing.Size(449, 291);
            this.tbConcole.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(2, 43);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(632, 336);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btDumpRefresh);
            this.tabPage1.Controls.Add(this.cbDumpDatabase);
            this.tabPage1.Controls.Add(this.btDumpRun);
            this.tabPage1.Controls.Add(this.btDumpLocation);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.tbDumpLocation);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.tbDumpPort);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.tbDumpPass);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.tbDumpUser);
            this.tabPage1.Controls.Add(this.cbDumpDumpFormat);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.cbDumpHost);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(624, 310);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Dump";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btDumpRefresh
            // 
            this.btDumpRefresh.FlatAppearance.BorderSize = 0;
            this.btDumpRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDumpRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btDumpRefresh.Image")));
            this.btDumpRefresh.Location = new System.Drawing.Point(351, 95);
            this.btDumpRefresh.Name = "btDumpRefresh";
            this.btDumpRefresh.Size = new System.Drawing.Size(23, 23);
            this.btDumpRefresh.TabIndex = 17;
            this.toolTip1.SetToolTip(this.btDumpRefresh, "Refresh Database List");
            this.btDumpRefresh.UseVisualStyleBackColor = true;
            this.btDumpRefresh.Click += new System.EventHandler(this.btDumpRefresh_Click);
            // 
            // cbDumpDatabase
            // 
            this.cbDumpDatabase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDumpDatabase.FormattingEnabled = true;
            this.cbDumpDatabase.Location = new System.Drawing.Point(104, 97);
            this.cbDumpDatabase.Name = "cbDumpDatabase";
            this.cbDumpDatabase.Size = new System.Drawing.Size(244, 21);
            this.cbDumpDatabase.TabIndex = 16;
            // 
            // btDumpRun
            // 
            this.btDumpRun.Image = ((System.Drawing.Image)(resources.GetObject("btDumpRun.Image")));
            this.btDumpRun.Location = new System.Drawing.Point(260, 260);
            this.btDumpRun.Name = "btDumpRun";
            this.btDumpRun.Size = new System.Drawing.Size(138, 26);
            this.btDumpRun.TabIndex = 15;
            this.btDumpRun.Text = "Run Dump Process";
            this.btDumpRun.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btDumpRun.UseVisualStyleBackColor = true;
            this.btDumpRun.Click += new System.EventHandler(this.btDumoRun_Click);
            // 
            // btDumpLocation
            // 
            this.btDumpLocation.BackColor = System.Drawing.SystemColors.Control;
            this.btDumpLocation.FlatAppearance.BorderSize = 0;
            this.btDumpLocation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDumpLocation.Image = ((System.Drawing.Image)(resources.GetObject("btDumpLocation.Image")));
            this.btDumpLocation.Location = new System.Drawing.Point(583, 27);
            this.btDumpLocation.Name = "btDumpLocation";
            this.btDumpLocation.Size = new System.Drawing.Size(19, 17);
            this.btDumpLocation.TabIndex = 14;
            this.btDumpLocation.UseVisualStyleBackColor = false;
            this.btDumpLocation.Click += new System.EventHandler(this.btDumpLocation_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Dump Location:";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // tbDumpLocation
            // 
            this.tbDumpLocation.Location = new System.Drawing.Point(104, 25);
            this.tbDumpLocation.Name = "tbDumpLocation";
            this.tbDumpLocation.ReadOnly = true;
            this.tbDumpLocation.Size = new System.Drawing.Size(501, 20);
            this.tbDumpLocation.TabIndex = 12;
            this.tbDumpLocation.TextChanged += new System.EventHandler(this.tbDumpLocation_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(388, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Port:";
            // 
            // tbDumpPort
            // 
            this.tbDumpPort.Location = new System.Drawing.Point(420, 62);
            this.tbDumpPort.Name = "tbDumpPort";
            this.tbDumpPort.Size = new System.Drawing.Size(185, 20);
            this.tbDumpPort.TabIndex = 10;
            this.tbDumpPort.Text = "5432";
            this.tbDumpPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbDumpPort_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 189);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Password:";
            // 
            // tbDumpPass
            // 
            this.tbDumpPass.Location = new System.Drawing.Point(104, 185);
            this.tbDumpPass.Name = "tbDumpPass";
            this.tbDumpPass.Size = new System.Drawing.Size(141, 20);
            this.tbDumpPass.TabIndex = 8;
            this.tbDumpPass.Text = "postgres";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(69, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "User:";
            // 
            // tbDumpUser
            // 
            this.tbDumpUser.Location = new System.Drawing.Point(104, 151);
            this.tbDumpUser.Name = "tbDumpUser";
            this.tbDumpUser.Size = new System.Drawing.Size(141, 20);
            this.tbDumpUser.TabIndex = 6;
            this.tbDumpUser.Text = "postgres";
            // 
            // cbDumpDumpFormat
            // 
            this.cbDumpDumpFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDumpDumpFormat.FormattingEnabled = true;
            this.cbDumpDumpFormat.Location = new System.Drawing.Point(464, 97);
            this.cbDumpDumpFormat.Name = "cbDumpDumpFormat";
            this.cbDumpDumpFormat.Size = new System.Drawing.Size(141, 21);
            this.cbDumpDumpFormat.TabIndex = 5;
            this.cbDumpDumpFormat.SelectedIndexChanged += new System.EventHandler(this.cbDumpDumpFormat_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(388, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Dump Format:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Database Name:";
            // 
            // cbDumpHost
            // 
            this.cbDumpHost.FormattingEnabled = true;
            this.cbDumpHost.Location = new System.Drawing.Point(104, 61);
            this.cbDumpHost.Name = "cbDumpHost";
            this.cbDumpHost.Size = new System.Drawing.Size(244, 21);
            this.cbDumpHost.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Host:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.tbRestorePass);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.tbRestoreUser);
            this.tabPage2.Controls.Add(this.btRestoreRun);
            this.tabPage2.Controls.Add(this.tbRestoreDatabase);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.tbRestorePort);
            this.tabPage2.Controls.Add(this.cbRestoreHost);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.btRestoreLocation);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.tbRestoreLocation);
            this.tabPage2.Controls.Add(this.cbRestoreFormat);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(624, 310);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Restore";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(45, 189);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 13);
            this.label13.TabIndex = 35;
            this.label13.Text = "Password:";
            // 
            // tbRestorePass
            // 
            this.tbRestorePass.Location = new System.Drawing.Point(104, 185);
            this.tbRestorePass.Name = "tbRestorePass";
            this.tbRestorePass.Size = new System.Drawing.Size(141, 20);
            this.tbRestorePass.TabIndex = 34;
            this.tbRestorePass.Text = "postgres";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(69, 155);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(32, 13);
            this.label14.TabIndex = 33;
            this.label14.Text = "User:";
            // 
            // tbRestoreUser
            // 
            this.tbRestoreUser.Location = new System.Drawing.Point(104, 151);
            this.tbRestoreUser.Name = "tbRestoreUser";
            this.tbRestoreUser.Size = new System.Drawing.Size(141, 20);
            this.tbRestoreUser.TabIndex = 32;
            this.tbRestoreUser.Text = "postgres";
            // 
            // btRestoreRun
            // 
            this.btRestoreRun.Image = ((System.Drawing.Image)(resources.GetObject("btRestoreRun.Image")));
            this.btRestoreRun.Location = new System.Drawing.Point(260, 260);
            this.btRestoreRun.Name = "btRestoreRun";
            this.btRestoreRun.Size = new System.Drawing.Size(138, 26);
            this.btRestoreRun.TabIndex = 31;
            this.btRestoreRun.Text = "Run Restore Process";
            this.btRestoreRun.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btRestoreRun.UseVisualStyleBackColor = true;
            this.btRestoreRun.Click += new System.EventHandler(this.btRestoreRun_Click);
            // 
            // tbRestoreDatabase
            // 
            this.tbRestoreDatabase.Location = new System.Drawing.Point(369, 25);
            this.tbRestoreDatabase.Name = "tbRestoreDatabase";
            this.tbRestoreDatabase.Size = new System.Drawing.Size(239, 20);
            this.tbRestoreDatabase.TabIndex = 30;
            this.tbRestoreDatabase.Text = "epm";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(279, 29);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(87, 13);
            this.label12.TabIndex = 24;
            this.label12.Text = "Database Name:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(421, 101);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "Port:";
            // 
            // tbRestorePort
            // 
            this.tbRestorePort.Location = new System.Drawing.Point(453, 97);
            this.tbRestorePort.Name = "tbRestorePort";
            this.tbRestorePort.Size = new System.Drawing.Size(152, 20);
            this.tbRestorePort.TabIndex = 22;
            this.tbRestorePort.Text = "5432";
            // 
            // cbRestoreHost
            // 
            this.cbRestoreHost.FormattingEnabled = true;
            this.cbRestoreHost.Location = new System.Drawing.Point(104, 97);
            this.cbRestoreHost.Name = "cbRestoreHost";
            this.cbRestoreHost.Size = new System.Drawing.Size(301, 21);
            this.cbRestoreHost.TabIndex = 21;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(69, 102);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "Host:";
            // 
            // btRestoreLocation
            // 
            this.btRestoreLocation.BackColor = System.Drawing.SystemColors.Control;
            this.btRestoreLocation.FlatAppearance.BorderSize = 0;
            this.btRestoreLocation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btRestoreLocation.Image = ((System.Drawing.Image)(resources.GetObject("btRestoreLocation.Image")));
            this.btRestoreLocation.Location = new System.Drawing.Point(584, 63);
            this.btRestoreLocation.Margin = new System.Windows.Forms.Padding(0);
            this.btRestoreLocation.Name = "btRestoreLocation";
            this.btRestoreLocation.Size = new System.Drawing.Size(19, 17);
            this.btRestoreLocation.TabIndex = 19;
            this.btRestoreLocation.UseVisualStyleBackColor = false;
            this.btRestoreLocation.Click += new System.EventHandler(this.btRestoreLocation_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Dump Location:";
            // 
            // tbRestoreLocation
            // 
            this.tbRestoreLocation.Location = new System.Drawing.Point(104, 61);
            this.tbRestoreLocation.Name = "tbRestoreLocation";
            this.tbRestoreLocation.ReadOnly = true;
            this.tbRestoreLocation.Size = new System.Drawing.Size(501, 20);
            this.tbRestoreLocation.TabIndex = 17;
            // 
            // cbRestoreFormat
            // 
            this.cbRestoreFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRestoreFormat.FormattingEnabled = true;
            this.cbRestoreFormat.Location = new System.Drawing.Point(104, 24);
            this.cbRestoreFormat.Name = "cbRestoreFormat";
            this.cbRestoreFormat.Size = new System.Drawing.Size(159, 21);
            this.cbRestoreFormat.TabIndex = 16;
            this.cbRestoreFormat.SelectedIndexChanged += new System.EventHandler(this.cbRestoreFormat_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(28, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Dump Format:";
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(624, 310);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Transfer";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.rbConsole);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(624, 310);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Log Output";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // rbConsole
            // 
            this.rbConsole.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rbConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbConsole.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbConsole.Location = new System.Drawing.Point(3, 3);
            this.rbConsole.Name = "rbConsole";
            this.rbConsole.Size = new System.Drawing.Size(618, 304);
            this.rbConsole.TabIndex = 1;
            this.rbConsole.Text = "";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(634, 37);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 381);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.tbConcole);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "PostgreSQL Tools v. 0.1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox tbConcole;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ComboBox cbDumpHost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbDumpDumpFormat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbDumpPass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbDumpUser;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbDumpPort;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbDumpLocation;
        private System.Windows.Forms.Button btDumpLocation;
        private System.Windows.Forms.Button btDumpRun;
        private System.Windows.Forms.ComboBox cbDumpDatabase;
        private System.Windows.Forms.Button btDumpRefresh;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btRestoreLocation;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbRestoreLocation;
        private System.Windows.Forms.ComboBox cbRestoreFormat;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbRestorePort;
        private System.Windows.Forms.ComboBox cbRestoreHost;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbRestoreDatabase;
        private System.Windows.Forms.Button btRestoreRun;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbRestorePass;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbRestoreUser;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.RichTextBox rbConsole;
    }
}

