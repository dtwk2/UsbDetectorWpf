using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsbDetector.Enum;

namespace UsbDetector.EventArgs
{

    public class DeviceChangeEventArgs : System.EventArgs
    {
        public DeviceChange DeviceChange { get; set; }

    }
}
