namespace DataPusher
{
    partial class ServerFrom
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
            this.btnSend = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.tbInput = new System.Windows.Forms.TextBox();
            this.lbconnectstate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.btnconfig = new System.Windows.Forms.Button();
            this.labelopen = new System.Windows.Forms.Label();
            this.BtnMacStart = new System.Windows.Forms.Button();
            this.btnMacStatue = new System.Windows.Forms.Button();
            this.lbMacStatue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(800, 384);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(136, 104);
            this.btnSend.TabIndex = 0;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(20, 8);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(916, 349);
            this.txtLog.TabIndex = 1;
            // 
            // tbInput
            // 
            this.tbInput.Location = new System.Drawing.Point(20, 385);
            this.tbInput.Multiline = true;
            this.tbInput.Name = "tbInput";
            this.tbInput.Size = new System.Drawing.Size(761, 104);
            this.tbInput.TabIndex = 2;
            // 
            // lbconnectstate
            // 
            this.lbconnectstate.AutoSize = true;
            this.lbconnectstate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lbconnectstate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbconnectstate.Location = new System.Drawing.Point(334, 526);
            this.lbconnectstate.Name = "lbconnectstate";
            this.lbconnectstate.Size = new System.Drawing.Size(153, 21);
            this.lbconnectstate.TabIndex = 3;
            this.lbconnectstate.Text = "No connect...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(597, 526);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Port:";
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(656, 523);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(119, 28);
            this.textBoxPort.TabIndex = 5;
            this.textBoxPort.Text = "10086";
            // 
            // btnconfig
            // 
            this.btnconfig.Location = new System.Drawing.Point(800, 514);
            this.btnconfig.Name = "btnconfig";
            this.btnconfig.Size = new System.Drawing.Size(136, 43);
            this.btnconfig.TabIndex = 6;
            this.btnconfig.Text = "Config";
            this.btnconfig.UseVisualStyleBackColor = true;
            this.btnconfig.Click += new System.EventHandler(this.btnconfig_Click);
            // 
            // labelopen
            // 
            this.labelopen.AutoSize = true;
            this.labelopen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelopen.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelopen.Location = new System.Drawing.Point(30, 525);
            this.labelopen.Name = "labelopen";
            this.labelopen.Size = new System.Drawing.Size(109, 21);
            this.labelopen.TabIndex = 7;
            this.labelopen.Text = "PORT OPEN";
            // 
            // BtnMacStart
            // 
            this.BtnMacStart.Location = new System.Drawing.Point(33, 561);
            this.BtnMacStart.Name = "BtnMacStart";
            this.BtnMacStart.Size = new System.Drawing.Size(122, 43);
            this.BtnMacStart.TabIndex = 8;
            this.BtnMacStart.Text = "Mac Start";
            this.BtnMacStart.UseVisualStyleBackColor = true;
            this.BtnMacStart.Click += new System.EventHandler(this.BtnMacStart_Click);
            // 
            // btnMacStatue
            // 
            this.btnMacStatue.Location = new System.Drawing.Point(337, 561);
            this.btnMacStatue.Name = "btnMacStatue";
            this.btnMacStatue.Size = new System.Drawing.Size(122, 43);
            this.btnMacStatue.TabIndex = 9;
            this.btnMacStatue.Text = "Mac Statue";
            this.btnMacStatue.UseVisualStyleBackColor = true;
            this.btnMacStatue.Click += new System.EventHandler(this.btnMacStatue_Click);
            // 
            // lbMacStatue
            // 
            this.lbMacStatue.AutoSize = true;
            this.lbMacStatue.Location = new System.Drawing.Point(597, 573);
            this.lbMacStatue.Name = "lbMacStatue";
            this.lbMacStatue.Size = new System.Drawing.Size(161, 18);
            this.lbMacStatue.TabIndex = 10;
            this.lbMacStatue.Text = "Mac No Connect...";
            // 
            // ServerFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 622);
            this.Controls.Add(this.lbMacStatue);
            this.Controls.Add(this.btnMacStatue);
            this.Controls.Add(this.BtnMacStart);
            this.Controls.Add(this.labelopen);
            this.Controls.Add(this.btnconfig);
            this.Controls.Add(this.textBoxPort);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbconnectstate);
            this.Controls.Add(this.tbInput);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.btnSend);
            this.Name = "ServerFrom";
            this.Text = "DataPush";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.TextBox tbInput;
        private System.Windows.Forms.Label lbconnectstate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.Button btnconfig;
        private System.Windows.Forms.Label labelopen;
        private System.Windows.Forms.Button BtnMacStart;
        private System.Windows.Forms.Button btnMacStatue;
        private System.Windows.Forms.Label lbMacStatue;
    }
}