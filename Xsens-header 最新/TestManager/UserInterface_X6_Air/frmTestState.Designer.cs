namespace UserInterface
{
    partial class frmTestState
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTestState));
            this.lblStatus0 = new System.Windows.Forms.Label();
            this.txtFail = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxFailRate = new System.Windows.Forms.TextBox();
            this.textBoxPassRate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.checkboxloop = new System.Windows.Forms.CheckBox();
            this.testTime = new System.Windows.Forms.Timer(this.components);
            this.lbtesttime = new System.Windows.Forms.Label();
            this.timerLoopTest = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.bnUnitStop = new System.Windows.Forms.Button();
            this.btnUnitStart = new System.Windows.Forms.Button();
            this.lbStationname = new System.Windows.Forms.Label();
            this.linkLabelUser = new System.Windows.Forms.LinkLabel();
            this.lblooptime = new System.Windows.Forms.Label();
            this.textBoxStatue = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.cSN1 = new System.Windows.Forms.CheckBox();
            this.cSN2 = new System.Windows.Forms.CheckBox();
            this.cSN3 = new System.Windows.Forms.CheckBox();
            this.cSN4 = new System.Windows.Forms.CheckBox();
            this.cSN5 = new System.Windows.Forms.CheckBox();
            this.cSN6 = new System.Windows.Forms.CheckBox();
            this.lblStatus2 = new System.Windows.Forms.Label();
            this.lblStatus3 = new System.Windows.Forms.Label();
            this.lblStatus4 = new System.Windows.Forms.Label();
            this.lblStatus1 = new System.Windows.Forms.Label();
            this.lblStatus5 = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            this.timer5 = new System.Windows.Forms.Timer(this.components);
            this.timer6 = new System.Windows.Forms.Timer(this.components);
            this.lbtesttime1 = new System.Windows.Forms.Label();
            this.lbtesttime2 = new System.Windows.Forms.Label();
            this.lbtesttime3 = new System.Windows.Forms.Label();
            this.lbtesttime4 = new System.Windows.Forms.Label();
            this.lbtesttime5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // lblStatus0
            // 
            this.lblStatus0.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus0.BackColor = System.Drawing.Color.RoyalBlue;
            this.lblStatus0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblStatus0.Font = new System.Drawing.Font("Times New Roman", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus0.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblStatus0.Location = new System.Drawing.Point(5, 85);
            this.lblStatus0.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblStatus0.Name = "lblStatus0";
            this.lblStatus0.Size = new System.Drawing.Size(232, 48);
            this.lblStatus0.TabIndex = 2;
            this.lblStatus0.Text = "IDLE";
            this.lblStatus0.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtFail
            // 
            this.txtFail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFail.BackColor = System.Drawing.Color.Red;
            this.txtFail.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtFail.Location = new System.Drawing.Point(75, 66);
            this.txtFail.Margin = new System.Windows.Forms.Padding(5);
            this.txtFail.Name = "txtFail";
            this.txtFail.ReadOnly = true;
            this.txtFail.Size = new System.Drawing.Size(72, 39);
            this.txtFail.TabIndex = 31;
            this.txtFail.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(3, 73);
            this.label13.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(58, 31);
            this.label13.TabIndex = 26;
            this.label13.Text = "Fail:";
            // 
            // txtPass
            // 
            this.txtPass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txtPass.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPass.Location = new System.Drawing.Point(75, 33);
            this.txtPass.Margin = new System.Windows.Forms.Padding(5);
            this.txtPass.Name = "txtPass";
            this.txtPass.ReadOnly = true;
            this.txtPass.Size = new System.Drawing.Size(72, 39);
            this.txtPass.TabIndex = 30;
            this.txtPass.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(3, 36);
            this.label12.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 31);
            this.label12.TabIndex = 28;
            this.label12.Text = "Pass:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(32, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(170, 47);
            this.pictureBox1.TabIndex = 46;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBoxFailRate);
            this.groupBox1.Controls.Add(this.textBoxPassRate);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtFail);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtPass);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Location = new System.Drawing.Point(1, 470);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(236, 99);
            this.groupBox1.TabIndex = 49;
            this.groupBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(159, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 31);
            this.label6.TabIndex = 35;
            this.label6.Text = "Rate:";
            // 
            // textBoxFailRate
            // 
            this.textBoxFailRate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFailRate.BackColor = System.Drawing.Color.Red;
            this.textBoxFailRate.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxFailRate.Location = new System.Drawing.Point(156, 66);
            this.textBoxFailRate.Margin = new System.Windows.Forms.Padding(5);
            this.textBoxFailRate.Name = "textBoxFailRate";
            this.textBoxFailRate.ReadOnly = true;
            this.textBoxFailRate.Size = new System.Drawing.Size(72, 39);
            this.textBoxFailRate.TabIndex = 34;
            this.textBoxFailRate.Text = "0";
            // 
            // textBoxPassRate
            // 
            this.textBoxPassRate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPassRate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.textBoxPassRate.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxPassRate.Location = new System.Drawing.Point(156, 33);
            this.textBoxPassRate.Margin = new System.Windows.Forms.Padding(5);
            this.textBoxPassRate.Name = "textBoxPassRate";
            this.textBoxPassRate.ReadOnly = true;
            this.textBoxPassRate.Size = new System.Drawing.Size(72, 39);
            this.textBoxPassRate.TabIndex = 33;
            this.textBoxPassRate.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(79, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 31);
            this.label5.TabIndex = 32;
            this.label5.Text = "Test:";
            // 
            // checkboxloop
            // 
            this.checkboxloop.AutoSize = true;
            this.checkboxloop.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkboxloop.Location = new System.Drawing.Point(4, 429);
            this.checkboxloop.Name = "checkboxloop";
            this.checkboxloop.Size = new System.Drawing.Size(166, 35);
            this.checkboxloop.TabIndex = 50;
            this.checkboxloop.Text = "循环测试？";
            this.checkboxloop.UseVisualStyleBackColor = true;
            this.checkboxloop.Visible = false;
            this.checkboxloop.CheckedChanged += new System.EventHandler(this.checkboxloop_CheckedChanged);
            // 
            // testTime
            // 
            this.testTime.Tick += new System.EventHandler(this.testTime_Tick);
            // 
            // lbtesttime
            // 
            this.lbtesttime.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.lbtesttime.Location = new System.Drawing.Point(239, 80);
            this.lbtesttime.Name = "lbtesttime";
            this.lbtesttime.Size = new System.Drawing.Size(57, 29);
            this.lbtesttime.TabIndex = 51;
            this.lbtesttime.Text = "0000";
            this.lbtesttime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerLoopTest
            // 
            this.timerLoopTest.Enabled = true;
            this.timerLoopTest.Interval = 3000;
            this.timerLoopTest.Tick += new System.EventHandler(this.timerLoopTest_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 31);
            this.label2.TabIndex = 53;
            // 
            // bnUnitStop
            // 
            this.bnUnitStop.Location = new System.Drawing.Point(156, 386);
            this.bnUnitStop.Name = "bnUnitStop";
            this.bnUnitStop.Size = new System.Drawing.Size(97, 44);
            this.bnUnitStop.TabIndex = 55;
            this.bnUnitStop.Text = "Stop(F6)";
            this.bnUnitStop.UseVisualStyleBackColor = true;
            this.bnUnitStop.Click += new System.EventHandler(this.bnUnitStop_Click);
            // 
            // btnUnitStart
            // 
            this.btnUnitStart.Location = new System.Drawing.Point(34, 386);
            this.btnUnitStart.Name = "btnUnitStart";
            this.btnUnitStart.Size = new System.Drawing.Size(97, 44);
            this.btnUnitStart.TabIndex = 54;
            this.btnUnitStart.Text = "Start";
            this.btnUnitStart.UseVisualStyleBackColor = true;
            this.btnUnitStart.Click += new System.EventHandler(this.btnUnitStart_Click);
            // 
            // lbStationname
            // 
            this.lbStationname.AutoSize = true;
            this.lbStationname.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbStationname.Location = new System.Drawing.Point(2, 609);
            this.lbStationname.Name = "lbStationname";
            this.lbStationname.Size = new System.Drawing.Size(331, 31);
            this.lbStationname.TabIndex = 60;
            this.lbStationname.Text = "Station:JR3_Glass_Alsar_001";
            // 
            // linkLabelUser
            // 
            this.linkLabelUser.AutoSize = true;
            this.linkLabelUser.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkLabelUser.Location = new System.Drawing.Point(4, 633);
            this.linkLabelUser.Name = "linkLabelUser";
            this.linkLabelUser.Size = new System.Drawing.Size(85, 31);
            this.linkLabelUser.TabIndex = 61;
            this.linkLabelUser.TabStop = true;
            this.linkLabelUser.Text = "admin";
            this.linkLabelUser.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelUser_LinkClicked);
            // 
            // lblooptime
            // 
            this.lblooptime.AutoSize = true;
            this.lblooptime.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblooptime.Location = new System.Drawing.Point(3, 455);
            this.lblooptime.Name = "lblooptime";
            this.lblooptime.Size = new System.Drawing.Size(203, 31);
            this.lblooptime.TabIndex = 62;
            this.lblooptime.Text = "Current Loop：0";
            this.lblooptime.Visible = false;
            // 
            // textBoxStatue
            // 
            this.textBoxStatue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxStatue.Font = new System.Drawing.Font("微软雅黑", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxStatue.ForeColor = System.Drawing.Color.Red;
            this.textBoxStatue.Location = new System.Drawing.Point(1, 575);
            this.textBoxStatue.Multiline = true;
            this.textBoxStatue.Name = "textBoxStatue";
            this.textBoxStatue.Size = new System.Drawing.Size(279, 35);
            this.textBoxStatue.TabIndex = 64;
            this.textBoxStatue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxStatue.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(214, 432);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 65;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.bnReset_Click);
            // 
            // cSN1
            // 
            this.cSN1.AutoSize = true;
            this.cSN1.Checked = true;
            this.cSN1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cSN1.Location = new System.Drawing.Point(258, 112);
            this.cSN1.Name = "cSN1";
            this.cSN1.Size = new System.Drawing.Size(28, 27);
            this.cSN1.TabIndex = 66;
            this.cSN1.UseVisualStyleBackColor = true;
            this.cSN1.CheckedChanged += new System.EventHandler(this.cSN1_CheckedChanged);
            // 
            // cSN2
            // 
            this.cSN2.AutoSize = true;
            this.cSN2.Enabled = false;
            this.cSN2.Location = new System.Drawing.Point(258, 159);
            this.cSN2.Name = "cSN2";
            this.cSN2.Size = new System.Drawing.Size(28, 27);
            this.cSN2.TabIndex = 67;
            this.cSN2.UseVisualStyleBackColor = true;
            this.cSN2.CheckedChanged += new System.EventHandler(this.cSN2_CheckedChanged);
            // 
            // cSN3
            // 
            this.cSN3.AutoSize = true;
            this.cSN3.Enabled = false;
            this.cSN3.Location = new System.Drawing.Point(258, 210);
            this.cSN3.Name = "cSN3";
            this.cSN3.Size = new System.Drawing.Size(28, 27);
            this.cSN3.TabIndex = 68;
            this.cSN3.UseVisualStyleBackColor = true;
            this.cSN3.CheckedChanged += new System.EventHandler(this.cSN3_CheckedChanged);
            // 
            // cSN4
            // 
            this.cSN4.AutoSize = true;
            this.cSN4.Enabled = false;
            this.cSN4.Location = new System.Drawing.Point(259, 255);
            this.cSN4.Name = "cSN4";
            this.cSN4.Size = new System.Drawing.Size(28, 27);
            this.cSN4.TabIndex = 69;
            this.cSN4.UseVisualStyleBackColor = true;
            this.cSN4.CheckedChanged += new System.EventHandler(this.cSN4_CheckedChanged);
            // 
            // cSN5
            // 
            this.cSN5.AutoSize = true;
            this.cSN5.Enabled = false;
            this.cSN5.Location = new System.Drawing.Point(258, 309);
            this.cSN5.Name = "cSN5";
            this.cSN5.Size = new System.Drawing.Size(28, 27);
            this.cSN5.TabIndex = 70;
            this.cSN5.UseVisualStyleBackColor = true;
            this.cSN5.CheckedChanged += new System.EventHandler(this.cSN5_CheckedChanged);
            // 
            // cSN6
            // 
            this.cSN6.AutoSize = true;
            this.cSN6.Enabled = false;
            this.cSN6.Location = new System.Drawing.Point(257, 355);
            this.cSN6.Name = "cSN6";
            this.cSN6.Size = new System.Drawing.Size(28, 27);
            this.cSN6.TabIndex = 71;
            this.cSN6.UseVisualStyleBackColor = true;
            this.cSN6.CheckedChanged += new System.EventHandler(this.cSN6_CheckedChanged);
            // 
            // lblStatus2
            // 
            this.lblStatus2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus2.BackColor = System.Drawing.Color.Gray;
            this.lblStatus2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblStatus2.Font = new System.Drawing.Font("Times New Roman", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblStatus2.Location = new System.Drawing.Point(5, 183);
            this.lblStatus2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblStatus2.Name = "lblStatus2";
            this.lblStatus2.Size = new System.Drawing.Size(232, 48);
            this.lblStatus2.TabIndex = 84;
            this.lblStatus2.Text = "IDLE";
            this.lblStatus2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblStatus3
            // 
            this.lblStatus3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus3.BackColor = System.Drawing.Color.Gray;
            this.lblStatus3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblStatus3.Font = new System.Drawing.Font("Times New Roman", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblStatus3.Location = new System.Drawing.Point(5, 232);
            this.lblStatus3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblStatus3.Name = "lblStatus3";
            this.lblStatus3.Size = new System.Drawing.Size(232, 48);
            this.lblStatus3.TabIndex = 85;
            this.lblStatus3.Text = "IDLE";
            this.lblStatus3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblStatus4
            // 
            this.lblStatus4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus4.BackColor = System.Drawing.Color.Gray;
            this.lblStatus4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblStatus4.Font = new System.Drawing.Font("Times New Roman", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblStatus4.Location = new System.Drawing.Point(5, 281);
            this.lblStatus4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblStatus4.Name = "lblStatus4";
            this.lblStatus4.Size = new System.Drawing.Size(232, 48);
            this.lblStatus4.TabIndex = 86;
            this.lblStatus4.Text = "IDLE";
            this.lblStatus4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblStatus1
            // 
            this.lblStatus1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus1.BackColor = System.Drawing.Color.Gray;
            this.lblStatus1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblStatus1.Font = new System.Drawing.Font("Times New Roman", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblStatus1.Location = new System.Drawing.Point(5, 134);
            this.lblStatus1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblStatus1.Name = "lblStatus1";
            this.lblStatus1.Size = new System.Drawing.Size(232, 48);
            this.lblStatus1.TabIndex = 87;
            this.lblStatus1.Text = "IDLE";
            this.lblStatus1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblStatus5
            // 
            this.lblStatus5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus5.BackColor = System.Drawing.Color.Gray;
            this.lblStatus5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblStatus5.Font = new System.Drawing.Font("Times New Roman", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblStatus5.Location = new System.Drawing.Point(5, 329);
            this.lblStatus5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblStatus5.Name = "lblStatus5";
            this.lblStatus5.Size = new System.Drawing.Size(232, 48);
            this.lblStatus5.TabIndex = 88;
            this.lblStatus5.Text = "IDLE";
            this.lblStatus5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // timer4
            // 
            this.timer4.Tick += new System.EventHandler(this.timer4_Tick);
            // 
            // timer5
            // 
            this.timer5.Tick += new System.EventHandler(this.timer5_Tick);
            // 
            // timer6
            // 
            this.timer6.Tick += new System.EventHandler(this.timer6_Tick);
            // 
            // lbtesttime1
            // 
            this.lbtesttime1.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.lbtesttime1.Location = new System.Drawing.Point(239, 134);
            this.lbtesttime1.Name = "lbtesttime1";
            this.lbtesttime1.Size = new System.Drawing.Size(57, 29);
            this.lbtesttime1.TabIndex = 89;
            this.lbtesttime1.Text = "0000";
            this.lbtesttime1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbtesttime1.Visible = false;
            // 
            // lbtesttime2
            // 
            this.lbtesttime2.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.lbtesttime2.Location = new System.Drawing.Point(239, 184);
            this.lbtesttime2.Name = "lbtesttime2";
            this.lbtesttime2.Size = new System.Drawing.Size(57, 29);
            this.lbtesttime2.TabIndex = 90;
            this.lbtesttime2.Text = "0000";
            this.lbtesttime2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbtesttime2.Visible = false;
            // 
            // lbtesttime3
            // 
            this.lbtesttime3.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.lbtesttime3.Location = new System.Drawing.Point(239, 230);
            this.lbtesttime3.Name = "lbtesttime3";
            this.lbtesttime3.Size = new System.Drawing.Size(57, 29);
            this.lbtesttime3.TabIndex = 91;
            this.lbtesttime3.Text = "0000";
            this.lbtesttime3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbtesttime3.Visible = false;
            // 
            // lbtesttime4
            // 
            this.lbtesttime4.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.lbtesttime4.Location = new System.Drawing.Point(239, 279);
            this.lbtesttime4.Name = "lbtesttime4";
            this.lbtesttime4.Size = new System.Drawing.Size(57, 29);
            this.lbtesttime4.TabIndex = 92;
            this.lbtesttime4.Text = "0000";
            this.lbtesttime4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbtesttime4.Visible = false;
            // 
            // lbtesttime5
            // 
            this.lbtesttime5.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.lbtesttime5.Location = new System.Drawing.Point(239, 330);
            this.lbtesttime5.Name = "lbtesttime5";
            this.lbtesttime5.Size = new System.Drawing.Size(57, 29);
            this.lbtesttime5.TabIndex = 93;
            this.lbtesttime5.Text = "0000";
            this.lbtesttime5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbtesttime5.Visible = false;
            // 
            // frmTestState
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 700);
            this.CloseButton = false;
            this.CloseButtonVisible = false;
            this.ControlBox = false;
            this.Controls.Add(this.lbtesttime4);
            this.Controls.Add(this.lblStatus5);
            this.Controls.Add(this.lblStatus1);
            this.Controls.Add(this.lblStatus4);
            this.Controls.Add(this.lblStatus3);
            this.Controls.Add(this.lblStatus2);
            this.Controls.Add(this.cSN6);
            this.Controls.Add(this.cSN5);
            this.Controls.Add(this.cSN4);
            this.Controls.Add(this.cSN3);
            this.Controls.Add(this.cSN2);
            this.Controls.Add(this.cSN1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.textBoxStatue);
            this.Controls.Add(this.lblooptime);
            this.Controls.Add(this.linkLabelUser);
            this.Controls.Add(this.lbStationname);
            this.Controls.Add(this.bnUnitStop);
            this.Controls.Add(this.btnUnitStart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkboxloop);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblStatus0);
            this.Controls.Add(this.lbtesttime5);
            this.Controls.Add(this.lbtesttime);
            this.Controls.Add(this.lbtesttime3);
            this.Controls.Add(this.lbtesttime2);
            this.Controls.Add(this.lbtesttime1);
            this.DockAreas = WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight;
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.HelpButton = true;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmTestState";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockRight;
            this.Load += new System.EventHandler(this.frmTestState_Load);
            this.SizeChanged += new System.EventHandler(this.frmTestState_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStatus0;
        public System.Windows.Forms.TextBox txtFail;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkboxloop;
        private System.Windows.Forms.Timer testTime;
        private System.Windows.Forms.Label lbtesttime;
        private System.Windows.Forms.Timer timerLoopTest;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bnUnitStop;
        private System.Windows.Forms.Button btnUnitStart;
        private System.Windows.Forms.Label lbStationname;
        private System.Windows.Forms.LinkLabel linkLabelUser;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox textBoxFailRate;
        public System.Windows.Forms.TextBox textBoxPassRate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblooptime;
        private System.Windows.Forms.TextBox textBoxStatue;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.CheckBox cSN1;
        private System.Windows.Forms.CheckBox cSN2;
        private System.Windows.Forms.CheckBox cSN3;
        private System.Windows.Forms.CheckBox cSN4;
        private System.Windows.Forms.CheckBox cSN5;
        private System.Windows.Forms.CheckBox cSN6;
        private System.Windows.Forms.Label lblStatus2;
        private System.Windows.Forms.Label lblStatus3;
        private System.Windows.Forms.Label lblStatus4;
        private System.Windows.Forms.Label lblStatus1;
        private System.Windows.Forms.Label lblStatus5;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Timer timer4;
        private System.Windows.Forms.Timer timer5;
        private System.Windows.Forms.Timer timer6;
        private System.Windows.Forms.Label lbtesttime1;
        private System.Windows.Forms.Label lbtesttime2;
        private System.Windows.Forms.Label lbtesttime3;
        private System.Windows.Forms.Label lbtesttime4;
        private System.Windows.Forms.Label lbtesttime5;
    }
}