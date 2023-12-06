using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
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

        public MainWindow()
        {
            InitializeComponent();

            serialPort = new SerialPort();
            serialPort.BaudRate = 9600;
            serialPort.PortName = "COM4"; // Set in Windows
            serialPort.Open();
            serialPort.WriteTimeout = 1000;
        }

        private void btnRandom_Click(object sender, RoutedEventArgs e)
        {
            serialPort.WriteLine("2");
        }

        private void btnAll_Click(object sender, RoutedEventArgs e)
        {
            serialPort.WriteLine("1");
            serialPort.Close();
            AllTargetsWindow atw = new AllTargetsWindow();
            atw.Show();
            this.Close();
        }
    }
}
