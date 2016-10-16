namespace EEBroadController
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
            this.btnRefresh = new System.Windows.Forms.Button();
            this.OK = new System.Windows.Forms.Button();
            this.ComboxComlist = new System.Windows.Forms.ComboBox();
            this.tbConfig = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Send = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.Clear = new System.Windows.Forms.Button();
            this.bnreset = new System.Windows.Forms.Button();
            this.bnwork = new System.Windows.Forms.Button();
            this.tbEEStatue = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRefresh.Location = new System.Drawing.Point(737, 36);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(175, 57);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "ReScan";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // OK
            // 
            this.OK.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.OK.Location = new System.Drawing.Point(737, 120);
            this.OK.Margin = new System.Windows.Forms.Padding(4);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(175, 57);
            this.OK.TabIndex = 1;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // ComboxComlist
            // 
            this.ComboxComlist.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ComboxComlist.FormattingEnabled = true;
            this.ComboxComlist.Location = new System.Drawing.Point(177, 44);
            this.ComboxComlist.Margin = new System.Windows.Forms.Padding(4);
            this.ComboxComlist.Name = "ComboxComlist";
            this.ComboxComlist.Size = new System.Drawing.Size(477, 39);
            this.ComboxComlist.TabIndex = 2;
            this.ComboxComlist.SelectedIndexChanged += new System.EventHandler(this.ComboxComlist_SelectedIndexChanged);
            // 
            // tbConfig
            // 
            this.tbConfig.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbConfig.Location = new System.Drawing.Point(177, 120);
            this.tbConfig.Margin = new System.Windows.Forms.Padding(4);
            this.tbConfig.Name = "tbConfig";
            this.tbConfig.Size = new System.Drawing.Size(297, 39);
            this.tbConfig.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(23, 44);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 31);
            this.label1.TabIndex = 4;
            this.label1.Text = "Com Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(20, 128);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 31);
            this.label2.TabIndex = 5;
            this.label2.Text = "Config:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(484, 128);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 31);
            this.label3.TabIndex = 6;
            this.label3.Text = "115200,n,8,1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Send);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.Clear);
            this.groupBox1.Controls.Add(this.bnreset);
            this.groupBox1.Controls.Add(this.bnwork);
            this.groupBox1.Controls.Add(this.tbEEStatue);
            this.groupBox1.Location = new System.Drawing.Point(16, 185);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(896, 428);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ctrl";
            // 
            // Send
            // 
            this.Send.Location = new System.Drawing.Point(679, 349);
            this.Send.Name = "Send";
            this.Send.Size = new System.Drawing.Size(121, 50);
            this.Send.TabIndex = 37;
            this.Send.Text = "Send";
            this.Send.UseVisualStyleBackColor = true;
            this.Send.Click += new System.EventHandler(this.Send_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "MAN_POSITIVE_ON",
            "MAN_POSITIVE_OFF",
            "POSITIVE_A_ON",
            "POSITIVE_A_OFF",
            "POSITIVE_B_ON",
            "POSITIVE_B_OFF",
            "NEGATIVE_A_ON",
            "NEGATIVE_A_OFF",
            "NEGATIVE_B_ON",
            "NEGATIVE_B_OFF",
            "VACUUM_ON",
            "VACUUM_OFF",
            "HOLD_OUT_A_ON",
            "HOLD_OUT_A_OFF",
            "HOLD_IN_A_ON",
            "HOLD_IN_A_OFF",
            "HOLD_OUT_B_ON",
            "HOLD_OUT_B_OFF",
            "HOLD_IN_B_ON",
            "HOLD_IN_B_OFF",
            "UP_A_ON",
            "UP_A_OFF",
            "DOWN_A_ON",
            "DOWN_A_OFF",
            "UP_B_ON",
            "UP_B_OFF",
            "DOWN_B_ON",
            "DOWN_B_OFF",
            "SEN_UP_A",
            "SEN_DOWN_A",
            "SEN_UP_B",
            "SEN_DOWN_B",
            "SEN_HOLD_OUT_A_OPEN",
            "SEN_HOLD_IN_A_OPEN",
            "HOLD_OUT_B_ON",
            "HOLD_IN_B_ON",
            "RASTER_A",
            "RASTER_B "});
            this.comboBox1.Location = new System.Drawing.Point(13, 358);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(645, 41);
            this.comboBox1.TabIndex = 25;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Clear
            // 
            this.Clear.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Clear.Location = new System.Drawing.Point(757, 223);
            this.Clear.Margin = new System.Windows.Forms.Padding(4);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(124, 72);
            this.Clear.TabIndex = 36;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // bnreset
            // 
            this.bnreset.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bnreset.Location = new System.Drawing.Point(757, 129);
            this.bnreset.Margin = new System.Windows.Forms.Padding(4);
            this.bnreset.Name = "bnreset";
            this.bnreset.Size = new System.Drawing.Size(124, 72);
            this.bnreset.TabIndex = 15;
            this.bnreset.Text = "Reset";
            this.bnreset.UseVisualStyleBackColor = true;
            this.bnreset.Click += new System.EventHandler(this.bnreset_Click);
            // 
            // bnwork
            // 
            this.bnwork.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bnwork.Location = new System.Drawing.Point(757, 35);
            this.bnwork.Margin = new System.Windows.Forms.Padding(4);
            this.bnwork.Name = "bnwork";
            this.bnwork.Size = new System.Drawing.Size(124, 72);
            this.bnwork.TabIndex = 14;
            this.bnwork.Text = "Work";
            this.bnwork.UseVisualStyleBackColor = true;
            this.bnwork.Click += new System.EventHandler(this.bnwork_Click);
            // 
            // tbEEStatue
            // 
            this.tbEEStatue.Location = new System.Drawing.Point(13, 27);
            this.tbEEStatue.Margin = new System.Windows.Forms.Padding(4);
            this.tbEEStatue.Multiline = true;
            this.tbEEStatue.Name = "tbEEStatue";
            this.tbEEStatue.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbEEStatue.Size = new System.Drawing.Size(730, 279);
            this.tbEEStatue.TabIndex = 13;
            // 
            // ConfigDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 629);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbConfig);
            this.Controls.Add(this.ComboxComlist);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.btnRefresh);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ConfigDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EEController Config";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.TextBox tbEEStatue;
        private System.Windows.Forms.Button bnreset;
        private System.Windows.Forms.Button bnwork;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button Send;
    }
}