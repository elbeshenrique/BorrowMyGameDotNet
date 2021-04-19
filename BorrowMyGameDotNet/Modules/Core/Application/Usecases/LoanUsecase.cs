using System;
using System.Threading.Tasks;
using BorrowMyGameDotNet.Modules.Core.Domain.Entities;
using BorrowMyGameDotNet.Modules.Core.Domain.Exceptions;
using BorrowMyGameDotNet.Modules.Core.Domain.Repositories;
using BorrowMyGameDotNet.Modules.Core.Domain.Usecases.Loan;

namespace BorrowMyGameDotNet.Modules.Core.Application.Usecases
{
    public class LoanUsecase : ILoanUsecase
    {
        private const string GameNotFoundMessage = "Game with id: {0} not found.";
        private const string FriendNotFoundMessage = "Friend with id: {0} not found.";

        private readonly ILoanRepository loanRepository;
        private readonly IGameRepository gameRepository;
        private readonly IFriendRepository friendRepository;

        public LoanUsecase(ILoanRepository loanRepository, IGameRepository gameRepository, IFriendRepository friendRepository)
        {
            this.loanRepository = loanRepository;
            this.gameRepository = gameRepository;
            this.friendRepository = friendRepository;
        }

        public async Task LoanGameToFriend(int gameId, int friendId)
        {
            var game = await GetGame(gameId);
            var friend = await GetFriend(friendId);

            if (GameIsBorrowed(game)) {
                throw new GameBorrowedException();
            }

            
        }


        public async Task RetrieveGameFromFriend(int gameId, int friendId)
        {
            throw new System.NotImplementedException();
        }

        private async Task<Game> GetGame(int gameId)
        {
            var game = await gameRepository.FindAsync(gameId);
            if (game == null)
            {
                throw new NotFoundException(String.Format(GameNotFoundMessage, gameId));
            }

            return game;
        }

        private bool GameIsBorrowed(Game game)
        {
            return game.IsBorrowed;
        }

        private async Task<Friend> GetFriend(int friendId)
        {
            var friend = await friendRepository.FindAsync(friendId);
            if (friend == null)
            {
                throw new NotFoundException(String.Format(FriendNotFoundMessage, friendId));
            }

            return friend;
        }

    }
}