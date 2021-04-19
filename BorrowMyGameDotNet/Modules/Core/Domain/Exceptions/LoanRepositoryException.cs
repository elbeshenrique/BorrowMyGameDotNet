using System;

namespace BorrowMyGameDotNet.Modules.Core.Domain.Exceptions
{
    public class LoanRepositoryException : CoreException
    {

        private const string RepositoryFailureMessage = "Loan repository failure.";

        public LoanRepositoryException()
            : base(RepositoryFailureMessage)
        {
        }

        public LoanRepositoryException(Exception innerException)
            : base(RepositoryFailureMessage, innerException)
        {

        }
    }
}