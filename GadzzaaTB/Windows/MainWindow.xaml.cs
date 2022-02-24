﻿using System;
using System.IO;
using System.Windows;
using Microsoft.VisualBasic.Devices;
using System.Diagnostics;


namespace GadzzaaTB
{
    public partial class MainWindow : Window
    {
        public static FileStream ostrm;
        public static StreamWriter writer;
        public static TextWriter oldOut = Console.Out;
        public Main MainW; 
        StackTrace stackTrace = new StackTrace();


        public MainWindow()
        {
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
                Console.WriteLine("Cannot open Redirect.txt for writing");
                Console.WriteLine(e.Message);
                return;
            }

            Console.SetOut(writer);
            Console.WriteLine("||||||||| SYSTEM INFO |||||||||");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("PC User Name : " + Environment.UserName);
            Console.WriteLine("OS Version: " + getOSInfo());
            Console.WriteLine("Machine Name: " + Environment.MachineName);
            var OStype = "";
            if (Environment.Is64BitOperatingSystem)
                OStype = "64-Bit, ";
            else
                OStype = "32-Bit, ";
            OStype += Environment.ProcessorCount + " Threads";
            Console.WriteLine("OS Type: " + OStype);
            var toalRam = GetTotalMemoryInBytes();
            var toal = Convert.ToDouble(toalRam / (1024 * 1024));
            var t = Convert.ToInt32(Math.Ceiling(toal / 1024).ToString());
            Console.WriteLine("Memory: " + t + " GB");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("|||||||||||||||||||||||||||||||");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("||||||||| CONSOLE OUTPUT |||||||||");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Logging Started");
            InitializeComponent();
            MainW = new Main();
            Loaded += MyWindow_Loaded;
        }

        private void MyWindow_Loaded(object sender, RoutedEventArgs e)
        {
            NavigationFrame1.NavigationService.Navigate(MainW);
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
            Console.WriteLine("Done");
        }

        public string getOSInfo()
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
                        if (vs.Revision.ToString() == "2222A")
                            operatingSystem = "98SE";
                        else
                            operatingSystem = "98";
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
                        if (vs.Minor == 0)
                            operatingSystem = "Windows 2000";
                        else
                            operatingSystem = "Windows XP";
                        break;
                    case 6:
                        if (vs.Minor == 0)
                            operatingSystem = "Windows Vista";
                        else
                            operatingSystem = "Windows 7 or Above";
                        break;
                }

            return operatingSystem;
        }
    }
}