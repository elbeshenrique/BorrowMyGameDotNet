using System;

namespace BorrowMyGameDotNet.Modules.Core.Domain.Exceptions
{
    public class LoanUsecaseException : CoreException
    {
        public LoanUsecaseException(string message)
            : base(message)
        {
        }

        public LoanUsecaseException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}