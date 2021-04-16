namespace BorrowMyGameDotNet.Modules.Core.Domain.Exceptions
{
    public class NotFoundException : BorrowMyGameDotNetException
    {
        public NotFoundException(string message)
            : base(message)
        {
        }
    }
}