using BorrowMyGameDotNet.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using BorrowMyGameDotNet.Modules.Core.Domain.Usecases;
using BorrowMyGameDotNet.Modules.Core.Domain.Entities;
using BorrowMyGameDotNet.Modules.Core.Domain.Exceptions;
using System;
using BorrowMyGameDotNet.Modules.Core.Domain.Presenters;
using System.Collections.Generic;

namespace BorrowMyGameDotNet.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {

        private ApplicationDbContext _dbContext;
        private ISaveNewGameUsecase _saveNewGame;
        private IGetAllGamesUsecase _getAllGames;
        private IGamePresenter _gamePresenter;

        public GameController(
            ApplicationDbContext dbContext,
            ISaveNewGameUsecase saveNewGame,
            IGetAllGamesUsecase getAllGames,
            IGamePresenter gamePresenter
        )
        {
            _dbContext = dbContext;
            _saveNewGame = saveNewGame;
            _getAllGames = getAllGames;
            _gamePresenter = gamePresenter;
        }

        [HttpGet]
        public ActionResult<IEnumerable<GameOutput>> Get()
        {
            try
            {
                var gameOutputs = _getAllGames.Execute();
                return Ok(gameOutputs);
            }
            catch (GetAllGamesException exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        [HttpPost]
        public ActionResult<GameOutput> Post([FromBody] GameInput gameInput)
        {
            try
            {
                var gameOutput = _saveNewGame.Execute(gameInput);
                return StatusCode(StatusCodes.Status201Created, gameOutput);
            }
            catch (SaveNewGameException exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        // [HttpPut]
        // public ActionResult<GameOutput> Put(int id, [FromBody] GameInput gameInput)
        // {
        //     try
        //     {
                
        //     }
        //     catch (SaveNewGameException exception)
        //     {
        //         return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
        //     }
        //     catch (Exception exception)
        //     {
        //         return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
        //     }
        // }
    }
}