using System.Collections.Generic;
using System.Threading.Tasks;

namespace BorrowMyGameDotNet.Modules.Core.Domain.Usecases.Friend
{
    public interface IFriendUsecase
    {
        Task<IEnumerable<FriendOutput>> GetAllAsync();
        Task<FriendOutput> FindAsync(int id);
        Task<FriendOutput> CreateAsync(FriendInput friendInput);
        Task UpdateAsync(int id, FriendInput friendInput);
    }
}