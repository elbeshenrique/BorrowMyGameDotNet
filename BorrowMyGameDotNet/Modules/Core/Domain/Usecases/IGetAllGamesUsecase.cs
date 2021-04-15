using System.Collections.Generic;
using System.Threading.Tasks;
using BorrowMyGameDotNet.Modules.Core.Domain.Entities;

namespace BorrowMyGameDotNet.Modules.Core.Domain.Usecases
{
    public interface IGetAllGamesUsecase
    {
        IEnumerable<GameOutput> Execute();
    }
}