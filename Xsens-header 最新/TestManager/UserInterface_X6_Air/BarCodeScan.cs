using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TestStudio.Automation.TestManager.libCommon.Class;

namespace UserInterface
{
    public partial class BarCodeScan : Form
    {
        string m_SN = ""; 
        public BarCodeScan()
        {
            InitializeComponent();
            InitUI();
        }

        public BarCodeScan(string sn):this() 
        {
            m_SN = sn;
        }

        private void InitUI()
        {
            bool bfirst = true;
            TextBox[] boxlist = { textBoxSN1, textBoxSN2, textBoxSN3, textBoxSN4, textBoxSN5, textBoxSN6 };
            for (int nsize = 0; nsize < 6; nsize++)
            {
                string str = string.Format("{0}{1}", tmMarcos.kUUTEnable, nsize);
                if (TestContext.m_dicConfig[str] != null)
                {
                    boxlist[nsize].Enabled = (bool)TestContext.m_dicConfig[str];
                    if (bfirst)
                    {
                        boxlist[nsize].Focus();
                        bfirst = false;
                    }
                }
                else
                {
                    boxlist[nsize].Enabled = true;
                }
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            TextBox[]  boxlist={textBoxSN1,textBoxSN2,textBoxSN3,textBoxSN4,textBoxSN5,textBoxSN6};
            //Lex may be we need to check the SN is ok no not.
            for (int nsize = 0; nsize < 6; nsize++)
            {
                string  str = boxlist[nsize].Text;
                if (str != null)
                {
                    DictionaryEx dic = new DictionaryEx();
                    dic["id"] = nsize;
                    dic[tmMarcos.kContextMLBSN] = str;
                    NotificationCenter.DefaultCenter().PostNotification(tmMarcos.kOnGetSN, dic);
                }
            }

            //DictionaryEx dicstart = new DictionaryEx();
            //dicstart["id"] = -1;
            //NotificationCenter.DefaultCenter().PostNotification(tmMarcos.kOnStartTest, dicstart);
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BarCodeScan_KeyPress(object sender, KeyPressEventArgs e)
        {
           if(e.KeyChar == (char)Keys.Enter)
           {
               TextBox[] boxlist = { textBoxSN1, textBoxSN2, textBoxSN3, textBoxSN4, textBoxSN5, textBoxSN6 };
               for (int nsize = 0; nsize < 6; nsize++)
               {
                   if (boxlist[nsize].Focused)
                   {

                   }
               }
           }
        }
    }
}
