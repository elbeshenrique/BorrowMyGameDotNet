using System.Collections.Generic;
using System.Threading.Tasks;
using BorrowMyGameDotNet.Modules.Core.Domain.Entities;

namespace BorrowMyGameDotNet.Modules.Core.Domain.Repositories
{
    public interface IGamesRepository
    {
        Task<ICollection<Game>> GetAll();
    }
}