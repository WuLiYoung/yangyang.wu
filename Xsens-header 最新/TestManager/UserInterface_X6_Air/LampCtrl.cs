using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using TestStudio.Automation.TestManager.libCommon.Class;
using TestStudio.Automation.TestManager.libCommon.Interface;

namespace UserInterface
{
    class LampCtrl
    {
        public List<Button> m_buttonarrayleft = new List<Button>();
        public List<Button> m_buttonarrayright = new List<Button>();
        public Button m_curBtnleft = null;
        public Button m_curBtnright = null;
    
        public void AddCtrl(Button btn,int nside)
        {
            if (nside == 0)
            {
                m_buttonarrayleft.Add(btn);
            }
            else
            {
                m_buttonarrayright.Add(btn);
            }
        }

        public void HighLight(int nSide, int nIndex)
        {
            if (nSide == 0)
            {
                HighLightSingle(m_curBtnleft, false);
                if (nIndex >= 0)
                {
                    HighLightSingle(m_buttonarrayleft[nIndex], true);
                    m_curBtnleft = m_buttonarrayleft[nIndex];
                }
            }
            else if (nSide == 1)
            {
                HighLightSingle(m_curBtnright, false);
                if (nIndex >= 0)
                {
                    HighLightSingle(m_buttonarrayright[nIndex], true);
                    m_curBtnright = m_buttonarrayright[nIndex];
                }
            }
            else
            {
                HighLightSingle(m_curBtnleft, false);
                HighLightSingle(m_curBtnright, false);
            }
        }

        protected void HighLightSingle(Button btn,bool bhighlight)
        {
            if (btn == null)
                return;
            if(bhighlight)
            {
                string imagepath = Path.Combine(tmEnvironment.AppDir(),
                            @"images\\1683_Lightbulb_32x32.png");
                btn.BackgroundImage = System.Drawing.Image.FromFile(imagepath);
            }
            else
            {
                btn.BackgroundImage = null;
            }
            btn.Refresh();
        }

        //nstatue : 0 == normal 1 == ok -1 = fail
        public void SetLampStatue(int nSide, int nIndex, int nstatue,string value)
        {
            if (nSide == 1)
            {
                if (nIndex >= 0 && nIndex < m_buttonarrayleft.Count)
                {
                    SetSingleLampStatue(m_buttonarrayleft[nIndex],
                        nstatue,nIndex.ToString()+"\r\n"+value);
                }
            }
            else
            {
                if (nIndex >= 0 && nIndex < m_buttonarrayleft.Count)
                {
                    SetSingleLampStatue(m_buttonarrayright[nIndex],
                        nstatue, nIndex.ToString() + "\r\n" + value);
                }
            }
        }

        public void ResetAllLampStatue()
        {
            for (int nsize = 0; nsize < m_buttonarrayleft.Count; nsize++)
            {
                SetSingleLampStatue(m_buttonarrayleft[nsize], 0xff, nsize.ToString());
            }
            for (int nsize = 0; nsize < m_buttonarrayright.Count; nsize++)
            {
                SetSingleLampStatue(m_buttonarrayright[nsize], 0xff, nsize.ToString());
            }
        }

        protected void SetSingleLampStatue(Button btn,int nstatue,string value)
        {
            if (nstatue == 0xff)
            {
                btn.BackColor = System.Drawing.Color.White;
            }
            else if(nstatue == 1)
            {
                btn.BackColor = System.Drawing.Color.Green;
            }
            else if (nstatue == -1||nstatue == 0)
            {
                btn.BackColor = System.Drawing.Color.Red;
            }
            btn.Text = value;
        }
    }
}
