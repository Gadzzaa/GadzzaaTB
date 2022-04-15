using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using Microsoft.VisualBasic.Devices;

// ReSharper disable SpecifyACultureInStringConversionExplicitly

namespace GadzzaaTB.Windows
{
    public partial class MainWindow
    {
        // ReSharper disable once IdentifierTypo
        public static FileStream ostrm;
        public static StreamWriter writer;
        public static TextWriter oldOut = Console.Out;
        public bool isClosing;
        public Main mainW;
        public UpdaterPage updatePage;


        public MainWindow()
        {
            if (Settings1.Default.FirstRun)
                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory +
                                @"StreamCompanion\osu!StreamCompanion.exe"))
                    Settings1.Default.LocationFolder =
                        AppDomain.CurrentDomain.BaseDirectory + @"StreamCompanion";
                else MessageBox.Show("Invalid install ! Please consider reinstalling the app!", "Error on startup!");
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory +
                            @"gosumemory\gosumemory.exe"))
                Settings1.Default.LocationFolderG =
                    AppDomain.CurrentDomain.BaseDirectory + @"gosumemory";
            else MessageBox.Show("Invalid install ! Please consider reinstalling the app!", "Error on startup!");
            Settings1.Default.FirstRun = false;
            var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) +
                       "\\GadzzaaTB\\logs\\" + DateTime.UtcNow.Year + "-" + DateTime.UtcNow.Month + "-" +
                       DateTime.UtcNow.Day + " " + DateTime.UtcNow.Hour + "-" + DateTime.UtcNow.Minute + "-" +
                       DateTime.UtcNow.Second + ".txt";
            Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) +
                                      "\\GadzzaaTB\\logs\\");
            Console.WriteLine(path);
            if (!File.Exists(path))
                using (var fs = File.Create(path))
                {
                    for (byte i = 0; i < 100; i++) fs.WriteByte(i);
                }

            try
            {
                ostrm = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                writer = new StreamWriter(ostrm);
            }
            catch (Exception e)
            {
                Console.WriteLine(@"Cannot open Redirect.txt for writing");
                Console.WriteLine(e.Message);
                return;
            }

            Console.SetOut(writer);


            Console.WriteLine(@"SYSTEM INFO");
            Console.WriteLine(@"PC User Name : " + Environment.UserName);
            Console.WriteLine(@"OS Version: " + GetOsInfo());
            Console.WriteLine(@"Machine Name: " + Environment.MachineName);
            var ostype = Environment.Is64BitOperatingSystem ? "64-Bit, " : "32-Bit, ";
            ostype += Environment.ProcessorCount + " Threads";
            Console.WriteLine(@"OS Type: " + ostype);
            var totalRam = GetTotalMemoryInBytes();
            var total = Convert.ToDouble(totalRam / (1024 * 1024));
            var t = Convert.ToInt32(Math.Ceiling(total / 1024).ToString());
            Console.WriteLine($@"Memory: {t} GB");
            Console.WriteLine(@"CONSOLE OUTPUT");


            InitializeComponent();
            mainW = new Main();
            updatePage = new UpdaterPage();
            Loaded += MyWindow_Loaded;
            Closed += OnClosed;
        }

        protected void OnClosed(object sender, EventArgs e)
        {
            isClosing = true;
            Main.main.bugReport.Close();
            Test();
            foreach (var process in Process.GetProcessesByName("osu!StreamCompanion")) process.Kill();
            foreach (var process in Process.GetProcessesByName("WindowsTerminal")) process.Kill();
            Settings1.Default.Save();
            Application.Current.Shutdown();
        }

        private void MyWindow_Loaded(object sender, RoutedEventArgs e)
        {
            NavigationFrame.NavigationService.Navigate(mainW);
        }


        private static ulong GetTotalMemoryInBytes()
        {
            return new ComputerInfo().TotalPhysicalMemory;
        }

        public static void Test()
        {
            Console.SetOut(oldOut);
            writer.Close();
            ostrm.Close();
            Console.WriteLine(@"Done");
        }

        public string GetOsInfo()
        {
            //Get Operating system information.
            var os = Environment.OSVersion;
            //Get version information about the os.
            var vs = os.Version;

            //Variable to hold our return value
            var operatingSystem = "";

            if (os.Platform == PlatformID.Win32Windows)
                //This is a pre-NT version of Windows
                switch (vs.Minor)
                {
                    case 0:
                        operatingSystem = "95";
                        break;
                    case 10:
                        operatingSystem = vs.Revision.ToString() == "2222A" ? "98SE" : "98";
                        break;
                    case 90:
                        operatingSystem = "Me";
                        break;
                }
            else if (os.Platform == PlatformID.Win32NT)
                switch (vs.Major)
                {
                    case 3:
                        operatingSystem = "NT 3.51";
                        break;
                    case 4:
                        operatingSystem = "NT 4.0";
                        break;
                    case 5:
                        operatingSystem = vs.Minor == 0 ? "Windows 2000" : "Windows XP";
                        break;
                    case 6:
                        operatingSystem = vs.Minor == 0 ? "Windows Vista" : "Windows 7 or Above";
                        break;
                }

            return operatingSystem;
        }
    }
}