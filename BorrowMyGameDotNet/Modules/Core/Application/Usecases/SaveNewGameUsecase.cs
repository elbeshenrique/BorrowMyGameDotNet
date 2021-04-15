using BorrowMyGameDotNet.Modules.Core.Domain.Entities;
using BorrowMyGameDotNet.Modules.Core.Domain.Exceptions;
using BorrowMyGameDotNet.Modules.Core.Domain.Usecases;

namespace BorrowMyGameDotNet.Modules.Core.Application.Usecases
{
    public class SaveNewGameUsecase : ISaveNewGameUsecase
    {
        public Game Execute(GameInput gameInput)
        {
            throw new SaveNewGameException();
        }
    }
}