using System;

namespace BorrowMyGameDotNet.Modules.Core.Domain.Exceptions
{
    public class GameBorrowedException : CoreException
    {

        private const string GameBorrowedMessage = "Game already borrowed.";

        public GameBorrowedException()
            : base(GameBorrowedMessage)
        {
        }

        public GameBorrowedException(Exception innerException)
            : base(GameBorrowedMessage, innerException)
        {

        }
    }
}