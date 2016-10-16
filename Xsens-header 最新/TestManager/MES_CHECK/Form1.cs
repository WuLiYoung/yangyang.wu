using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MES_CHECK
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool pf = GT_MESCLASS.m_object.CheckSN(SNText.Text,StationText.Text);
            richTextBox1.Text = GT_MESCLASS.m_object.getFmsg();
            if (pf == true)
            {
                labelStaion.BackColor = Color.Green;
                label2.Text = "PASS";
            }
            else
            {
                labelStaion.BackColor = Color.Red;
                label2.Text = "Fail";
            }
        }

       

        

       
      
    }
}
