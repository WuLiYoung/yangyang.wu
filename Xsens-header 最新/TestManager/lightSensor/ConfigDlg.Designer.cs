﻿namespace lightSensor
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
            this.bnGetValue = new System.Windows.Forms.Button();
            this.lbsensorvalue = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRefresh.Location = new System.Drawing.Point(528, 22);
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
            this.OK.Location = new System.Drawing.Point(528, 84);
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
            this.ComboxComlist.Location = new System.Drawing.Point(133, 33);
            this.ComboxComlist.Name = "ComboxComlist";
            this.ComboxComlist.Size = new System.Drawing.Size(359, 32);
            this.ComboxComlist.TabIndex = 2;
            // 
            // tbConfig
            // 
            this.tbConfig.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbConfig.Location = new System.Drawing.Point(133, 90);
            this.tbConfig.Name = "tbConfig";
            this.tbConfig.Size = new System.Drawing.Size(224, 31);
            this.tbConfig.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(17, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "Com Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(15, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "Config:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(363, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 24);
            this.label3.TabIndex = 6;
            this.label3.Text = "115200,n,8,1";
            // 
            // bnGetValue
            // 
            this.bnGetValue.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bnGetValue.Location = new System.Drawing.Point(462, 154);
            this.bnGetValue.Name = "bnGetValue";
            this.bnGetValue.Size = new System.Drawing.Size(197, 58);
            this.bnGetValue.TabIndex = 7;
            this.bnGetValue.Text = "Get Sensor Value";
            this.bnGetValue.UseVisualStyleBackColor = true;
            this.bnGetValue.Click += new System.EventHandler(this.bnGetValue_Click);
            // 
            // lbsensorvalue
            // 
            this.lbsensorvalue.AutoSize = true;
            this.lbsensorvalue.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.lbsensorvalue.Location = new System.Drawing.Point(144, 165);
            this.lbsensorvalue.Name = "lbsensorvalue";
            this.lbsensorvalue.Size = new System.Drawing.Size(75, 31);
            this.lbsensorvalue.TabIndex = 8;
            this.lbsensorvalue.Text = "value";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ConfigDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 234);
            this.Controls.Add(this.lbsensorvalue);
            this.Controls.Add(this.bnGetValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbConfig);
            this.Controls.Add(this.ComboxComlist);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.btnRefresh);
            this.Name = "ConfigDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sensor 1";
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
        private System.Windows.Forms.Button bnGetValue;
        private System.Windows.Forms.Label lbsensorvalue;
        private System.Windows.Forms.Timer timer1;
    }
}