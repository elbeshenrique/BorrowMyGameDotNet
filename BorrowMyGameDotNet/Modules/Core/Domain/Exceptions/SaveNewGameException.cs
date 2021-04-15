namespace BorrowMyGameDotNet.Modules.Core.Domain.Exceptions
{
    public class SaveNewGameException : BorrowMyGameException
    {
        public SaveNewGameException()
            : base("Failure on saving game.")
        {
        }
    }
}