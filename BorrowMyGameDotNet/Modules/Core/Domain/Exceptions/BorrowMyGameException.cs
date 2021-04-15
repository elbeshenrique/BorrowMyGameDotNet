using System;

namespace BorrowMyGameDotNet.Modules.Core.Domain.Exceptions
{
    public abstract class BorrowMyGameException : Exception
    {
        protected BorrowMyGameException(string message) : base(message) {
        }
    }
}