namespace BorrowMyGameDotNet.Modules.Auth.Domain.Exceptions
{
    public class NotFoundException : UserException
    {
        public NotFoundException(string message)
            : base(message)
        {
        }
    }
}