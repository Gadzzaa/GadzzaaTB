using System;
using System.Diagnostics;
using System.Windows;

namespace Tcoc.ExceptionHandler.Windows
{
    public partial class ExceptionWindow : Window
    {
        public ExceptionWindow()
        {
            InitializeComponent();
        }

        // In a real world application we would use a command
        // property on the viewmodel and some sort of system
        // service that we iject into the viewmodel to exit the
        // application.
        private void OnExitAppClick(object sender, RoutedEventArgs e)
        {
            Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }

        private void OnExceptionWindowClosed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}