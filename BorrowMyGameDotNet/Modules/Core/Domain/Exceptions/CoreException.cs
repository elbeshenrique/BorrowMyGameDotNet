using System;

namespace BorrowMyGameDotNet.Modules.Core.Domain.Exceptions
{
    public abstract class CoreException : Exception
    {
        protected CoreException()
        {
        }

        protected CoreException(string message) : base(message)
        {
        }

        protected CoreException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}