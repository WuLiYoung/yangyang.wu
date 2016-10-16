using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using Checkroute;

namespace MES_CHECK
{
    class MESCLASS
    {
      
        Mescheckroute mescheck = new Mescheckroute();
        public bool flag = false;
         string message="";
         string Fmsg="";
         
        public  bool CheckSN(string sn, string station){

            flag = mescheck.checkroute(sn, station, out message);
            Fmsg = message;
            if (!flag)
            {
                System.Windows.Forms.MessageBox.Show(sn+":MES Fail\n"+Fmsg);
            }
            return flag;
        
        }
        public string getFmsg() {
            return Fmsg;
        }
    }
}
