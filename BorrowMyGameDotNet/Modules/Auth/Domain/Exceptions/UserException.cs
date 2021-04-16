using System;

namespace BorrowMyGameDotNet.Modules.Auth.Domain.Exceptions
{
    public abstract class UserException : Exception
    {
        protected UserException()
        {
        }

        protected UserException(string message) : base(message)
        {
        }

        protected UserException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}