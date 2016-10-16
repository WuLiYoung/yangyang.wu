namespace UserInterface
{
    partial class TestUnit
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
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showLimitedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showUnitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showRemarkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lvTestItem = new ListViewNF();
            this.ItemIndex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.testName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lower = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.upper = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.itemtime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UUT1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UUT2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UUT3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UUT4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UUT5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UUT6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.remark = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lbscriptver = new System.Windows.Forms.Label();
            this.lbTestName = new System.Windows.Forms.Label();
            this.tbUnitSN = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.checkBoxNeedCode = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLimitedToolStripMenuItem,
            this.showUnitToolStripMenuItem,
            this.showRemarkToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(157, 70);
            // 
            // showLimitedToolStripMenuItem
            // 
            this.showLimitedToolStripMenuItem.Name = "showLimitedToolStripMenuItem";
            this.showLimitedToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.showLimitedToolStripMenuItem.Text = "Show Limited";
            // 
            // showUnitToolStripMenuItem
            // 
            this.showUnitToolStripMenuItem.Name = "showUnitToolStripMenuItem";
            this.showUnitToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.showUnitToolStripMenuItem.Text = "Show Unit";
            // 
            // showRemarkToolStripMenuItem
            // 
            this.showRemarkToolStripMenuItem.Name = "showRemarkToolStripMenuItem";
            this.showRemarkToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.showRemarkToolStripMenuItem.Text = "Show Remark";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 53);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1133, 594);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lvTestItem);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1125, 564);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Items";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lvTestItem
            // 
            this.lvTestItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ItemIndex,
            this.testName,
            this.lower,
            this.upper,
            this.itemtime,
            this.UUT1,
            this.UUT2,
            this.UUT3,
            this.UUT4,
            this.UUT5,
            this.UUT6,
            this.remark});
            this.lvTestItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvTestItem.FullRowSelect = true;
            this.lvTestItem.GridLines = true;
            this.lvTestItem.Location = new System.Drawing.Point(3, 3);
            this.lvTestItem.Margin = new System.Windows.Forms.Padding(5);
            this.lvTestItem.Name = "lvTestItem";
            this.lvTestItem.Size = new System.Drawing.Size(1119, 558);
            this.lvTestItem.TabIndex = 1;
            this.lvTestItem.UseCompatibleStateImageBehavior = false;
            this.lvTestItem.View = System.Windows.Forms.View.Details;
            this.lvTestItem.SelectedIndexChanged += new System.EventHandler(this.lvTestItem_SelectedIndexChanged);
            // 
            // ItemIndex
            // 
            this.ItemIndex.Text = "Index";
            // 
            // testName
            // 
            this.testName.Text = "ItemName";
            this.testName.Width = 150;
            // 
            // lower
            // 
            this.lower.Text = "lower";
            this.lower.Width = 120;
            // 
            // upper
            // 
            this.upper.Text = "upper";
            this.upper.Width = 120;
            // 
            // itemtime
            // 
            this.itemtime.Text = "time";
            this.itemtime.Width = 120;
            // 
            // UUT1
            // 
            this.UUT1.Text = "UUT1";
            // 
            // UUT2
            // 
            this.UUT2.Text = "UUT2";
            // 
            // UUT3
            // 
            this.UUT3.Text = "UUT3";
            // 
            // UUT4
            // 
            this.UUT4.Text = "UUT4";
            // 
            // UUT5
            // 
            this.UUT5.Text = "UUT5";
            // 
            // UUT6
            // 
            this.UUT6.Text = "UUT6";
            // 
            // remark
            // 
            this.remark.Text = "Remark";
            this.remark.Width = 150;
            // 
            // lbscriptver
            // 
            this.lbscriptver.AutoSize = true;
            this.lbscriptver.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lbscriptver.Location = new System.Drawing.Point(0, 32);
            this.lbscriptver.Name = "lbscriptver";
            this.lbscriptver.Size = new System.Drawing.Size(70, 17);
            this.lbscriptver.TabIndex = 40;
            this.lbscriptver.Text = "Script V1.0";
            // 
            // lbTestName
            // 
            this.lbTestName.AutoSize = true;
            this.lbTestName.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.lbTestName.ForeColor = System.Drawing.Color.Blue;
            this.lbTestName.Location = new System.Drawing.Point(-3, 3);
            this.lbTestName.Name = "lbTestName";
            this.lbTestName.Size = new System.Drawing.Size(182, 30);
            this.lbTestName.TabIndex = 38;
            this.lbTestName.Text = "Alsar Glass  Test";
            // 
            // tbUnitSN
            // 
            this.tbUnitSN.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.tbUnitSN.Location = new System.Drawing.Point(365, 6);
            this.tbUnitSN.Name = "tbUnitSN";
            this.tbUnitSN.Size = new System.Drawing.Size(415, 36);
            this.tbUnitSN.TabIndex = 5;
            this.tbUnitSN.TextChanged += new System.EventHandler(this.tbUnitSN_TextChanged);
            this.tbUnitSN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbUnitSN_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label1.Location = new System.Drawing.Point(308, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 21);
            this.label1.TabIndex = 6;
            this.label1.Text = "SN:";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 3000;
            // 
            // checkBoxNeedCode
            // 
            this.checkBoxNeedCode.AutoSize = true;
            this.checkBoxNeedCode.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.checkBoxNeedCode.Location = new System.Drawing.Point(786, 15);
            this.checkBoxNeedCode.Name = "checkBoxNeedCode";
            this.checkBoxNeedCode.Size = new System.Drawing.Size(130, 25);
            this.checkBoxNeedCode.TabIndex = 41;
            this.checkBoxNeedCode.Text = "ScanBarCode";
            this.checkBoxNeedCode.UseVisualStyleBackColor = true;
            this.checkBoxNeedCode.CheckedChanged += new System.EventHandler(this.checkBoxNeedCode_CheckedChanged);
            // 
            // TestUnit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1133, 647);
            this.CloseButton = false;
            this.CloseButtonVisible = false;
            this.Controls.Add(this.checkBoxNeedCode);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbUnitSN);
            this.Controls.Add(this.lbTestName);
            this.Controls.Add(this.lbscriptver);
            this.DockAreas = WeifenLuo.WinFormsUI.Docking.DockAreas.Document;
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "TestUnit";
            this.Text = "MK One FCT";
            this.Load += new System.EventHandler(this.TestUnit_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        //private System.Windows.Forms.ListView lvTestItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showLimitedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showUnitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showRemarkToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lbTestName;
        private System.Windows.Forms.TextBox tbUnitSN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbscriptver;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox checkBoxNeedCode;
        private ListViewNF lvTestItem;
        private System.Windows.Forms.ColumnHeader ItemIndex;
        private System.Windows.Forms.ColumnHeader testName;
        private System.Windows.Forms.ColumnHeader lower;
        private System.Windows.Forms.ColumnHeader upper;
        private System.Windows.Forms.ColumnHeader itemtime;
        private System.Windows.Forms.ColumnHeader remark;
        private System.Windows.Forms.ColumnHeader UUT1;
        private System.Windows.Forms.ColumnHeader UUT2;
        private System.Windows.Forms.ColumnHeader UUT3;
        private System.Windows.Forms.ColumnHeader UUT4;
        private System.Windows.Forms.ColumnHeader UUT5;
        private System.Windows.Forms.ColumnHeader UUT6;
    }
}