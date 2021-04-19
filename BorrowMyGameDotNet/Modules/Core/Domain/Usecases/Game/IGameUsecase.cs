using System.Collections.Generic;
using System.Threading.Tasks;

namespace BorrowMyGameDotNet.Modules.Core.Domain.Usecases.Game
{
    public interface IGameUsecase
    {
        Task<IEnumerable<GameOutput>> GetAllAsync();
        Task<GameOutput> FindAsync(int id);
        Task<GameOutput> CreateAsync(GameInput gameInput);
        Task UpdateAsync(int id, GameInput gameInput);
        Task UpdateIsBorrowedAsync(int id, bool isBorrowed);
        Task DeleteAsync(int id);
    }
}