using BorrowMyGameDotNet.Modules.Core.Domain.Entities;

namespace BorrowMyGameDotNet.Modules.Core.Domain.Usecases
{
    public interface ISaveNewGameUsecase
    {
        GameOutput Execute(GameInput gameInput);
    }
}