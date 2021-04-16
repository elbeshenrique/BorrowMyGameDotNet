using System.Collections.Generic;
using System.Threading.Tasks;
using BorrowMyGameDotNet.Modules.Core.Domain.Entities;

namespace BorrowMyGameDotNet.Modules.Core.Domain.Usecases
{
    public interface IGameUsecase
    {
        Task<IEnumerable<GameOutput>> GetAll();
        Task<GameOutput> Find(int id);
        Task<GameOutput> Create(GameInput gameInput);
        Task Update(int id, GameInput gameInput);
        Task UpdateIsBorrowed(int id, bool isBorrowed);
    }
}