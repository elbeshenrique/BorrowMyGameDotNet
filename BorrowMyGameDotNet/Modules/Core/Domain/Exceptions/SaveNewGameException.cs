using System;

namespace BorrowMyGameDotNet.Modules.Core.Domain.Exceptions
{
    public class SaveNewGameException : BorrowMyGameException
    {
        public const string FailureSavingGame = "Failure on saving game.";

        public SaveNewGameException()
            : base(FailureSavingGame)
        {
        }

        public SaveNewGameException(Exception innerException)
            : base(FailureSavingGame, innerException)
        {
        }
    }
}