using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Interop;
using UsbDetector.Enum;

namespace UsbDetector
{
    public class USBWindow:Window
    {

        private IntPtr windowHandle;

        protected override void OnSourceInitialized(System.EventArgs e)
        {
            base.OnSourceInitialized(e);

            // Adds the windows message processing hook and registers USB device add/removal notification.
            HwndSource source = HwndSource.FromHwnd(new WindowInteropHelper(this).Handle);
            if (source != null)
            {
                windowHandle = source.Handle;
                source.AddHook(HwndHandler);
                UsbDetector.UsbNotification.RegisterUsbDeviceNotification(windowHandle);
            }
        }

        public event EventHandler<DeviceChange> DeviceChanged;

        /// <summary>
        /// Method that receives window messages.
        /// https://stackoverflow.com/questions/16245706/check-for-device-change-add-remove-events
        /// </summary>
        private IntPtr HwndHandler(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam, ref bool handled)
        {
            if (msg == UsbNotification.WmDevicechange)
            {
                switch ((int)wparam)
                {
                    case UsbNotification.DbtDeviceremovecomplete:
                        this.DeviceChanged?.Invoke(this, DeviceChange.Remove);
                        //OnThresholdReached();
                        break;
                    case UsbNotification.DbtDevicearrival:
                        this.DeviceChanged?.Invoke(this, DeviceChange.Add);
                        // OnThresholdReached();
                        break;
                }
            }

            handled = false;
            return IntPtr.Zero;
        }

    }
}
