﻿namespace UserInterface
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
            this.lbDueTime = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bnUnitStop = new System.Windows.Forms.Button();
            this.btnUnitStart = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbStationname = new System.Windows.Forms.Label();
            this.linkLabelUser = new System.Windows.Forms.LinkLabel();
            this.timerCalibtime = new System.Windows.Forms.Timer(this.components);
            this.lblooptime = new System.Windows.Forms.Label();
            this.textBoxlooptime = new System.Windows.Forms.TextBox();
            this.textBoxStatue = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // lblStatus0
            // 
            this.lblStatus0.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus0.BackColor = System.Drawing.Color.Cyan;
            this.lblStatus0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblStatus0.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus0.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblStatus0.Location = new System.Drawing.Point(1, 63);
            this.lblStatus0.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblStatus0.Name = "lblStatus0";
            this.lblStatus0.Size = new System.Drawing.Size(236, 85);
            this.lblStatus0.TabIndex = 2;
            this.lblStatus0.Text = "IDLE";
            this.lblStatus0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtFail
            // 
            this.txtFail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFail.BackColor = System.Drawing.Color.Red;
            this.txtFail.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txtFail.Location = new System.Drawing.Point(67, 91);
            this.txtFail.Margin = new System.Windows.Forms.Padding(5);
            this.txtFail.Name = "txtFail";
            this.txtFail.ReadOnly = true;
            this.txtFail.Size = new System.Drawing.Size(77, 29);
            this.txtFail.TabIndex = 31;
            this.txtFail.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.label13.Location = new System.Drawing.Point(8, 98);
            this.label13.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(37, 20);
            this.label13.TabIndex = 26;
            this.label13.Text = "Fail:";
            // 
            // txtPass
            // 
            this.txtPass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txtPass.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txtPass.Location = new System.Drawing.Point(67, 50);
            this.txtPass.Margin = new System.Windows.Forms.Padding(5);
            this.txtPass.Name = "txtPass";
            this.txtPass.ReadOnly = true;
            this.txtPass.Size = new System.Drawing.Size(77, 29);
            this.txtPass.TabIndex = 30;
            this.txtPass.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.label12.Location = new System.Drawing.Point(8, 54);
            this.label12.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 20);
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
            this.groupBox1.Location = new System.Drawing.Point(9, 347);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(228, 138);
            this.groupBox1.TabIndex = 49;
            this.groupBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label6.Location = new System.Drawing.Point(153, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 20);
            this.label6.TabIndex = 35;
            this.label6.Text = "Rate:";
            // 
            // textBoxFailRate
            // 
            this.textBoxFailRate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFailRate.BackColor = System.Drawing.Color.Red;
            this.textBoxFailRate.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.textBoxFailRate.Location = new System.Drawing.Point(148, 91);
            this.textBoxFailRate.Margin = new System.Windows.Forms.Padding(5);
            this.textBoxFailRate.Name = "textBoxFailRate";
            this.textBoxFailRate.ReadOnly = true;
            this.textBoxFailRate.Size = new System.Drawing.Size(77, 29);
            this.textBoxFailRate.TabIndex = 34;
            this.textBoxFailRate.Text = "0";
            // 
            // textBoxPassRate
            // 
            this.textBoxPassRate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPassRate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.textBoxPassRate.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.textBoxPassRate.Location = new System.Drawing.Point(148, 50);
            this.textBoxPassRate.Margin = new System.Windows.Forms.Padding(5);
            this.textBoxPassRate.Name = "textBoxPassRate";
            this.textBoxPassRate.ReadOnly = true;
            this.textBoxPassRate.Size = new System.Drawing.Size(77, 29);
            this.textBoxPassRate.TabIndex = 33;
            this.textBoxPassRate.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label5.Location = new System.Drawing.Point(62, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 20);
            this.label5.TabIndex = 32;
            this.label5.Text = "Test:";
            // 
            // checkboxloop
            // 
            this.checkboxloop.AutoSize = true;
            this.checkboxloop.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.checkboxloop.Location = new System.Drawing.Point(10, 290);
            this.checkboxloop.Name = "checkboxloop";
            this.checkboxloop.Size = new System.Drawing.Size(98, 24);
            this.checkboxloop.TabIndex = 50;
            this.checkboxloop.Text = "循环测试？";
            this.checkboxloop.UseVisualStyleBackColor = true;
            this.checkboxloop.CheckedChanged += new System.EventHandler(this.checkboxloop_CheckedChanged);
            // 
            // testTime
            // 
            this.testTime.Tick += new System.EventHandler(this.testTime_Tick);
            // 
            // lbtesttime
            // 
            this.lbtesttime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbtesttime.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.lbtesttime.Location = new System.Drawing.Point(77, 182);
            this.lbtesttime.Name = "lbtesttime";
            this.lbtesttime.Size = new System.Drawing.Size(151, 38);
            this.lbtesttime.TabIndex = 51;
            this.lbtesttime.Text = "0000S";
            this.lbtesttime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerLoopTest
            // 
            this.timerLoopTest.Enabled = true;
            this.timerLoopTest.Interval = 3000;
            this.timerLoopTest.Tick += new System.EventHandler(this.timerLoopTest_Tick);
            // 
            // lbDueTime
            // 
            this.lbDueTime.AutoSize = true;
            this.lbDueTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbDueTime.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbDueTime.Location = new System.Drawing.Point(27, 658);
            this.lbDueTime.Name = "lbDueTime";
            this.lbDueTime.Size = new System.Drawing.Size(135, 27);
            this.lbDueTime.TabIndex = 52;
            this.lbDueTime.Text = "00H:00M:00S";
            this.lbDueTime.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 17);
            this.label2.TabIndex = 53;
            // 
            // bnUnitStop
            // 
            this.bnUnitStop.Location = new System.Drawing.Point(122, 232);
            this.bnUnitStop.Name = "bnUnitStop";
            this.bnUnitStop.Size = new System.Drawing.Size(97, 44);
            this.bnUnitStop.TabIndex = 55;
            this.bnUnitStop.Text = "Stop(F6)";
            this.bnUnitStop.UseVisualStyleBackColor = true;
            this.bnUnitStop.Click += new System.EventHandler(this.bnUnitStop_Click);
            // 
            // btnUnitStart
            // 
            this.btnUnitStart.Location = new System.Drawing.Point(11, 232);
            this.btnUnitStart.Name = "btnUnitStart";
            this.btnUnitStart.Size = new System.Drawing.Size(97, 44);
            this.btnUnitStart.TabIndex = 54;
            this.btnUnitStart.Text = "Start(F5)";
            this.btnUnitStart.UseVisualStyleBackColor = true;
            this.btnUnitStart.Click += new System.EventHandler(this.btnUnitStart_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label3.Location = new System.Drawing.Point(8, 629);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 20);
            this.label3.TabIndex = 56;
            this.label3.Text = "校准倒数时间:";
            this.label3.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label4.Location = new System.Drawing.Point(8, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 20);
            this.label4.TabIndex = 57;
            this.label4.Text = "测试时间:";
            // 
            // lbStationname
            // 
            this.lbStationname.AutoSize = true;
            this.lbStationname.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.lbStationname.Location = new System.Drawing.Point(2, 579);
            this.lbStationname.Name = "lbStationname";
            this.lbStationname.Size = new System.Drawing.Size(217, 21);
            this.lbStationname.TabIndex = 60;
            this.lbStationname.Text = "Station:JR3_Glass_Alsar_001";
            // 
            // linkLabelUser
            // 
            this.linkLabelUser.AutoSize = true;
            this.linkLabelUser.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.linkLabelUser.Location = new System.Drawing.Point(4, 606);
            this.linkLabelUser.Name = "linkLabelUser";
            this.linkLabelUser.Size = new System.Drawing.Size(58, 21);
            this.linkLabelUser.TabIndex = 61;
            this.linkLabelUser.TabStop = true;
            this.linkLabelUser.Text = "admin";
            this.linkLabelUser.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelUser_LinkClicked);
            // 
            // timerCalibtime
            // 
            this.timerCalibtime.Interval = 1000;
            this.timerCalibtime.Tick += new System.EventHandler(this.timerCalibtime_Tick);
            // 
            // lblooptime
            // 
            this.lblooptime.AutoSize = true;
            this.lblooptime.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblooptime.Location = new System.Drawing.Point(9, 326);
            this.lblooptime.Name = "lblooptime";
            this.lblooptime.Size = new System.Drawing.Size(101, 20);
            this.lblooptime.TabIndex = 62;
            this.lblooptime.Text = "已循环次数：0";
            // 
            // textBoxlooptime
            // 
            this.textBoxlooptime.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.textBoxlooptime.Location = new System.Drawing.Point(137, 290);
            this.textBoxlooptime.Name = "textBoxlooptime";
            this.textBoxlooptime.Size = new System.Drawing.Size(100, 25);
            this.textBoxlooptime.TabIndex = 63;
            this.textBoxlooptime.Visible = false;
            this.textBoxlooptime.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxlooptime_KeyUp);
            // 
            // textBoxStatue
            // 
            this.textBoxStatue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxStatue.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.textBoxStatue.ForeColor = System.Drawing.Color.Red;
            this.textBoxStatue.Location = new System.Drawing.Point(1, 491);
            this.textBoxStatue.Multiline = true;
            this.textBoxStatue.Name = "textBoxStatue";
            this.textBoxStatue.Size = new System.Drawing.Size(236, 85);
            this.textBoxStatue.TabIndex = 64;
            this.textBoxStatue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(187, 292);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 65;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // frmTestState
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 700);
            this.CloseButton = false;
            this.CloseButtonVisible = false;
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.textBoxStatue);
            this.Controls.Add(this.textBoxlooptime);
            this.Controls.Add(this.lblooptime);
            this.Controls.Add(this.linkLabelUser);
            this.Controls.Add(this.lbStationname);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.bnUnitStop);
            this.Controls.Add(this.btnUnitStart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbDueTime);
            this.Controls.Add(this.lbtesttime);
            this.Controls.Add(this.checkboxloop);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblStatus0);
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
        private System.Windows.Forms.TextBox txtFail;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkboxloop;
        private System.Windows.Forms.Timer testTime;
        private System.Windows.Forms.Label lbtesttime;
        private System.Windows.Forms.Timer timerLoopTest;
        private System.Windows.Forms.Label lbDueTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bnUnitStop;
        private System.Windows.Forms.Button btnUnitStart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbStationname;
        private System.Windows.Forms.LinkLabel linkLabelUser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxFailRate;
        private System.Windows.Forms.TextBox textBoxPassRate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Timer timerCalibtime;
        private System.Windows.Forms.Label lblooptime;
        private System.Windows.Forms.TextBox textBoxlooptime;
        private System.Windows.Forms.TextBox textBoxStatue;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}