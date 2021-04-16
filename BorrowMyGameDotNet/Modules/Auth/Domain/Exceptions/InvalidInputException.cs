namespace BorrowMyGameDotNet.Modules.Auth.Domain.Exceptions
{
    public class InvalidInputException : UserException
    {
        public InvalidInputException(string message)
            : base(message)
        {
        }
    }
}