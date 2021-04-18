namespace BorrowMyGameDotNet.Modules.Core.Domain.Usecases.Game
{
    public class GameOutput
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsBorrowed { get; set; }

        public GameOutput()
        {
        }

        public GameOutput(int id, string title, bool isBorrowed)
        {
            Id = id;
            Title = title;
            IsBorrowed = isBorrowed;
        }
    }
}