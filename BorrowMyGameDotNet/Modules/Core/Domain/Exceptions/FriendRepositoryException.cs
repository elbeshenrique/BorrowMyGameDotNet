using System;

namespace BorrowMyGameDotNet.Modules.Core.Domain.Exceptions
{
    public class FriendRepositoryException : CoreException
    {

        private const string FriendRepositoryFailureMessage = "Friend repository failure.";

        public FriendRepositoryException()
            : base(FriendRepositoryFailureMessage)
        {
        }

        public FriendRepositoryException(Exception innerException)
            : base(FriendRepositoryFailureMessage, innerException)
        {
        }
    }
}