namespace BorrowMyGameDotNet.Modules.Core.Domain.Exceptions
{
    public class InvalidInputException : BorrowMyGameDotNetException
    {
        public InvalidInputException(string message)
            : base(message)
        {
        }
    }
}