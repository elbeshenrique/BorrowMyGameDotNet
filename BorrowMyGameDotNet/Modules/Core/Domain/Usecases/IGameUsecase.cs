using System.Collections.Generic;
using System.Threading.Tasks;
using BorrowMyGameDotNet.Modules.Core.Domain.Entities;

namespace BorrowMyGameDotNet.Modules.Core.Domain.Usecases
{
    public interface IGameUsecase
    {
        IEnumerable<GameOutput> GetAll();
        GameOutput Create(GameInput gameInput);
        GameOutput Update(int id, GameInput gameInput);
    }
}