namespace BorrowMyGameDotNet.Modules.Auth.Domain.Exceptions
{
    public class InvalidCredentialsException : UserException
    {
        public InvalidCredentialsException(string message)
            : base(message)
        {
        }
    }
}