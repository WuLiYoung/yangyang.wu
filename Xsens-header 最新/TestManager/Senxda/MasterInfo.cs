using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using XDA;
namespace Senxda
{
    public class MasterInfo : DeviceInfo
    {
        public MasterInfo(XsDeviceId id)
            : base(id)
        {
        }

        public override string ToString()
        {
            string portName = ComPort.toString();
            if (portName.Contains("usb"))
                return string.Format("Id {0:X8}", Id);
            else
                return string.Format("Id {2:X8} ({0:000} @ {1,8}bps)", ComPort.toString(), BaudRate, Id);
        }

    }
}

