using System.Collections.Generic;
using System.Threading.Tasks;
using BorrowMyGameDotNet.Modules.Core.Domain.Entities;

namespace BorrowMyGameDotNet.Modules.Core.Domain.Repositories
{
    public interface IFriendRepository
    {
        Task<IEnumerable<Friend>> GetAllAsync();
        Task<Friend> FindAsync(int id);
        Task CreateAsync(Friend friend);
        Task UpdateAsync(int id, Friend friend);
    }
}