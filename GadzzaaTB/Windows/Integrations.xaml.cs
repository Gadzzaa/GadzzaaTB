using System;
using System.Windows;
using System.Windows.Controls;

namespace GadzzaaTB
{
    /// <summary>
    ///     Interaction logic for Integrations.xaml
    /// </summary>
    public partial class Integrations : Page
    {
        public Integrations()
        {
            InitializeComponent();
        }

        private void ShowStreamCompanion(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Main.main.StreamCP);
            Console.WriteLine("Navigation to StreamCompanion Tab Request Sent!");
        }

        private void BackButton(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Main.main.MainA.MainW);
            Console.WriteLine("Navigation to Main Tab Request Sent!");
        }
    }
}