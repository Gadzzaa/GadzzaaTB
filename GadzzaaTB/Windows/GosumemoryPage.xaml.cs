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

namespace GadzzaaTB.Windows
{
    /// <summary>
    /// Interaction logic for GosumemoryPage.xaml
    /// </summary>
    public partial class GosumemoryPage : Page
    {
        public GosumemoryPage()
        {
            InitializeComponent();
        }

        private void DaPula(object sender, RoutedEventArgs e)
        {
            Main.main.bugReportp.Show();
        }

        private void ExecuteWebhook(object sender, RoutedEventArgs e)
        {
            Main.main.ws2.ConnectAsync();
        }

        private void BackButton(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Main.main.IntegP);
        }
    }
}
