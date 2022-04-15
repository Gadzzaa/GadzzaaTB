using System;

namespace GadzzaaTB.ExceptionWindow
{
    public class UnknownAppDomainException : Exception
    {
        public UnknownAppDomainException(string msg) : base(msg)
        {
        }
    }
}