using System;

namespace BorrowMyGameDotNet.Modules.Auth.Domain.Exceptions
{
    public class UserRepositoryException : UserException
    {
        public UserRepositoryException()
        {
        }

        public UserRepositoryException(string message) : base(message)
        {
        }

        public UserRepositoryException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}