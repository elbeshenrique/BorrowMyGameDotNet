using System.Threading.Tasks;
using BorrowMyGameDotNet.Modules.Auth.Domain.Entities;

namespace BorrowMyGameDotNet.Modules.Auth.Domain.Usecases
{
    public interface IUserUsecase
    {
        Task<User> GetAuthenticatedAsync(LoginInput loginInput);
    }
}