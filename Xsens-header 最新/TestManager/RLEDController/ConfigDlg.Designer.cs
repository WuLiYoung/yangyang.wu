namespace RLEDController
{
    partial class ConfigDlg
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
            this.btnRefresh = new System.Windows.Forms.Button();
            this.OK = new System.Windows.Forms.Button();
            this.ComboxComlist = new System.Windows.Forms.ComboBox();
            this.tbConfig = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCalibLeft = new System.Windows.Forms.Button();
            this.btnCalibRight = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.listboxlightdata = new System.Windows.Forms.ListBox();
            this.lbcalibtime = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.bnDel = new System.Windows.Forms.Button();
            this.bnAdd = new System.Windows.Forms.Button();
            this.bnOff = new System.Windows.Forms.Button();
            this.bnCycle = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.bnOn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRefresh.Location = new System.Drawing.Point(584, 21);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(131, 43);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "ReScan";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // OK
            // 
            this.OK.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.OK.Location = new System.Drawing.Point(584, 79);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(131, 43);
            this.OK.TabIndex = 1;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // ComboxComlist
            // 
            this.ComboxComlist.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ComboxComlist.FormattingEnabled = true;
            this.ComboxComlist.Location = new System.Drawing.Point(164, 24);
            this.ComboxComlist.Name = "ComboxComlist";
            this.ComboxComlist.Size = new System.Drawing.Size(359, 32);
            this.ComboxComlist.TabIndex = 2;
            // 
            // tbConfig
            // 
            this.tbConfig.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbConfig.Location = new System.Drawing.Point(164, 80);
            this.tbConfig.Name = "tbConfig";
            this.tbConfig.Size = new System.Drawing.Size(224, 31);
            this.tbConfig.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(48, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "Com Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(51, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "Config:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(404, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 24);
            this.label3.TabIndex = 6;
            this.label3.Text = "115200,n,8,1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.OK);
            this.groupBox1.Controls.Add(this.ComboxComlist);
            this.groupBox1.Controls.Add(this.tbConfig);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(13, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(761, 136);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Com";
            // 
            // btnCalibLeft
            // 
            this.btnCalibLeft.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCalibLeft.Location = new System.Drawing.Point(388, 30);
            this.btnCalibLeft.Name = "btnCalibLeft";
            this.btnCalibLeft.Size = new System.Drawing.Size(174, 56);
            this.btnCalibLeft.TabIndex = 11;
            this.btnCalibLeft.Text = "校准";
            this.btnCalibLeft.UseVisualStyleBackColor = true;
            this.btnCalibLeft.Click += new System.EventHandler(this.btnCalibLeft_Click);
            // 
            // btnCalibRight
            // 
            this.btnCalibRight.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCalibRight.Location = new System.Drawing.Point(568, 30);
            this.btnCalibRight.Name = "btnCalibRight";
            this.btnCalibRight.Size = new System.Drawing.Size(175, 56);
            this.btnCalibRight.TabIndex = 12;
            this.btnCalibRight.Text = "Calibration Right";
            this.btnCalibRight.UseVisualStyleBackColor = true;
            this.btnCalibRight.Visible = false;
            this.btnCalibRight.Click += new System.EventHandler(this.btnCalibRight_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.listboxlightdata);
            this.groupBox2.Controls.Add(this.lbcalibtime);
            this.groupBox2.Controls.Add(this.btnCalibLeft);
            this.groupBox2.Controls.Add(this.btnCalibRight);
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(13, 155);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(759, 342);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Calibration";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(26, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 24);
            this.label6.TabIndex = 16;
            this.label6.Text = "Last Calib Time:";
            // 
            // listboxlightdata
            // 
            this.listboxlightdata.FormattingEnabled = true;
            this.listboxlightdata.ItemHeight = 24;
            this.listboxlightdata.Location = new System.Drawing.Point(18, 103);
            this.listboxlightdata.Name = "listboxlightdata";
            this.listboxlightdata.Size = new System.Drawing.Size(724, 220);
            this.listboxlightdata.TabIndex = 18;
            // 
            // lbcalibtime
            // 
            this.lbcalibtime.AutoSize = true;
            this.lbcalibtime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbcalibtime.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbcalibtime.Location = new System.Drawing.Point(184, 47);
            this.lbcalibtime.Name = "lbcalibtime";
            this.lbcalibtime.Size = new System.Drawing.Size(94, 26);
            this.lbcalibtime.TabIndex = 14;
            this.lbcalibtime.Text = "1970/1/1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(577, 541);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 24);
            this.label5.TabIndex = 17;
            this.label5.Text = "25000";
            // 
            // bnDel
            // 
            this.bnDel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bnDel.Location = new System.Drawing.Point(658, 522);
            this.bnDel.Name = "bnDel";
            this.bnDel.Size = new System.Drawing.Size(87, 56);
            this.bnDel.TabIndex = 19;
            this.bnDel.Text = "-";
            this.bnDel.UseVisualStyleBackColor = true;
            this.bnDel.Click += new System.EventHandler(this.bnDel_Click);
            // 
            // bnAdd
            // 
            this.bnAdd.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bnAdd.Location = new System.Drawing.Point(477, 522);
            this.bnAdd.Name = "bnAdd";
            this.bnAdd.Size = new System.Drawing.Size(87, 56);
            this.bnAdd.TabIndex = 18;
            this.bnAdd.Text = "+";
            this.bnAdd.UseVisualStyleBackColor = true;
            this.bnAdd.Click += new System.EventHandler(this.bnAdd_Click);
            // 
            // bnOff
            // 
            this.bnOff.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bnOff.Location = new System.Drawing.Point(362, 522);
            this.bnOff.Name = "bnOff";
            this.bnOff.Size = new System.Drawing.Size(87, 56);
            this.bnOff.TabIndex = 18;
            this.bnOff.Text = "OFF";
            this.bnOff.UseVisualStyleBackColor = true;
            this.bnOff.Click += new System.EventHandler(this.bnOff_Click);
            // 
            // bnCycle
            // 
            this.bnCycle.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bnCycle.Location = new System.Drawing.Point(256, 598);
            this.bnCycle.Name = "bnCycle";
            this.bnCycle.Size = new System.Drawing.Size(202, 56);
            this.bnCycle.TabIndex = 19;
            this.bnCycle.Text = "Cycle";
            this.bnCycle.UseVisualStyleBackColor = true;
            this.bnCycle.Click += new System.EventHandler(this.bnCycle_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "led0",
            "led1",
            "led2",
            "led3",
            "led4",
            "led5",
            "led6",
            "led7",
            "led8",
            "led9",
            "led10",
            "led11",
            "led12",
            "led13",
            "led14",
            "led15",
            "led16",
            "led0"});
            this.comboBox1.Location = new System.Drawing.Point(19, 539);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(197, 26);
            this.comboBox1.TabIndex = 20;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // bnOn
            // 
            this.bnOn.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bnOn.Location = new System.Drawing.Point(256, 522);
            this.bnOn.Name = "bnOn";
            this.bnOn.Size = new System.Drawing.Size(87, 56);
            this.bnOn.TabIndex = 21;
            this.bnOn.Text = "ON";
            this.bnOn.UseVisualStyleBackColor = true;
            this.bnOn.Click += new System.EventHandler(this.bnOn_Click);
            // 
            // ConfigDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 666);
            this.Controls.Add(this.bnOn);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.bnCycle);
            this.Controls.Add(this.bnOff);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.bnDel);
            this.Controls.Add(this.bnAdd);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ConfigDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ALSC3-2 Config";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.ComboBox ComboxComlist;
        private System.Windows.Forms.TextBox tbConfig;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCalibLeft;
        private System.Windows.Forms.Button btnCalibRight;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bnDel;
        private System.Windows.Forms.Button bnAdd;
        private System.Windows.Forms.Button bnOff;
        private System.Windows.Forms.Label lbcalibtime;
        private System.Windows.Forms.ListBox listboxlightdata;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button bnCycle;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button bnOn;
    }
}