using System;

namespace BorrowMyGameDotNet.Modules.Core.Domain.Exceptions
{
    public class GetAllGamesException : BorrowMyGameException
    {

        private const string FailureGettingAll = "Failure on getting all games list.";

        public GetAllGamesException()
            : base(FailureGettingAll)
        {
        }

        public GetAllGamesException(Exception innerException)
            : base(FailureGettingAll, innerException)
        {
        }
    }
}