namespace BorrowMyGameDotNet.Modules.Core.Domain.Entities
{
    public struct GameInput
    {
        public readonly string Title;
        public readonly bool IsBorrowed;

        public GameInput(string title, bool isBorrowed)
        {
            Title = title;
            IsBorrowed = isBorrowed;
        }
    }
}