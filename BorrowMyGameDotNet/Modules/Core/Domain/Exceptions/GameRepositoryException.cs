namespace BorrowMyGameDotNet.Modules.Core.Domain.Exceptions
{
    public class GetAllGamesException : BorrowMyGameException
    {
        public GetAllGamesException()
            : base("Failure on getting all games list.")
        {
        }
    }
}