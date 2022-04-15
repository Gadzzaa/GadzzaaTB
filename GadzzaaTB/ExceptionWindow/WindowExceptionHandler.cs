using System;
using System.Windows;

namespace GadzzaaTB.ExceptionWindow
{
    /// <summary>
    ///     This ExceptionHandler implementation opens a new
    ///     error window for every unhandled exception that occurs.
    /// </summary>
    internal class WindowExceptionHandler : GlobalExceptionHandlerBase
    {
        /// <summary>
        ///     This method opens a new ExceptionWindow with the
        ///     passed exception object as data context.
        /// </summary>
        public override void OnUnhandledException(Exception e)
        {
            Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            {
                var exceptionWindow = new ExceptionWindow
                {
                    DataContext = new ExceptionWindowVm(e)
                };
                exceptionWindow.Show();
            }));
        }
    }
}