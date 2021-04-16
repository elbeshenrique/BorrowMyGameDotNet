using System;

namespace BorrowMyGameDotNet.Modules.Core.Domain.Exceptions
{
    public class GameRepositoryException : CoreException
    {

        private const string GameRepositoryFailureMessage = "Game repository failure.";

        public GameRepositoryException()
            : base(GameRepositoryFailureMessage)
        {
        }

        public GameRepositoryException(Exception innerException)
            : base(GameRepositoryFailureMessage, innerException)
        {

        }
    }
}