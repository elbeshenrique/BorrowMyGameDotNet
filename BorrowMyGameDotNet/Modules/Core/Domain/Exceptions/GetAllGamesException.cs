using System;

namespace BorrowMyGameDotNet.Modules.Core.Domain.Exceptions
{
    public class GameRepositoryException : BorrowMyGameException
    {

        private const string GameRepositoryFailure = "Game repository failure.";

        public GameRepositoryException()
            : base(GameRepositoryFailure)
        {
        }

        public GameRepositoryException(Exception innerException)
            : base(GameRepositoryFailure, innerException)
        {

        }
    }
}