namespace Fixture
{
    partial class Fixture
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
            this.FixtureUp = new System.Windows.Forms.Button();
            this.FixtureDown = new System.Windows.Forms.Button();
            this.ComboxComlist = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.tbConfig = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Normal = new System.Windows.Forms.Button();
            this.Fault = new System.Windows.Forms.Button();
            this.Service = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FixtureUp
            // 
            this.FixtureUp.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.FixtureUp.Location = new System.Drawing.Point(113, 156);
            this.FixtureUp.Name = "FixtureUp";
            this.FixtureUp.Size = new System.Drawing.Size(75, 32);
            this.FixtureUp.TabIndex = 0;
            this.FixtureUp.Text = "UP";
            this.FixtureUp.UseVisualStyleBackColor = true;
            this.FixtureUp.Click += new System.EventHandler(this.FixtureUp_Click);
            // 
            // FixtureDown
            // 
            this.FixtureDown.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.FixtureDown.Location = new System.Drawing.Point(248, 156);
            this.FixtureDown.Name = "FixtureDown";
            this.FixtureDown.Size = new System.Drawing.Size(75, 32);
            this.FixtureDown.TabIndex = 1;
            this.FixtureDown.Text = "DOWN";
            this.FixtureDown.UseVisualStyleBackColor = true;
            this.FixtureDown.Click += new System.EventHandler(this.FixtureDown_Click);
            // 
            // ComboxComlist
            // 
            this.ComboxComlist.FormattingEnabled = true;
            this.ComboxComlist.Location = new System.Drawing.Point(131, 49);
            this.ComboxComlist.Name = "ComboxComlist";
            this.ComboxComlist.Size = new System.Drawing.Size(121, 20);
            this.ComboxComlist.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label1.Location = new System.Drawing.Point(26, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Com Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label2.Location = new System.Drawing.Point(26, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Setting";
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.button3.Location = new System.Drawing.Point(365, 42);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 32);
            this.button3.TabIndex = 5;
            this.button3.Text = "Rescan";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.button4.Location = new System.Drawing.Point(365, 82);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 32);
            this.button4.TabIndex = 6;
            this.button4.Text = "OK";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // tbConfig
            // 
            this.tbConfig.Location = new System.Drawing.Point(131, 83);
            this.tbConfig.Name = "tbConfig";
            this.tbConfig.Size = new System.Drawing.Size(121, 21);
            this.tbConfig.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(272, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "115200,N,8,1";
            // 
            // Normal
            // 
            this.Normal.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Normal.Image = global::Fixture.Properties.Resources.Green;
            this.Normal.Location = new System.Drawing.Point(59, 216);
            this.Normal.Name = "Normal";
            this.Normal.Size = new System.Drawing.Size(75, 42);
            this.Normal.TabIndex = 9;
            this.Normal.Text = "Normal";
            this.Normal.UseVisualStyleBackColor = true;
            this.Normal.Click += new System.EventHandler(this.Normal_Click);
            // 
            // Fault
            // 
            this.Fault.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Fault.Image = global::Fixture.Properties.Resources.Red;
            this.Fault.Location = new System.Drawing.Point(190, 216);
            this.Fault.Name = "Fault";
            this.Fault.Size = new System.Drawing.Size(75, 42);
            this.Fault.TabIndex = 10;
            this.Fault.Text = "FAULT";
            this.Fault.UseVisualStyleBackColor = true;
            this.Fault.Click += new System.EventHandler(this.Fault_Click);
            // 
            // Service
            // 
            this.Service.BackColor = System.Drawing.Color.Yellow;
            this.Service.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Service.Location = new System.Drawing.Point(312, 216);
            this.Service.Name = "Service";
            this.Service.Size = new System.Drawing.Size(86, 42);
            this.Service.TabIndex = 11;
            this.Service.Text = "On Service";
            this.Service.UseVisualStyleBackColor = false;
            this.Service.Click += new System.EventHandler(this.Service_Click);
            // 
            // Fixture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 310);
            this.Controls.Add(this.Service);
            this.Controls.Add(this.Fault);
            this.Controls.Add(this.Normal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbConfig);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ComboxComlist);
            this.Controls.Add(this.FixtureDown);
            this.Controls.Add(this.FixtureUp);
            this.Name = "Fixture";
            this.Text = "Fixture";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button FixtureUp;
        private System.Windows.Forms.Button FixtureDown;
        private System.Windows.Forms.ComboBox ComboxComlist;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox tbConfig;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Normal;
        private System.Windows.Forms.Button Fault;
        private System.Windows.Forms.Button Service;
    }
}