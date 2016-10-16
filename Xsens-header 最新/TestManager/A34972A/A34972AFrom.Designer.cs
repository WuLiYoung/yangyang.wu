namespace A34972A
{
    partial class A34972AFrom
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.RCmd = new System.Windows.Forms.Button();
            this.WCmd = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.CMD = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Lable2 = new System.Windows.Forms.Label();
            this.Connect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RCmd
            // 
            this.RCmd.Font = new System.Drawing.Font("微软雅黑", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RCmd.Location = new System.Drawing.Point(528, 187);
            this.RCmd.Name = "RCmd";
            this.RCmd.Size = new System.Drawing.Size(107, 51);
            this.RCmd.TabIndex = 0;
            this.RCmd.Text = "Read";
            this.RCmd.UseVisualStyleBackColor = true;
            this.RCmd.Click += new System.EventHandler(this.RCmd_Click);
            // 
            // WCmd
            // 
            this.WCmd.Font = new System.Drawing.Font("微软雅黑", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.WCmd.Location = new System.Drawing.Point(239, 187);
            this.WCmd.Name = "WCmd";
            this.WCmd.Size = new System.Drawing.Size(107, 51);
            this.WCmd.TabIndex = 1;
            this.WCmd.Text = "Write";
            this.WCmd.UseVisualStyleBackColor = true;
            this.WCmd.Click += new System.EventHandler(this.WCmd_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("微软雅黑", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(239, 54);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(396, 43);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.Text = "34972A";
            // 
            // CMD
            // 
            this.CMD.Font = new System.Drawing.Font("微软雅黑", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CMD.FormattingEnabled = true;
            this.CMD.Location = new System.Drawing.Point(239, 119);
            this.CMD.Name = "CMD";
            this.CMD.Size = new System.Drawing.Size(396, 43);
            this.CMD.TabIndex = 3;
            this.CMD.Text = "*IDN?";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 35);
            this.label1.TabIndex = 4;
            this.label1.Text = "Device：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(239, 254);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(396, 256);
            this.textBox1.TabIndex = 5;
            // 
            // Lable2
            // 
            this.Lable2.AutoSize = true;
            this.Lable2.Font = new System.Drawing.Font("微软雅黑", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Lable2.Location = new System.Drawing.Point(12, 119);
            this.Lable2.Name = "Lable2";
            this.Lable2.Size = new System.Drawing.Size(80, 35);
            this.Lable2.TabIndex = 6;
            this.Lable2.Text = "CMD";
            // 
            // Connect
            // 
            this.Connect.Font = new System.Drawing.Font("微软雅黑", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Connect.Location = new System.Drawing.Point(670, 54);
            this.Connect.Name = "Connect";
            this.Connect.Size = new System.Drawing.Size(172, 51);
            this.Connect.TabIndex = 7;
            this.Connect.Text = "ReConnect";
            this.Connect.UseVisualStyleBackColor = true;
            this.Connect.Click += new System.EventHandler(this.Connect_Click);
            // 
            // A34972AFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 522);
            this.Controls.Add(this.Connect);
            this.Controls.Add(this.Lable2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CMD);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.WCmd);
            this.Controls.Add(this.RCmd);
            this.Name = "A34972AFrom";
            this.Text = "34972A Debug";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RCmd;
        private System.Windows.Forms.Button WCmd;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox CMD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label Lable2;
        private System.Windows.Forms.Button Connect;
    }
}

