using System.Collections.Generic;
using System.Threading.Tasks;
using BorrowMyGameDotNet.Modules.Core.Domain.Entities;

namespace BorrowMyGameDotNet.Modules.Core.Domain.Repositories
{
    public interface IGameRepository
    {
        Task<IEnumerable<Game>> GetAllAsync();
        Task<Game> FindAsync(int id);
        Task CreateAsync(Game game);
        Task UpdateAsync(int id, Game game);
        Task UpdateIsBorrowedAsync(Game game, bool isBorrowed);
        Task DeleteAsync(Game game);
    }
}