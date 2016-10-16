using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using XDA;
namespace Senxda
{
    public class MtwEventArgs : EventArgs
    {
        public XsDevice Mtw { get; private set; }
        public bool Connected { get; private set; }
        public MtwEventArgs(XsDevice mtw, bool connected)
        {
            Mtw = mtw;
            Connected = connected;
        }
    }

    public class DataAvailableArgs : EventArgs
    {
        public XsDevice Device { get; private set; }
        public XsDataPacket Packet { get; private set; }
        public DataAvailableArgs(XsDevice device, XsDataPacket packet)
        {
            Device = device;
            Packet = packet;
        }
    }

    public class BatteryLevelChangedArgs : EventArgs
    {
        public XsDeviceId DeviceId { get; private set; }
        public int Level { get; private set; }
        public BatteryLevelChangedArgs(XsDeviceId deviceId, int level)
        {
            DeviceId = deviceId;
            Level = level;
        }
    }

    public class ProgressUpdateArgs : EventArgs
    {
        public XsDeviceId DeviceId { get; private set; }
        public int Current { get; private set; }
        public int Total { get; private set; }
        public string Identifier { get; private set; }
        public ProgressUpdateArgs(XsDeviceId deviceId, int current, int total, string identifier)
        {
            DeviceId = deviceId;
            Current = current;
            Total = total;
            Identifier = identifier;
        }
    }

    public class DeviceErrorArgs : EventArgs
    {
        public XsDeviceId DeviceId { get; private set; }
        public XsResultValue Result { get; private set; }
        public DeviceErrorArgs(XsDeviceId deviceId, XsResultValue result)
        {
            DeviceId = deviceId;
            Result = result;
        }
    }

    public class DeviceIdArg : EventArgs
    {
        public XsDeviceId DeviceId { get; private set; }
        public DeviceIdArg(XsDeviceId deviceId)
        {
            DeviceId = deviceId;
            string bla = DeviceId.toXsString().toString();
            string bla2 = deviceId.toXsString().toString();
        }
    }

    public class PortInfoArg : EventArgs
    {
        public XsPortInfo PortInfo { get; private set; }
        public PortInfoArg(XsPortInfo portInfo)
        {
            PortInfo = portInfo;
        }
    }
}
