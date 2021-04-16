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
        private IGameUsecase _gameUsecase;
        private IGamePresenter _gamePresenter;

        public GameController(
            ApplicationDbContext dbContext,
            IGameUsecase gameUsecase,
            IGamePresenter gamePresenter
        )
        {
            _dbContext = dbContext;
            _gameUsecase = gameUsecase;
            _gamePresenter = gamePresenter;
        }

        [HttpGet]
        public ActionResult<IEnumerable<GameOutput>> Get()
        {
            try
            {
                var gameOutputs = _gameUsecase.GetAll();
                return Ok(gameOutputs);
            }
            catch (GameUsecaseException exception)
            {
                return BadRequest(exception.Message);
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
                var gameOutput = _gameUsecase.Create(gameInput);
                return StatusCode(StatusCodes.Status201Created, gameOutput);
            }
            catch (GameUsecaseException exception)
            {
                return BadRequest(exception.Message);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<GameOutput> Put(int id, [FromBody] GameInput gameInput)
        {
            try
            {
                var gameOutput = _gameUsecase.Update(id, gameInput);
                return StatusCode(StatusCodes.Status200OK, gameOutput);
            }
            catch (GameUsecaseException exception)
            {
                return BadRequest(exception.Message);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }
    }
}