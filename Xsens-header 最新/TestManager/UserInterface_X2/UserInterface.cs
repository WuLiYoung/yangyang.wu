using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TestStudio.Automation.TestManager.libCommon.Class;

namespace UserInterface
{
    class UserInterface
    {
        public int ShowTestStart(int id)
        {
            DictionaryEx dic = new DictionaryEx();
            dic["id"] = id;
            NotificationCenter.DefaultCenter().PostNotification(tmMarcos.kOnTestStart, dic);
            return 0;
        }
        public int ShowTestFinish(int id, int status)
        {
            DictionaryEx dic = new DictionaryEx();
            dic["id"] = id;
            dic["state"] = status;
            NotificationCenter.DefaultCenter().PostNotification(tmMarcos.kOnTestFinish, dic);
            return 0;
        }

        public int ShowItemStart(int id, int index)
        {
            DictionaryEx dic = new DictionaryEx();
            dic["id"] = id;
            dic["index"] = index;
            NotificationCenter.DefaultCenter().PostNotification(tmMarcos.kOnTestItemStart, dic);
            return 0;
        }

        public int ShowItemFinish(int id, int index, string display, int status, string remark)
        {
            DictionaryEx dic = new DictionaryEx();
            dic["id"] = id;
            dic["index"] = index;
            dic["value"] = display;
            dic["state"] = status;
            dic["remark"] = remark;
            NotificationCenter.DefaultCenter().PostNotification(tmMarcos.kOnTestItemFinish, dic);
            return 0;
        }
        public int ShowItemExInfo(int id, string display, int status, string exinfo)
        {
            DictionaryEx dic = new DictionaryEx();
            dic["id"] = id;
            dic["value"] = display;
            dic["state"] = status;
            dic["exinfo"] = exinfo;
            NotificationCenter.DefaultCenter().PostNotification(tmMarcos.kOnTestItemFinishEx, dic);

            return 0;
        }
        /// <summary>
        /// 设置sn
        /// </summary>
        /// <param name="id"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public int UiSetSN(int id, string str)
        {
            DictionaryEx dic = new DictionaryEx();
            dic["id"] = id;
            dic[tmMarcos.kContextMLBSN] = str;
            NotificationCenter.DefaultCenter().PostNotification(tmMarcos.kOnGetSN, dic);
            return 0;
        }
        /// <summary>
        /// 高亮测试过程中的灯
        /// </summary>
        /// <param name="nside">-1就是全关掉，左（0）还是右（1）</param>
        /// <param name="nindex"></param>
        /// <returns></returns>
        public int UiHighlightLamp(int id,int nside, int nindex)
        {
            DictionaryEx dic = new DictionaryEx();
            dic["id"] = id;
            dic["lampside"]     = nside;
            dic["lamplight"]    = nindex;
            NotificationCenter.DefaultCenter().PostNotification(tmMarcos.kOnCtrlLamp, dic);
            return 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nside"></param>
        /// <param name="nindex"></param>
        /// <param name="value"></param>
        /// <param name="resultstatue">PASS=1;FAIL=0;ERROR=-1;SKIP=2;</param>
        /// <returns></returns>
        public int UiDisplayARMinMax(int id,int nside, int nindex, string value,int resultstatue)
        {
            DictionaryEx dic = new DictionaryEx();
            dic["id"] = id;
            dic["side"] = nside;
            dic["index"] = nindex;
            dic["value"] = value;
            dic["resultstatue"] = resultstatue;
            NotificationCenter.DefaultCenter().PostNotification(tmMarcos.kOnUpdateArMinMax, dic);
            return 0;
        }
        /// <summary>
        /// 更新状态显示
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public int UiShowStatueText(int id ,string str)
        {

            return 0;
        }

        public int UiShowNotify(string str,int nHideTime)
        {
            NotifyWindow notify = new NotifyWindow();
            
            notify.Show();
            return 0;
        }
    }
}
