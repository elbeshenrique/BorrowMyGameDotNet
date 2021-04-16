using System;

namespace BorrowMyGameDotNet.Modules.Core.Domain.Exceptions
{
    public abstract class BorrowMyGameDotNetException : Exception
    {
        protected BorrowMyGameDotNetException()
        {
        }

        protected BorrowMyGameDotNetException(string message) : base(message)
        {
        }

        protected BorrowMyGameDotNetException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}