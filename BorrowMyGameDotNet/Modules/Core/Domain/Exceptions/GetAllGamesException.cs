namespace BorrowMyGameDotNet.Modules.Core.Domain.Exceptions
{
    public class GameRepositoryException : BorrowMyGameException
    {
        public GameRepositoryException()
            : base("Game repository failure.")
        {
        }
    }
}