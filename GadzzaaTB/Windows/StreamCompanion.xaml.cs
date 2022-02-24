using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Ookii.Dialogs.Wpf;

namespace GadzzaaTB
{
    public partial class StreamCompanion : Page
    {
        private readonly bool autoStartSC = Settings1.Default.AutoStart;
        private string locationFolder;

        public StreamCompanion()
        {
            InitializeComponent();
            if (Settings1.Default.LocationFolder != null ||
                Settings1.Default.LocationFolder != "@" + Settings1.Default.LocationFolder)
                locationFolder = Settings1.Default.LocationFolder;
            if (Settings1.Default.AutoStart)
                AutoStartSCY.IsChecked = true;
            else if (Settings1.Default.AutoStart == false)
                AutoStartSCY.IsChecked = false;
            FolderLocation.Content = locationFolder;
            if (!File.Exists(locationFolder + @"\osu!StreamCompanion.exe"))
            {
                AutoStartSCY.IsChecked = false;
                AutoStartSCY.IsEnabled = false;
            }

            StartWebSocket.Visibility = Visibility.Visible;
            DisconnectSCWebsocket.Visibility = Visibility.Hidden;
            Status.Content = "Status: Offline";
            Status.Foreground = Brushes.Red;
            if (autoStartSC)
            {
                if (File.Exists(locationFolder + @"\osu!StreamCompanion.exe"))
                {
                    Start_SC();
                    var i = 0;
                    foreach (var process in Process.GetProcessesByName("osu!StreamCompanion")) i = 1;
                    if (i == 0)
                    {
                        MessageBox.Show("StreamCompanion not running!", "Error!");
                    }
                    else
                    {
                        Main.main.ws.ConnectAsync();
                        Status.Content = "Status: Online";
                        Status.Foreground = Brushes.Green;
                        StartWebSocket.Visibility = Visibility.Hidden;
                        DisconnectSCWebsocket.Visibility = Visibility.Visible;
                    }
                }
                else
                {
                    Settings1.Default.AutoStart = false;
                }
            }
        }

        private void ShowFolderBrowserDialog()
        {
            var dialog = new VistaFolderBrowserDialog();
            dialog.Description = "Please select StreamCompanion's folder.";
            dialog.UseDescriptionForTitle = true;

            if ((bool) dialog.ShowDialog())
            {
                if (File.Exists(dialog.SelectedPath + @"\osu!StreamCompanion.exe"))
                {
                    locationFolder = dialog.SelectedPath;
                    // MessageBox.Show(this, locationFolder);
                    Settings1.Default.LocationFolder = locationFolder;
                    Console.WriteLine(Settings1.Default.LocationFolder);
                    FolderLocation.Content = locationFolder;
                    AutoStartSCY.IsEnabled = true;
                }
                else
                {
                    MessageBox.Show(
                        "The folder is invalid. 'osu!StreamCompanion.exe' not found in the selected directory!",
                        "osu!StreamCompanion.exe not found");
                }
            }
        }

        private void Start_SC()
        {
            foreach (var process in Process.GetProcessesByName("osu!StreamCompanion")) process.Kill();
            Process.Start(locationFolder + @"\osu!StreamCompanion.exe");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ShowFolderBrowserDialog();
            Console.WriteLine("Showed folder browser");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Start_SC();
            Console.WriteLine("Started StreamCompanion");
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Main.main.IntegP);
            Console.WriteLine("Navigation to Integrations Tab Request Sent!");
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Settings1.Default.AutoStart = true;
            Console.WriteLine("Checked Auto Start");
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Settings1.Default.AutoStart = false;
            Console.WriteLine("Unchecked Auto Start");
        }

        private void WebSocketConnect(object sender, RoutedEventArgs e)
        {
            var i = 0;
            foreach (var process in Process.GetProcessesByName("osu!StreamCompanion")) i = 1;
            if (i == 0)
            {
                MessageBox.Show("StreamCompanion not running!", "Error!");
            }
            else
            {
                Main.main.ws.ConnectAsync();
                StartWebSocket.Visibility = Visibility.Hidden;
                DisconnectSCWebsocket.Visibility = Visibility.Visible;
            }
        }

        private void WebSocketDisconnect(object sender, RoutedEventArgs e)
        {
            Main.main.ws.CloseAsync();
            StartWebSocket.Visibility = Visibility.Visible;
            DisconnectSCWebsocket.Visibility = Visibility.Hidden;
        }
    }
}