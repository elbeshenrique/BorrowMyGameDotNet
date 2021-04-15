namespace BorrowMyGameDotNet.Modules.Core.Domain.Entities
{
    public struct GameOutput
    {
        public readonly int Id;
        public readonly string Title;
        public readonly bool IsBorrowed;

        public GameOutput(int id, string title, bool isBorrowed)
        {
            Id = id;
            Title = title;
            IsBorrowed = isBorrowed;
        }
    }
}