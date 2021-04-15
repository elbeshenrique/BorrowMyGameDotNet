using BorrowMyGameDotNet.Modules.Core.Domain.ValueObjects;

namespace BorrowMyGameDotNet.Modules.Core.Domain.Entities
{
    public class Game
    {
        public readonly Identifier Id;
        public readonly Title Title;
        public readonly IsBorrowed IsBorrowed;

        public Game(Identifier id, Title title, IsBorrowed isBorrowed)
        {
            Id = id;
            Title = title;
            IsBorrowed = isBorrowed;
        }
    }
}