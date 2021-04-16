using System;

namespace BorrowMyGameDotNet.Modules.Core.Domain.Exceptions
{
    public class GameRepositoryException : BorrowMyGameDotNetException
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