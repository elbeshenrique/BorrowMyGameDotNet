using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BorrowMyGameDotNet.Modules.Core.Domain.Entities;
using BorrowMyGameDotNet.Modules.Core.Domain.Exceptions;
using BorrowMyGameDotNet.Modules.Core.Domain.Presenters;
using BorrowMyGameDotNet.Modules.Core.Domain.Repositories;
using BorrowMyGameDotNet.Modules.Core.Domain.Usecases.Friend;

namespace BorrowMyGameDotNet.Modules.Core.Application.Usecases
{
    public class FriendUsecase : IFriendUsecase
    {
        private const string FailureGettingFriendDataMessage = "Failure on getting friend data.";
        private const string FailureCreatingFriendDataMessage = "Failure on creating friend data.";
        private const string FailureUpdatingFriendDataMessage = "Failure on updating friend data.";
        private const string FriendNotFoundMessage = "Friend with id: {0} not found.";
        private const string InvalidFriendInputMessage = "Invalid friend input.";
        private const string EmptyFriendNameMessage = "Friend name cannot be empty.";

        private readonly IFriendRepository repository;
        private readonly IFriendPresenter presenter;

        public FriendUsecase(IFriendRepository repository, IFriendPresenter presenter)
        {
            this.repository = repository;
            this.presenter = presenter;
        }

        public async Task<IEnumerable<FriendOutput>> GetAllAsync()
        {
            try
            {
                var friends = await repository.GetAllAsync();
                var friendOutputs = presenter.ToOutputs(friends);
                return friendOutputs;
            }
            catch (Exception exception)
            {
                throw new FriendUsecaseException(FailureGettingFriendDataMessage, exception);
            }
        }

        public async Task<FriendOutput> FindAsync(int id)
        {
            try
            {
                var friend = await repository.FindAsync(id);
                if (friend == null)
                {
                    throw new NotFoundException(String.Format(FriendNotFoundMessage, id));
                }

                var friendOutput = presenter.ToOutput(friend);
                return friendOutput;
            }
            catch (NotFoundException)
            {
                throw;
            }
            catch (Exception exception)
            {
                throw new FriendUsecaseException(FailureCreatingFriendDataMessage, exception);
            }
        }

        public async Task<FriendOutput> CreateAsync(FriendInput friendInput)
        {
            try
            {
                ValidateFriendInput(friendInput);

                var friend = new Friend
                {
                    Name = friendInput.Name
                };

                await repository.CreateAsync(friend);
                var friendOutput = presenter.ToOutput(friend);
                return friendOutput;
            }
            catch (Exception exception)
            {
                throw new FriendUsecaseException(FailureCreatingFriendDataMessage, exception);
            }
        }

        public async Task UpdateAsync(int id, FriendInput friendInput)
        {
            try
            {
                ValidateFriendInput(friendInput);

                var friend = await repository.FindAsync(id);
                if (friend == null)
                {
                    throw new NotFoundException(String.Format(FriendNotFoundMessage, id));
                }

                friend.Name = friendInput.Name;
                await repository.UpdateAsync(id, friend);
            }
            catch (Exception exception)
            {
                throw new FriendUsecaseException(FailureUpdatingFriendDataMessage, exception);
            }
        }

        private void ValidateFriendInput(FriendInput friendInput)
        {
            if (friendInput == null)
            {
                throw new InvalidInputException(InvalidFriendInputMessage);
            }

            if (String.IsNullOrEmpty(friendInput.Name))
            {
                throw new InvalidInputException(EmptyFriendNameMessage);
            }
        }

    }
}