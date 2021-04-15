using BorrowMyGameDotNet.Data;
using Microsoft.AspNetCore.Mvc;
using BorrowMyGameDotNet.Core.Domain.Adapters.Presenters;
using Microsoft.AspNetCore.Http;
using BorrowMyGameDotNet.Modules.Core.Domain.Usecases;
using BorrowMyGameDotNet.Modules.Core.Domain.Entities;
using BorrowMyGameDotNet.Modules.Core.Domain.Exceptions;
using System;

namespace BorrowMyGameDotNet.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {

        private ApplicationDbContext _dbContext;
        private ISaveNewGameUsecase _saveNewGame;
        private IGamePresenter _gamePresenter;

        public GameController(ApplicationDbContext dbContext, ISaveNewGameUsecase saveNewGame, IGamePresenter gamePresenter)
        {
            _dbContext = dbContext;
            _saveNewGame = saveNewGame;
            _gamePresenter = gamePresenter;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("GET ok");
        }

        [HttpPost]
        public IActionResult Post([FromBody] GameInput gameInput)
        {
            try
            {
                var game = _saveNewGame.Execute(gameInput);
                var gameOutput = _gamePresenter.ToOutput(game);
                return Ok(gameOutput);
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
    }
}