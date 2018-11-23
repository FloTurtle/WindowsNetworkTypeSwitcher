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
    public partial class NetworkPanel : UserControl
    {
        private RegistryKey registryNetworkkey;
        
        public NetworkPanel(RegistryKey registryNetworkkey)
        {
            InitializeComponent();
            this.DataContext = this;
            this.registryNetworkkey = registryNetworkkey;
            if (registryNetworkkey.GetValue("ProfileName") != null)
            {
                string registryNetwork_name = registryNetworkkey.GetValue("ProfileName").ToString();
                textBlock_Network_name.Text = registryNetwork_name;
            }
            else
            {
                Console.WriteLine("GetValue('ProfileName') returned null");
            }

            if (registryNetworkkey.GetValue("Category") != null)
            {
                int registryNetwork_type = Convert.ToInt32(registryNetworkkey.GetValue("Category",-1));
                if (registryNetwork_type == 0)
                {
                    button_private.IsEnabled = true;
                    button_domain.IsEnabled = true;
                }
                else if (registryNetwork_type == 1)
                {
                    button_public.IsEnabled = true;
                    button_domain.IsEnabled = true;
                }
                else if (registryNetwork_type == 2)
                {
                    button_public.IsEnabled = true;
                    button_private.IsEnabled = true;
                }
                else
                {
                    Console.WriteLine("GetValue('Category') returned something different than 0 or 1 or 2");
                }
            }
            else
            {
                Console.WriteLine("GetValue('Category') returned null");
            }
        }

        private void button_public_Click(object sender, RoutedEventArgs e)
        {
            button_public.IsEnabled = false;
            registryNetworkkey.SetValue("Category", 0, RegistryValueKind.DWord);
            button_private.IsEnabled = true;
            button_domain.IsEnabled = true;
        }

        private void button_private_Click(object sender, RoutedEventArgs e)
        {
            button_private.IsEnabled = false;
            registryNetworkkey.SetValue("Category", 1, RegistryValueKind.DWord);
            button_public.IsEnabled = true;
            button_domain.IsEnabled = true;
        }

        private void button_domain_Click(object sender, RoutedEventArgs e)
        {
            button_domain.IsEnabled = false;
            registryNetworkkey.SetValue("Category", 2, RegistryValueKind.DWord);
            button_public.IsEnabled = true;
            button_private.IsEnabled = true;
        }
    }
}
