using System;
using System.Threading.Tasks;
using BorrowMyGameDotNet.Modules.Auth.Domain.Entities;
using BorrowMyGameDotNet.Modules.Auth.Domain.Exceptions;
using BorrowMyGameDotNet.Modules.Auth.Domain.Repositories;
using BorrowMyGameDotNet.Modules.Auth.Domain.Usecases;

namespace BorrowMyGameDotNet.Modules.Auth.Application.Usecases
{
    public class UserUsecase : IUserUsecase
    {
        private const string UserAuthenticationFailure = "User authentication failure.";

        private IUserRepository repository;

        public UserUsecase(IUserRepository userRepository)
        {
            this.repository = userRepository;
        }

        public async Task<User> GetAuthenticated(LoginInput loginInput)
        {
            try
            {
                var user = await repository.GetAuthenticated(loginInput);
                return user;
            }
            catch (Exception exception)
            {
                throw new UserUsecaseException(UserAuthenticationFailure, exception);
            }
        }
    }
}