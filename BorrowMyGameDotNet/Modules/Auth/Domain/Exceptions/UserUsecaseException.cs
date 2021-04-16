using System;

namespace BorrowMyGameDotNet.Modules.Auth.Domain.Exceptions
{
    public class UserUsecaseException : UserException
    {
        public UserUsecaseException()
        {
        }

        public UserUsecaseException(string message) : base(message)
        {
        }

        public UserUsecaseException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}