namespace BorrowMyGameDotNet.Modules.Core.Domain.Exceptions
{
    public class NotFoundException : CoreException
    {
        public NotFoundException(string message)
            : base(message)
        {
        }
    }
}