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
        private const string UserAuthenticationFailureMessage = "User authentication failure.";
        private const string InvalidCredentialsMessage = "Invalid credentials.";
        private const string InvalidInputMessage = "Invalid login input.";

        private IUserRepository repository;

        public UserUsecase(IUserRepository userRepository)
        {
            this.repository = userRepository;
        }

        public async Task<User> GetAuthenticated(LoginInput loginInput)
        {
            if (loginInput == null)
            {
                throw new InvalidInputException(InvalidInputMessage);
            }

            var user = await repository.Get(loginInput.Email);
            if (user == null)
            {
                return null;
            }

            if (user.Password != loginInput.Password)
            {
                throw new InvalidCredentialsException(InvalidCredentialsMessage);
            }

            return user;
        }
    }
}