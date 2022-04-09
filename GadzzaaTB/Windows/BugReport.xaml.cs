using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Octokit;
using Application = System.Windows.Application;

namespace GadzzaaTB.Windows
{
    /// <summary>
    ///     Interaction logic for Window1.xaml
    /// </summary>
    public partial class BugReport : Window
    {
        private string BugReportDescriptionY;
        private string BugReportNameY;
        private string line;

        public BugReport()
        {
            InitializeComponent();
            BugReportName.MaxLength = 10;
            BugReportDescription.AcceptsReturn = true;
            Closing += Window_Closing;
        }


        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if (!Main.main.MainA.isClosing)
            {
                Hide();
                e.Cancel = true;
            }
        }

        private void BugReportName_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            BugReportNameY = BugReportName.Text;
        }

        private void BugReportDescription_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            BugReportDescriptionY = BugReportDescription.Text;
        }

        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var gClient = new GitHubClient(new ProductHeaderValue("Gadzzaa"));
            var tokenAuth = new Credentials("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"); // NOTE: not real token
            gClient.Credentials = tokenAuth;
            Console.WriteLine("Bug Report Name: " + BugReportNameY);
            Console.WriteLine("Bug Report Description: " + BugReportDescriptionY);
            var createIssue = new NewIssue(Environment.MachineName + " reported: " + BugReportNameY);
            MainWindow.Test();
            var directory =
                new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) +
                                  "\\GadzzaaTB\\logs\\");
            var myFile = directory.GetFiles()
                .OrderByDescending(f => f.LastWriteTime)
                .First();
            var sr = new StreamReader(myFile.FullName);
            line = sr.ReadLine();
            BugReportDescriptionY += "\n\n\n\n\nLOG FILE:\n\n" + line + "\n";
            line = sr.ReadLine();
            //Continue to read until you reach end of file
            while (line != null)
            {
                //write the line to console window
                BugReportDescriptionY += line + "\n";
                //Read the next line
                line = sr.ReadLine();
            }

            //close the file
            sr.Close();
            Console.ReadLine();
            

            createIssue.Body = BugReportDescriptionY;
            var issue = await gClient.Issue.Create("Gadzzaa", "GadzzaaTB", createIssue);
            Close();
            Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }
    }
}