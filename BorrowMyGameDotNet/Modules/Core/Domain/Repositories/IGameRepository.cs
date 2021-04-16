using System.Collections.Generic;
using BorrowMyGameDotNet.Modules.Core.Domain.Entities;

namespace BorrowMyGameDotNet.Modules.Core.Domain.Repositories
{
    public interface IGameRepository
    {
        IEnumerable<Game> GetAll();
        Game Find(int id);
        void Create(Game game);
        void Update(int id, Game game);
    }
}