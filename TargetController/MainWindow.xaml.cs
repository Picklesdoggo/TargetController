using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TargetController
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static SerialPort serialPort;
        ObservableCollection<SplitTime> splitTimes = new ObservableCollection<SplitTime>();
        List<Ellipse> targets = new List<Ellipse>();
        DateTime hitTimeReference;

        public MainWindow()
        {
            InitializeComponent();
            serialPort = new SerialPort();
            serialPort.BaudRate = 9600;
            serialPort.PortName = "COM4"; // Set in Windows            
            serialPort.WriteTimeout = 1000;
            serialPort.DataReceived += SerialPort_DataReceived;

            targets.Add(target0);
            targets.Add(target1);
            targets.Add(target2);
            targets.Add(target3);
            targets.Add(target4);

            grdSplits.ItemsSource = splitTimes;
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string dataReceived = serialPort.ReadLine();

            List<string> split = dataReceived.Split(',').ToList();

            SplitTime splitTime = new SplitTime();
            splitTime.TargetID = split[0];
            splitTime.SensorReading = split[1];
            splitTime.TimeHit = DateTime.Now;
            splitTime.TimeDuration = splitTime.TimeHit - hitTimeReference;
            hitTimeReference = DateTime.Now;

            App.Current.Dispatcher.Invoke((Action)delegate // <--- HERE
            {
                int targetIndex = Convert.ToInt32(splitTime.TargetID);
                targets[targetIndex].Fill = Brushes.Green;
                splitTimes.Add(splitTime);
                grdSplits.ScrollIntoView(grdSplits.Items[grdSplits.Items.Count - 1]);
            });
            

        }

        private void Connect_Click(object sender, RoutedEventArgs e)
        {
            serialPort.Open();
            hitTimeReference = DateTime.Now;
        }
    }
}
