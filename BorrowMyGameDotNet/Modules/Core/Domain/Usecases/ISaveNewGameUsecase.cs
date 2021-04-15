using BorrowMyGameDotNet.Modules.Core.Domain.Entities;

namespace BorrowMyGameDotNet.Modules.Core.Domain.Usecases
{
    public interface ISaveNewGameUsecase
    {
        Game Execute(GameInput gameInput);
    }
}