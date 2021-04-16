namespace BorrowMyGameDotNet.Modules.Core.Domain.Exceptions
{
    public class InvalidInputException : CoreException
    {
        public InvalidInputException(string message)
            : base(message)
        {
        }
    }
}