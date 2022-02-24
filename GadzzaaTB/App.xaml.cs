using System.Windows;
using Tcoc.ExceptionHandler.ExceptionHandling;

namespace GadzzaaTB
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly WindowExceptionHandler _exceptionHandler;

        public App()
        {
            _exceptionHandler = new WindowExceptionHandler();
        }
    }
}