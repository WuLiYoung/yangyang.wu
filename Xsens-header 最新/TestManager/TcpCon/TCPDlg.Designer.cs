namespace TcpCon
{
    partial class TCPDlg
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
            this.button_connect = new System.Windows.Forms.Button();
            this.textBox_IP = new System.Windows.Forms.TextBox();
            this.textBox_Port = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_Num = new System.Windows.Forms.ComboBox();
            this.comboBox_FunNum = new System.Windows.Forms.ComboBox();
            this.comboBox_Axis = new System.Windows.Forms.ComboBox();
            this.textBox_Loc = new System.Windows.Forms.TextBox();
            this.textBox_Spe = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button_Send = new System.Windows.Forms.Button();
            this.Message = new System.Windows.Forms.TextBox();
            this.OK = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_Spe1 = new System.Windows.Forms.TextBox();
            this.textBox_Loc1 = new System.Windows.Forms.TextBox();
            this.comboBox_Axis1 = new System.Windows.Forms.ComboBox();
            this.comboBox_FunNum1 = new System.Windows.Forms.ComboBox();
            this.comboBox_Num1 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox_Spe2 = new System.Windows.Forms.TextBox();
            this.textBox_Loc2 = new System.Windows.Forms.TextBox();
            this.comboBox_Axis2 = new System.Windows.Forms.ComboBox();
            this.comboBox_FunNum2 = new System.Windows.Forms.ComboBox();
            this.comboBox_Num2 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.INIT = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button8 = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.stepBox = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.button9 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button10 = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.button11 = new System.Windows.Forms.Button();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.button12 = new System.Windows.Forms.Button();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.button13 = new System.Windows.Forms.Button();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.labelRawData = new System.Windows.Forms.Label();
            this.labelRawData1 = new System.Windows.Forms.Label();
            this.labelRawData2 = new System.Windows.Forms.Label();
            this.labelRawData3 = new System.Windows.Forms.Label();
            this.labelRawData4 = new System.Windows.Forms.Label();
            this.button14 = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            this.timer5 = new System.Windows.Forms.Timer(this.components);
            this.timer6 = new System.Windows.Forms.Timer(this.components);
            this.timer7 = new System.Windows.Forms.Timer(this.components);
            this.Button_Record = new System.Windows.Forms.Button();
            this.button_Stop = new System.Windows.Forms.Button();
            this.button_LoadCsv = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_connect
            // 
            this.button_connect.Location = new System.Drawing.Point(614, 84);
            this.button_connect.Margin = new System.Windows.Forms.Padding(4);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(152, 56);
            this.button_connect.TabIndex = 0;
            this.button_connect.Text = "Connect";
            this.button_connect.UseVisualStyleBackColor = true;
            this.button_connect.Click += new System.EventHandler(this.button_connect_Click);
            // 
            // textBox_IP
            // 
            this.textBox_IP.Enabled = false;
            this.textBox_IP.Location = new System.Drawing.Point(84, 98);
            this.textBox_IP.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_IP.Name = "textBox_IP";
            this.textBox_IP.Size = new System.Drawing.Size(238, 35);
            this.textBox_IP.TabIndex = 1;
            this.textBox_IP.Text = "169.254.01.01";
            // 
            // textBox_Port
            // 
            this.textBox_Port.Enabled = false;
            this.textBox_Port.Location = new System.Drawing.Point(444, 98);
            this.textBox_Port.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_Port.Name = "textBox_Port";
            this.textBox_Port.Size = new System.Drawing.Size(136, 35);
            this.textBox_Port.TabIndex = 2;
            this.textBox_Port.Text = "5000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 100);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "IP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(356, 100);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "Port:";
            // 
            // comboBox_Num
            // 
            this.comboBox_Num.FormattingEnabled = true;
            this.comboBox_Num.Items.AddRange(new object[] {
            "01",
            "02",
            "03"});
            this.comboBox_Num.Location = new System.Drawing.Point(264, 270);
            this.comboBox_Num.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_Num.Name = "comboBox_Num";
            this.comboBox_Num.Size = new System.Drawing.Size(120, 32);
            this.comboBox_Num.TabIndex = 5;
            this.comboBox_Num.Text = "01";
            // 
            // comboBox_FunNum
            // 
            this.comboBox_FunNum.FormattingEnabled = true;
            this.comboBox_FunNum.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59",
            "60",
            "61",
            "62",
            "63",
            "64",
            "65",
            "66",
            "67",
            "68",
            "69",
            "70",
            "71",
            "72",
            "73",
            "74",
            "75",
            "76",
            "77",
            "78",
            "79",
            "80",
            "81",
            "82",
            "83",
            "84",
            "85",
            "86",
            "87",
            "88",
            "89",
            "90",
            "91",
            "92",
            "93",
            "94",
            "95",
            "96",
            "97",
            "98",
            "99"});
            this.comboBox_FunNum.Location = new System.Drawing.Point(440, 270);
            this.comboBox_FunNum.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_FunNum.Name = "comboBox_FunNum";
            this.comboBox_FunNum.Size = new System.Drawing.Size(120, 32);
            this.comboBox_FunNum.TabIndex = 6;
            this.comboBox_FunNum.Text = "01";
            // 
            // comboBox_Axis
            // 
            this.comboBox_Axis.FormattingEnabled = true;
            this.comboBox_Axis.Items.AddRange(new object[] {
            "A"});
            this.comboBox_Axis.Location = new System.Drawing.Point(94, 270);
            this.comboBox_Axis.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_Axis.Name = "comboBox_Axis";
            this.comboBox_Axis.Size = new System.Drawing.Size(120, 32);
            this.comboBox_Axis.TabIndex = 7;
            this.comboBox_Axis.Text = "A";
            // 
            // textBox_Loc
            // 
            this.textBox_Loc.Location = new System.Drawing.Point(610, 268);
            this.textBox_Loc.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_Loc.Name = "textBox_Loc";
            this.textBox_Loc.Size = new System.Drawing.Size(136, 35);
            this.textBox_Loc.TabIndex = 8;
            this.textBox_Loc.Text = "0";
            // 
            // textBox_Spe
            // 
            this.textBox_Spe.Location = new System.Drawing.Point(780, 268);
            this.textBox_Spe.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_Spe.Name = "textBox_Spe";
            this.textBox_Spe.Size = new System.Drawing.Size(136, 35);
            this.textBox_Spe.TabIndex = 9;
            this.textBox_Spe.Text = "50";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 276);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 24);
            this.label3.TabIndex = 10;
            this.label3.Text = "CMD1:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(270, 208);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 24);
            this.label4.TabIndex = 11;
            this.label4.Text = "Axis";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(320, 208);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 24);
            this.label5.TabIndex = 12;
            this.label5.Text = "Num";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(442, 208);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 24);
            this.label6.TabIndex = 13;
            this.label6.Text = "Function";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(608, 208);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 24);
            this.label7.TabIndex = 14;
            this.label7.Text = "Location";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(790, 208);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 24);
            this.label8.TabIndex = 15;
            this.label8.Text = "Speed";
            // 
            // button_Send
            // 
            this.button_Send.Location = new System.Drawing.Point(966, 258);
            this.button_Send.Margin = new System.Windows.Forms.Padding(4);
            this.button_Send.Name = "button_Send";
            this.button_Send.Size = new System.Drawing.Size(152, 56);
            this.button_Send.TabIndex = 16;
            this.button_Send.Text = "Send";
            this.button_Send.UseVisualStyleBackColor = true;
            this.button_Send.Click += new System.EventHandler(this.button_Send_Click);
            // 
            // Message
            // 
            this.Message.Location = new System.Drawing.Point(94, 628);
            this.Message.Margin = new System.Windows.Forms.Padding(4);
            this.Message.Multiline = true;
            this.Message.Name = "Message";
            this.Message.Size = new System.Drawing.Size(822, 216);
            this.Message.TabIndex = 17;
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(820, 84);
            this.OK.Margin = new System.Windows.Forms.Padding(4);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(152, 56);
            this.OK.TabIndex = 18;
            this.OK.Text = "DisConnect";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(966, 368);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(152, 56);
            this.button1.TabIndex = 25;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 386);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 24);
            this.label9.TabIndex = 24;
            this.label9.Text = "CMD2:";
            // 
            // textBox_Spe1
            // 
            this.textBox_Spe1.Location = new System.Drawing.Point(780, 378);
            this.textBox_Spe1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_Spe1.Name = "textBox_Spe1";
            this.textBox_Spe1.Size = new System.Drawing.Size(136, 35);
            this.textBox_Spe1.TabIndex = 23;
            this.textBox_Spe1.Text = "50";
            // 
            // textBox_Loc1
            // 
            this.textBox_Loc1.Location = new System.Drawing.Point(610, 378);
            this.textBox_Loc1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_Loc1.Name = "textBox_Loc1";
            this.textBox_Loc1.Size = new System.Drawing.Size(136, 35);
            this.textBox_Loc1.TabIndex = 22;
            this.textBox_Loc1.Text = "0";
            // 
            // comboBox_Axis1
            // 
            this.comboBox_Axis1.FormattingEnabled = true;
            this.comboBox_Axis1.Items.AddRange(new object[] {
            "A"});
            this.comboBox_Axis1.Location = new System.Drawing.Point(94, 380);
            this.comboBox_Axis1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_Axis1.Name = "comboBox_Axis1";
            this.comboBox_Axis1.Size = new System.Drawing.Size(120, 32);
            this.comboBox_Axis1.TabIndex = 21;
            this.comboBox_Axis1.Text = "A";
            // 
            // comboBox_FunNum1
            // 
            this.comboBox_FunNum1.FormattingEnabled = true;
            this.comboBox_FunNum1.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59",
            "60",
            "61",
            "62",
            "63",
            "64",
            "65",
            "66",
            "67",
            "68",
            "69",
            "70",
            "71",
            "72",
            "73",
            "74",
            "75",
            "76",
            "77",
            "78",
            "79",
            "80",
            "81",
            "82",
            "83",
            "84",
            "85",
            "86",
            "87",
            "88",
            "89",
            "90",
            "91",
            "92",
            "93",
            "94",
            "95",
            "96",
            "97",
            "98",
            "99"});
            this.comboBox_FunNum1.Location = new System.Drawing.Point(440, 380);
            this.comboBox_FunNum1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_FunNum1.Name = "comboBox_FunNum1";
            this.comboBox_FunNum1.Size = new System.Drawing.Size(120, 32);
            this.comboBox_FunNum1.TabIndex = 20;
            this.comboBox_FunNum1.Text = "01";
            // 
            // comboBox_Num1
            // 
            this.comboBox_Num1.FormattingEnabled = true;
            this.comboBox_Num1.Items.AddRange(new object[] {
            "01",
            "02",
            "03"});
            this.comboBox_Num1.Location = new System.Drawing.Point(264, 380);
            this.comboBox_Num1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_Num1.Name = "comboBox_Num1";
            this.comboBox_Num1.Size = new System.Drawing.Size(120, 32);
            this.comboBox_Num1.TabIndex = 19;
            this.comboBox_Num1.Text = "02";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(966, 472);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(152, 56);
            this.button2.TabIndex = 32;
            this.button2.Text = "Send";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 490);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 24);
            this.label10.TabIndex = 31;
            this.label10.Text = "CMD3:";
            // 
            // textBox_Spe2
            // 
            this.textBox_Spe2.Location = new System.Drawing.Point(780, 482);
            this.textBox_Spe2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_Spe2.Name = "textBox_Spe2";
            this.textBox_Spe2.Size = new System.Drawing.Size(136, 35);
            this.textBox_Spe2.TabIndex = 30;
            this.textBox_Spe2.Text = "50";
            // 
            // textBox_Loc2
            // 
            this.textBox_Loc2.Location = new System.Drawing.Point(610, 482);
            this.textBox_Loc2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_Loc2.Name = "textBox_Loc2";
            this.textBox_Loc2.Size = new System.Drawing.Size(136, 35);
            this.textBox_Loc2.TabIndex = 29;
            this.textBox_Loc2.Text = "0";
            // 
            // comboBox_Axis2
            // 
            this.comboBox_Axis2.FormattingEnabled = true;
            this.comboBox_Axis2.Items.AddRange(new object[] {
            "A"});
            this.comboBox_Axis2.Location = new System.Drawing.Point(94, 484);
            this.comboBox_Axis2.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_Axis2.Name = "comboBox_Axis2";
            this.comboBox_Axis2.Size = new System.Drawing.Size(120, 32);
            this.comboBox_Axis2.TabIndex = 28;
            this.comboBox_Axis2.Text = "A";
            // 
            // comboBox_FunNum2
            // 
            this.comboBox_FunNum2.FormattingEnabled = true;
            this.comboBox_FunNum2.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59",
            "60",
            "61",
            "62",
            "63",
            "64",
            "65",
            "66",
            "67",
            "68",
            "69",
            "70",
            "71",
            "72",
            "73",
            "74",
            "75",
            "76",
            "77",
            "78",
            "79",
            "80",
            "81",
            "82",
            "83",
            "84",
            "85",
            "86",
            "87",
            "88",
            "89",
            "90",
            "91",
            "92",
            "93",
            "94",
            "95",
            "96",
            "97",
            "98",
            "99"});
            this.comboBox_FunNum2.Location = new System.Drawing.Point(440, 484);
            this.comboBox_FunNum2.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_FunNum2.Name = "comboBox_FunNum2";
            this.comboBox_FunNum2.Size = new System.Drawing.Size(120, 32);
            this.comboBox_FunNum2.TabIndex = 27;
            this.comboBox_FunNum2.Text = "01";
            // 
            // comboBox_Num2
            // 
            this.comboBox_Num2.FormattingEnabled = true;
            this.comboBox_Num2.Items.AddRange(new object[] {
            "01",
            "02",
            "03"});
            this.comboBox_Num2.Location = new System.Drawing.Point(264, 484);
            this.comboBox_Num2.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_Num2.Name = "comboBox_Num2";
            this.comboBox_Num2.Size = new System.Drawing.Size(120, 32);
            this.comboBox_Num2.TabIndex = 26;
            this.comboBox_Num2.Text = "03";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(94, 876);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(822, 16);
            this.textBox1.TabIndex = 34;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(1192, 694);
            this.button5.Margin = new System.Windows.Forms.Padding(6);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(150, 46);
            this.button5.TabIndex = 36;
            this.button5.Text = "开始";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(1192, 790);
            this.button6.Margin = new System.Windows.Forms.Padding(6);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(150, 46);
            this.button6.TabIndex = 37;
            this.button6.Text = "停止";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(1040, 742);
            this.label11.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(118, 48);
            this.label11.TabIndex = 38;
            this.label11.Text = "老化";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1028, 84);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(152, 56);
            this.button4.TabIndex = 39;
            this.button4.Text = "Assignment";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // INIT
            // 
            this.INIT.Location = new System.Drawing.Point(1216, 84);
            this.INIT.Margin = new System.Windows.Forms.Padding(4);
            this.INIT.Name = "INIT";
            this.INIT.Size = new System.Drawing.Size(152, 56);
            this.INIT.TabIndex = 40;
            this.INIT.Text = "Value";
            this.INIT.UseVisualStyleBackColor = true;
            this.INIT.Click += new System.EventHandler(this.INIT_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(990, 208);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(82, 24);
            this.label12.TabIndex = 44;
            this.label12.Text = "Senxda";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(1406, 256);
            this.button7.Margin = new System.Windows.Forms.Padding(4);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(152, 56);
            this.button7.TabIndex = 46;
            this.button7.Text = "SendAllCMD";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(1420, 208);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(94, 24);
            this.label14.TabIndex = 47;
            this.label14.Text = "Machine";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(612, 448);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(6);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(28, 27);
            this.checkBox1.TabIndex = 48;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(1190, 256);
            this.button8.Margin = new System.Windows.Forms.Padding(4);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(152, 56);
            this.button8.TabIndex = 49;
            this.button8.Text = "零点";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(20, 566);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(58, 24);
            this.label13.TabIndex = 50;
            this.label13.Text = "Step";
            // 
            // stepBox
            // 
            this.stepBox.Location = new System.Drawing.Point(88, 560);
            this.stepBox.Margin = new System.Windows.Forms.Padding(4);
            this.stepBox.Name = "stepBox";
            this.stepBox.Size = new System.Drawing.Size(136, 35);
            this.stepBox.TabIndex = 51;
            this.stepBox.Text = "90.0";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(258, 560);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(130, 46);
            this.button3.TabIndex = 52;
            this.button3.Text = "Start";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label15.Location = new System.Drawing.Point(30, 1037);
            this.label15.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(123, 182);
            this.label15.TabIndex = 53;
            this.label15.Text = "俯仰角 ：\r\n\r\n横滚角 ：\r\n\r\n航向角 ：\r\n\r\n";
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(336, 957);
            this.button9.Margin = new System.Windows.Forms.Padding(6);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(76, 38);
            this.button9.TabIndex = 55;
            this.button9.Text = "open";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(200, 959);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(120, 32);
            this.comboBox1.TabIndex = 54;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(614, 957);
            this.button10.Margin = new System.Windows.Forms.Padding(6);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(76, 38);
            this.button10.TabIndex = 57;
            this.button10.Text = "open";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(478, 959);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(120, 32);
            this.comboBox2.TabIndex = 56;
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(876, 957);
            this.button11.Margin = new System.Windows.Forms.Padding(6);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(76, 38);
            this.button11.TabIndex = 59;
            this.button11.Text = "open";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(740, 959);
            this.comboBox3.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(120, 32);
            this.comboBox3.TabIndex = 58;
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(1150, 957);
            this.button12.Margin = new System.Windows.Forms.Padding(6);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(76, 38);
            this.button12.TabIndex = 61;
            this.button12.Text = "open";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(1014, 958);
            this.comboBox4.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(120, 32);
            this.comboBox4.TabIndex = 60;
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(1424, 957);
            this.button13.Margin = new System.Windows.Forms.Padding(6);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(76, 38);
            this.button13.TabIndex = 63;
            this.button13.Text = "open";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // comboBox5
            // 
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Location = new System.Drawing.Point(1288, 959);
            this.comboBox5.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(120, 32);
            this.comboBox5.TabIndex = 62;
            // 
            // labelRawData
            // 
            this.labelRawData.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelRawData.Location = new System.Drawing.Point(194, 1039);
            this.labelRawData.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRawData.Name = "labelRawData";
            this.labelRawData.Size = new System.Drawing.Size(145, 191);
            this.labelRawData.TabIndex = 64;
            // 
            // labelRawData1
            // 
            this.labelRawData1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelRawData1.Location = new System.Drawing.Point(472, 1042);
            this.labelRawData1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRawData1.Name = "labelRawData1";
            this.labelRawData1.Size = new System.Drawing.Size(145, 206);
            this.labelRawData1.TabIndex = 65;
            // 
            // labelRawData2
            // 
            this.labelRawData2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelRawData2.Location = new System.Drawing.Point(734, 1042);
            this.labelRawData2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRawData2.Name = "labelRawData2";
            this.labelRawData2.Size = new System.Drawing.Size(145, 217);
            this.labelRawData2.TabIndex = 66;
            // 
            // labelRawData3
            // 
            this.labelRawData3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelRawData3.Location = new System.Drawing.Point(1008, 1039);
            this.labelRawData3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRawData3.Name = "labelRawData3";
            this.labelRawData3.Size = new System.Drawing.Size(145, 220);
            this.labelRawData3.TabIndex = 67;
            // 
            // labelRawData4
            // 
            this.labelRawData4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelRawData4.Location = new System.Drawing.Point(1282, 1044);
            this.labelRawData4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRawData4.Name = "labelRawData4";
            this.labelRawData4.Size = new System.Drawing.Size(145, 215);
            this.labelRawData4.TabIndex = 68;
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(37, 956);
            this.button14.Margin = new System.Windows.Forms.Padding(6);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(76, 38);
            this.button14.TabIndex = 69;
            this.button14.Text = "close";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // timer2
            // 
            this.timer2.Interval = 20;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Interval = 20;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // timer4
            // 
            this.timer4.Interval = 20;
            this.timer4.Tick += new System.EventHandler(this.timer4_Tick);
            // 
            // timer5
            // 
            this.timer5.Interval = 20;
            this.timer5.Tick += new System.EventHandler(this.timer5_Tick);
            // 
            // timer6
            // 
            this.timer6.Interval = 20;
            this.timer6.Tick += new System.EventHandler(this.timer6_Tick);
            // 
            // timer7
            // 
            this.timer7.Tick += new System.EventHandler(this.timer7_Tick);
            // 
            // Button_Record
            // 
            this.Button_Record.Location = new System.Drawing.Point(202, 1313);
            this.Button_Record.Margin = new System.Windows.Forms.Padding(4);
            this.Button_Record.Name = "Button_Record";
            this.Button_Record.Size = new System.Drawing.Size(120, 56);
            this.Button_Record.TabIndex = 70;
            this.Button_Record.Text = "记录";
            this.Button_Record.UseVisualStyleBackColor = true;
            this.Button_Record.Click += new System.EventHandler(this.Button_Record_Click);
            // 
            // button_Stop
            // 
            this.button_Stop.Location = new System.Drawing.Point(459, 1313);
            this.button_Stop.Margin = new System.Windows.Forms.Padding(4);
            this.button_Stop.Name = "button_Stop";
            this.button_Stop.Size = new System.Drawing.Size(120, 56);
            this.button_Stop.TabIndex = 71;
            this.button_Stop.Text = "停止";
            this.button_Stop.UseVisualStyleBackColor = true;
            this.button_Stop.Click += new System.EventHandler(this.button_Stop_Click);
            // 
            // button_LoadCsv
            // 
            this.button_LoadCsv.Location = new System.Drawing.Point(709, 1313);
            this.button_LoadCsv.Margin = new System.Windows.Forms.Padding(4);
            this.button_LoadCsv.Name = "button_LoadCsv";
            this.button_LoadCsv.Size = new System.Drawing.Size(120, 56);
            this.button_LoadCsv.TabIndex = 72;
            this.button_LoadCsv.Text = "导出CSV";
            this.button_LoadCsv.UseVisualStyleBackColor = true;
            this.button_LoadCsv.Click += new System.EventHandler(this.button_LoadCsv_Click);
            // 
            // TCPDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1708, 1412);
            this.Controls.Add(this.button_LoadCsv);
            this.Controls.Add(this.button_Stop);
            this.Controls.Add(this.Button_Record);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.labelRawData4);
            this.Controls.Add(this.labelRawData3);
            this.Controls.Add(this.labelRawData2);
            this.Controls.Add(this.labelRawData1);
            this.Controls.Add(this.labelRawData);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.comboBox5);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.comboBox4);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.stepBox);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.INIT);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBox_Spe2);
            this.Controls.Add(this.textBox_Loc2);
            this.Controls.Add(this.comboBox_Axis2);
            this.Controls.Add(this.comboBox_FunNum2);
            this.Controls.Add(this.comboBox_Num2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBox_Spe1);
            this.Controls.Add(this.textBox_Loc1);
            this.Controls.Add(this.comboBox_Axis1);
            this.Controls.Add(this.comboBox_FunNum1);
            this.Controls.Add(this.comboBox_Num1);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.Message);
            this.Controls.Add(this.button_Send);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_Spe);
            this.Controls.Add(this.textBox_Loc);
            this.Controls.Add(this.comboBox_Axis);
            this.Controls.Add(this.comboBox_FunNum);
            this.Controls.Add(this.comboBox_Num);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_Port);
            this.Controls.Add(this.textBox_IP);
            this.Controls.Add(this.button_connect);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TCPDlg";
            this.Text = "TCPDlg";
            this.Load += new System.EventHandler(this.TCPDlg_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_connect;
        private System.Windows.Forms.TextBox textBox_IP;
        private System.Windows.Forms.TextBox textBox_Port;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_Num;
        private System.Windows.Forms.ComboBox comboBox_FunNum;
        private System.Windows.Forms.ComboBox comboBox_Axis;
        private System.Windows.Forms.TextBox textBox_Loc;
        private System.Windows.Forms.TextBox textBox_Spe;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button_Send;
        private System.Windows.Forms.TextBox Message;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox_Spe1;
        private System.Windows.Forms.TextBox textBox_Loc1;
        private System.Windows.Forms.ComboBox comboBox_Axis1;
        private System.Windows.Forms.ComboBox comboBox_FunNum1;
        private System.Windows.Forms.ComboBox comboBox_Num1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox_Spe2;
        private System.Windows.Forms.TextBox textBox_Loc2;
        private System.Windows.Forms.ComboBox comboBox_Axis2;
        private System.Windows.Forms.ComboBox comboBox_FunNum2;
        private System.Windows.Forms.ComboBox comboBox_Num2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button INIT;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox stepBox;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.Label labelRawData;
        private System.Windows.Forms.Label labelRawData1;
        private System.Windows.Forms.Label labelRawData2;
        private System.Windows.Forms.Label labelRawData3;
        private System.Windows.Forms.Label labelRawData4;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Timer timer4;
        private System.Windows.Forms.Timer timer5;
        private System.Windows.Forms.Timer timer6;
        private System.Windows.Forms.Timer timer7;
        private System.Windows.Forms.Button Button_Record;
        private System.Windows.Forms.Button button_Stop;
        private System.Windows.Forms.Button button_LoadCsv;
    }
}