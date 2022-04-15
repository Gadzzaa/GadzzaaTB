using System.Windows;
using GadzzaaTB.ExceptionWindow;
using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Diagnostics.Backends.Console;

namespace GadzzaaTB
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public App()
        {
            var unused = new WindowExceptionHandler();
            Startup += Application_Startup;
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var backend = new ConsoleLoggingBackend();
            backend.Options.Theme = new CustomTheme();
            backend.Options.IncludeTimestamp = true;
            backend.Options.TimestampFormat = "HH:mm:ss";

            LoggingServices.DefaultBackend = backend;
        }
    }
}