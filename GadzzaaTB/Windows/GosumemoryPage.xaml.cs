using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Ookii.Dialogs.Wpf;

namespace GadzzaaTB.Windows
{
    /// <summary>
    ///     Interaction logic for GosumemoryPage.xaml
    /// </summary>
    public partial class GosumemoryPage : Page
    {
        public GosumemoryPage()
        {
            InitializeComponent();
            AutoStartGY.IsChecked = false;
            Status.Content = "Status: Offline";
            Status.Foreground = Brushes.Red;
            WebHook.Visibility = Visibility.Visible;
            DisconnectWebhookY.Visibility = Visibility.Hidden;
            FolderLocation.Content = Settings1.Default.LocationFolderG;
            if (Settings1.Default.AutoStartG)
            {
                AutoStartGY.IsChecked = true;
                StartGosumemory();
                Main.main.ws2.ConnectAsync();
            }

            if (Settings1.Default.LocationFolderG == @"C:\Path\To\Gosumemory")
            {
                AutoStartGY.IsEnabled = false;
                AutoStartGY.IsChecked = false;
            }
        }

        private void DaPula(object sender, RoutedEventArgs e)
        {
            Main.main.bugReportp.Show();
        }

        private void ExecuteWebhook(object sender, RoutedEventArgs e)
        {
            Main.main.ws2.Connect();
        }

        private void BackButton(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Main.main.IntegP);
        }

        private void DisconnectWebhook(object sender, RoutedEventArgs e)
        {
            Main.main.ws2.Close();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Settings1.Default.AutoStartG = true;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Settings1.Default.AutoStartG = false;
        }

        private void StartGosumemory()
        {
            if (File.Exists(Settings1.Default.LocationFolderG + @"\gosumemory.exe"))
            {
                Process.Start(Settings1.Default.LocationFolderG + @"\gosumemory.exe");
                
            }
            else
            {
                MessageBox.Show(
                    "The folder is invalid. 'gosumemory.exe' not found in the selected directory!",
                    "gosumemory.exe not found");
                Settings1.Default.AutoStartG = false;
                AutoStartGY.IsChecked = false;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var dialog = new VistaFolderBrowserDialog();
            dialog.Description = "Please select Gosumemory's folder.";
            dialog.UseDescriptionForTitle = true;

            if ((bool) dialog.ShowDialog())
            {
                if (File.Exists(dialog.SelectedPath + @"\gosumemory.exe"))
                {
                    Settings1.Default.LocationFolderG = dialog.SelectedPath;
                    // MessageBox.Show(this, locationFolder);
                    Console.WriteLine(Settings1.Default.LocationFolderG);
                    FolderLocation.Content = Settings1.Default.LocationFolderG;
                    AutoStartGY.IsEnabled = true;
                }
                else
                {
                    MessageBox.Show(
                        "The folder is invalid. 'gosumemory.exe' not found in the selected directory!",
                        "gosumemory.exe not found");
                }
            }

            Console.WriteLine("Showed folder browser");
        }

        private void StartRestartGosumemory(object sender, RoutedEventArgs e)
        {
           // foreach (var process in Process.GetProcesses("gosumemory")) process.Kill();
            foreach (var process in Process.GetProcessesByName("WindowsTerminal")) process.Kill();
            StartGosumemory();
        }
    }
}