using System;

namespace GadzzaaTB.ExceptionWindow
{
    internal class ExceptionWindowVm
    {
        public ExceptionWindowVm(Exception exc)
        {
            Exception = exc;
            ExceptionType = exc.GetType().FullName;
        }

        public Exception Exception { get; }

        public string ExceptionType { get; }
    }
}