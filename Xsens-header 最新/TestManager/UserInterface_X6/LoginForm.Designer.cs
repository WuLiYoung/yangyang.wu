﻿namespace UserInterface
{
    partial class LoginForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxUser = new System.Windows.Forms.TextBox();
            this.btOK = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.textBoxPWD = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonexitlogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(24, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(28, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password:";
            // 
            // textBoxUser
            // 
            this.textBoxUser.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUser.ForeColor = System.Drawing.Color.Blue;
            this.textBoxUser.Location = new System.Drawing.Point(146, 40);
            this.textBoxUser.Name = "textBoxUser";
            this.textBoxUser.Size = new System.Drawing.Size(244, 32);
            this.textBoxUser.TabIndex = 2;
            this.textBoxUser.Text = "admin";
            // 
            // btOK
            // 
            this.btOK.Location = new System.Drawing.Point(46, 155);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(115, 33);
            this.btOK.TabIndex = 3;
            this.btOK.Text = "Login";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btCancel
            // 
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(291, 155);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(115, 33);
            this.btCancel.TabIndex = 4;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // textBoxPWD
            // 
            this.textBoxPWD.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPWD.ForeColor = System.Drawing.Color.Blue;
            this.textBoxPWD.Location = new System.Drawing.Point(146, 86);
            this.textBoxPWD.Name = "textBoxPWD";
            this.textBoxPWD.PasswordChar = '*';
            this.textBoxPWD.Size = new System.Drawing.Size(244, 32);
            this.textBoxPWD.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(0, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(441, 1);
            this.label3.TabIndex = 6;
            // 
            // buttonexitlogin
            // 
            this.buttonexitlogin.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonexitlogin.Location = new System.Drawing.Point(171, 155);
            this.buttonexitlogin.Name = "buttonexitlogin";
            this.buttonexitlogin.Size = new System.Drawing.Size(115, 33);
            this.buttonexitlogin.TabIndex = 7;
            this.buttonexitlogin.Text = "Logout";
            this.buttonexitlogin.UseVisualStyleBackColor = true;
            this.buttonexitlogin.Click += new System.EventHandler(this.buttonexitlogin_Click);
            // 
            // LoginForm
            // 
            this.AcceptButton = this.btOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(431, 200);
            this.Controls.Add(this.buttonexitlogin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxPWD);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.textBoxUser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxUser;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.TextBox textBoxPWD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonexitlogin;
    }
}