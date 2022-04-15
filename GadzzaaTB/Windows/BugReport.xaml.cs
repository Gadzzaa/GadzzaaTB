using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Octokit;
using Application = System.Windows.Application;

// ReSharper disable StringLiteralTypo

namespace GadzzaaTB.Windows
{
    /// <summary>
    ///     Interaction logic for Window1.xaml
    /// </summary>
    public partial class BugReport
    {
        private string _bugReportDescriptionY;
        private string _bugReportNameY;
        private string _line;

        public BugReport()
        {
            InitializeComponent();
            BugReportName.MaxLength = 10;
            BugReportDescription.AcceptsReturn = true;
            Closing += Window_Closing;
        }


        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if (!Main.main.mainA.isClosing)
            {
                Hide();
                e.Cancel = true;
            }
        }

        private void BugReportName_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            _bugReportNameY = BugReportName.Text;
        }

        private void BugReportDescription_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            _bugReportDescriptionY = BugReportDescription.Text;
        }

        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var gClient = new GitHubClient(new ProductHeaderValue("Gadzzaa"));
            var tokenAuth = new Credentials("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"); // NOTE: not real token
            gClient.Credentials = tokenAuth;
            Console.WriteLine(@"Bug Report Name: " + _bugReportNameY);
            Console.WriteLine(@"Bug Report Description: " + _bugReportDescriptionY);
            var createIssue = new NewIssue(Environment.MachineName + " reported: " + _bugReportNameY);
            MainWindow.Test();
            var directory =
                new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) +
                                  "\\GadzzaaTB\\logs\\");
            var myFile = directory.GetFiles()
                .OrderByDescending(f => f.LastWriteTime)
                .First();
            var sr = new StreamReader(myFile.FullName);
            _line = await sr.ReadLineAsync();
            _bugReportDescriptionY += "\n\n\n\n\nLOG FILE:\n\n" + _line + "\n";
            _line = await sr.ReadLineAsync();
            //Continue to read until you reach end of file
            while (_line != null)
            {
                //write the line to console window
                _bugReportDescriptionY += _line + "\n";
                //Read the next line
                _line = await sr.ReadLineAsync();
            }

            //close the file
            sr.Close();
            Console.ReadLine();


            createIssue.Body = _bugReportDescriptionY;
            var unused = await gClient.Issue.Create("Gadzzaa", "GadzzaaTB", createIssue);
            Close();
            Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }
    }
}