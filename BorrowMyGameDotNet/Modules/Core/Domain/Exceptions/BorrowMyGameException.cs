using System;

namespace BorrowMyGameDotNet.Modules.Core.Domain.Exceptions
{
    public abstract class BorrowMyGameException : Exception
    {
        protected BorrowMyGameException(string message) : base(message) {
        }

        protected BorrowMyGameException(string message, Exception innerException) : base(message, innerException) {
        }
    }
}