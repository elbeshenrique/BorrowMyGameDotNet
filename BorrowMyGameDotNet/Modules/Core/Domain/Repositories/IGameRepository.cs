using System.Collections.Generic;
using System.Threading.Tasks;
using BorrowMyGameDotNet.Modules.Core.Domain.Entities;

namespace BorrowMyGameDotNet.Modules.Core.Domain.Repositories
{
    public interface IGameRepository
    {
        Task<IEnumerable<Game>> GetAll();
        Task<Game> Find(int id);
        Task Create(Game game);
        Task Update(int id, Game game);
        Task UpdateIsBorrowed(Game game, bool isBorrowed);
    }
}