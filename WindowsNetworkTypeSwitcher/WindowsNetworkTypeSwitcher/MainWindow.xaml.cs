using System;
using System.Collections.Generic;
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
using System.Diagnostics;
using Microsoft.Win32;

namespace WindowsNetworkTypeSwitcher
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            RefreshNetworks();
        }
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
        public void RefreshNetworks()
        {
            listBox_networks.Items.Clear();
            var hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey  NetworkRegistryList = hklm.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\NetworkList\Profiles");
            if (NetworkRegistryList == null)
            {
                Console.WriteLine("OpenSubKey returned null");
            }
            else
            {
                string[] RegistryNetworks = NetworkRegistryList.GetSubKeyNames();
                foreach (string RegistryNetwork in RegistryNetworks)
                {
                    NetworkPanel NetworkPanelitem = new NetworkPanel(RegistryNetwork);
                    listBox_networks.Items.Add(NetworkPanelitem);
                }
            }
        }
    }
}
