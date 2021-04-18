using System;

namespace BorrowMyGameDotNet.Modules.Core.Domain.Exceptions
{
    public class FriendUsecaseException : CoreException
    {

        public FriendUsecaseException(string message)
            : base(message)
        {
        }

        public FriendUsecaseException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}