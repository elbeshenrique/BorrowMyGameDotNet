using System;

namespace BorrowMyGameDotNet.Modules.Core.Domain.Exceptions
{
    public class GameUsecaseException : CoreException
    {

        public GameUsecaseException(string message)
            : base(message)
        {
        }

        public GameUsecaseException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}