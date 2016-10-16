using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using C28Instrument;
using System.Threading;

namespace CYPress
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            ReadID.GetID();
            textBox1.Text = "";
            textBox1.Text = ReadID.Ret[0]+ "\r\n";
            textBox1.Text += ReadID.Ret[1]  + "\r\n";
            textBox1.Text += ReadID.Ret[2]  + "\r\n";
            textBox1.Text += ReadID.Ret[3]  + "\r\n";
            textBox1.Text += ReadID.Ret[4]  + "\r\n";
        }

    }
}
