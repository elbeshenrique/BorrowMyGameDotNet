using System.Collections.Generic;
using System.Threading.Tasks;
using BorrowMyGameDotNet.Modules.Core.Domain.Entities;

namespace BorrowMyGameDotNet.Modules.Core.Domain.Usecases
{
    public interface IGameUsecase
    {
        Task<IEnumerable<GameOutput>> GetAllAsync();
        Task<GameOutput> FindAsync(int id);
        Task<GameOutput> CreateAsync(GameInput gameInput);
        Task UpdateAsync(int id, GameInput gameInput);
        Task UpdateIsBorrowedAsync(int id, bool isBorrowed);
    }
}