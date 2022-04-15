using System;
using System.Diagnostics;
using System.Windows;
using GadzzaaTB.Windows;

namespace GadzzaaTB.ExceptionWindow
{
    public partial class ExceptionWindow
    {
        public ExceptionWindow()
        {
            InitializeComponent();
        }

        // In a real world application we would use a command
        // property on the viewmodel and some sort of system
        // service that we inject into the viewmodel to exit the
        // application.
        private void OnExitAppClick(object sender, RoutedEventArgs e)
        {
            MainWindow.Test();
            Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }

        private void OnExceptionWindowClosed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}