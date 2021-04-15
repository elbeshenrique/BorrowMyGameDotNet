using System;
using System.Collections.Generic;
using BorrowMyGameDotNet.Modules.Core.Application.Usecases;
using BorrowMyGameDotNet.Modules.Core.Domain.Entities;
using BorrowMyGameDotNet.Modules.Core.Domain.Exceptions;
using BorrowMyGameDotNet.Modules.Core.Domain.Presenters;
using BorrowMyGameDotNet.Modules.Core.Domain.Repositories;
using Moq;
using Xunit;

namespace BorrowMyGameDotNet.Tests.Modules.Core.Application.Usecases
{
    public class GetAllGamesUseCaseTests
    {
        [Fact]
        public void GetAll_ShouldWork()
        {
            var gameOutputs = new List<GameOutput> {
                new GameOutput(1, "Half-Life 3", false),
                new GameOutput(2, "Age of Empires 2", true),
                new GameOutput(3, "Warcraft 3", false)
            };

            var gameRepositoryMock = new Mock<IGameRepository>();
            gameRepositoryMock
                .Setup(repository => repository.GetAll())
                .Returns(new List<Game>());

            var gamePresenterMock = new Mock<IGamePresenter>();
            gamePresenterMock
                .Setup(presenter => presenter.ToOutputs(It.IsAny<IEnumerable<Game>>()))
                .Returns(gameOutputs);

            var getAllGames = new GetAllGamesUsecase(gameRepositoryMock.Object, gamePresenterMock.Object);
            var getAllGamesResult = getAllGames.Execute();

            Assert.Equal(getAllGamesResult, gameOutputs);
        }

        [Fact]
        public void GetAll_RepositoryErrorShouldFail()
        {
            var gameRepositoryMock = new Mock<IGameRepository>();
            gameRepositoryMock
                .Setup(repository => repository.GetAll())
                .Throws<GameRepositoryException>();

            var gamePresenterMock = new Mock<IGamePresenter>();

            Assert.Throws<GetAllGamesException>(() =>
            {
                var getAllGames = new GetAllGamesUsecase(gameRepositoryMock.Object, gamePresenterMock.Object);
                var games = getAllGames.Execute();
            });
        }

        [Fact]
        public void GetAll_PresenterErrorShouldFail()
        {
            var gameRepositoryMock = new Mock<IGameRepository>();
            
            var gamePresenterMock = new Mock<IGamePresenter>();
            gamePresenterMock
                .Setup(presenter => presenter.ToOutputs(It.IsAny<IEnumerable<Game>>()))
                .Throws<Exception>();

            Assert.Throws<GetAllGamesException>(() =>
            {
                var getAllGames = new GetAllGamesUsecase(gameRepositoryMock.Object, gamePresenterMock.Object);
                var games = getAllGames.Execute();
            });
        }
    }
}