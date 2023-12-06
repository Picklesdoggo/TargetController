using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TargetController
{
    /// <summary>
    /// Interaction logic for AllTargetsWindow.xaml
    /// </summary>
    public partial class AllTargetsWindow : Window
    {
        SerialPort serialPort;
        public AllTargetsWindow()
        {
            InitializeComponent();
            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 5000;
            aTimer.Enabled = true;
            serialPort = new SerialPort();
            serialPort.BaudRate = 9600;
            serialPort.PortName = "COM4"; // Set in Windows
            serialPort.Open();

        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            serialPort.WriteLine("r");
            while(serialPort.BytesToRead == 0)
            {
                // do nothing
            }
            String readData = serialPort.ReadLine();
            
            int breakPoint = 1;

        }
    }
}
