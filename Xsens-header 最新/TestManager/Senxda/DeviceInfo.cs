using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using XDA;
namespace Senxda
{
    public class DeviceInfo
    {
        public uint Id { get; private set; }

        public XsDeviceId DeviceId;
        public XsString ComPort;
        public XsBaudRate BaudRate;
        public XsString ProductCode;

        public DeviceInfo(XsDeviceId deviceId)
        {
            DeviceId = deviceId;
            Id = deviceId.toInt();
        }
    }
}

