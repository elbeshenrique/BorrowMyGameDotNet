using System.Collections.Generic;
using BorrowMyGameDotNet.Modules.Core.Domain.Entities;

namespace BorrowMyGameDotNet.Modules.Core.Domain.Repositories
{
    public interface IGameRepository
    {
        IEnumerable<Game> GetAll();
        void Create(Game game);
    }
}