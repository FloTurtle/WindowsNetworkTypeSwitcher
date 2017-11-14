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

namespace WindowsNetworkTypeSwitcher
{
    /// <summary>
    /// Interaktionslogik für NetworkPanel.xaml
    /// </summary>
    public partial class NetworkPanel : UserControl
    {
        private string registryNetwork;
        
        public NetworkPanel(string registryNetwork)
        {
            InitializeComponent();
            this.DataContext = this;
            this.registryNetwork = registryNetwork;
            textBlock_Network_name.Text = registryNetwork;
        }
    }
}
