using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace UsbDetector
{
    public static class UsbChecker
    {
        public static IEnumerable<DriveInfo> SelectDrives()
        {
            return DriveInfo.GetDrives().Where(d => d.DriveType == DriveType.Removable);
        }
    }
}
