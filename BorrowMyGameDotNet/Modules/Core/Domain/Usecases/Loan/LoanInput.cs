namespace BorrowMyGameDotNet.Modules.Core.Domain.Usecases.Game
{
    public class LoanInput
    {
        public int GameId { get; set; }
        public int FriendId { get; set; }
    }
}