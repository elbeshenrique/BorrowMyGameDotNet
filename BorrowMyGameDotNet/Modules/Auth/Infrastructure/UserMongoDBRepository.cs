using System.Threading.Tasks;
using BorrowMyGameDotNet.Modules.Auth.Domain.Entities;
using BorrowMyGameDotNet.Modules.Auth.Domain.Repositories;

namespace BorrowMyGameDotNet.Modules.Auth.Infrastructure
{
    public class UserMongoDBRepository : IUserRepository
    {
        public async Task<User> GetAuthenticated(LoginInput loginInput)
        {
            await Task.Yield();
            return new User(1, "elbesh@gmail.com", "123", "Admin");
        }
    }
}