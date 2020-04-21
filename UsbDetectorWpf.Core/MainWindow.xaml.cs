using System;
using System.Windows;


namespace UsbDetectorWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : UsbDetector.USBWindow
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_DeviceChanged(object sender, UsbDetector.Enum.DeviceChange e)
        {
            MessageBox.Show(e.ToString());
        }
    }
}
