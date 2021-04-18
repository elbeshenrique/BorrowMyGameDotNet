using System.Threading.Tasks;
using BorrowMyGameDotNet.Modules.Auth.Domain.Entities;

namespace BorrowMyGameDotNet.Modules.Auth.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetAsync(string email);
    }
}