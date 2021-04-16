using BorrowMyGameDotNet.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using BorrowMyGameDotNet.Modules.Core.Domain.Usecases;
using BorrowMyGameDotNet.Modules.Core.Domain.Entities;
using BorrowMyGameDotNet.Modules.Core.Domain.Exceptions;
using BorrowMyGameDotNet.Modules.Core.Domain.Presenters;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<ActionResult<IEnumerable<GameOutput>>> Get()
        {
            try
            {
                var gameOutputs = await _gameUsecase.GetAll();
                return Ok(gameOutputs);
            }
            catch (GameUsecaseException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GameOutput>> Get(int id)
        {
            try
            {
                var gameOutput = await _gameUsecase.Find(id);
                return Ok(gameOutput);
            }
            catch (NotFoundException exception)
            {
                return NotFound(exception.Message);
            }
            catch (GameUsecaseException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<GameOutput>> Post([FromBody] GameInput gameInput)
        {
            try
            {
                var gameOutput = await _gameUsecase.Create(gameInput);
                return StatusCode(StatusCodes.Status201Created, gameOutput);
            }
            catch (GameUsecaseException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] GameInput gameInput)
        {
            try
            {
                await _gameUsecase.Update(id, gameInput);
                return NoContent();
            }
            catch (NotFoundException exception)
            {
                return NotFound(exception.Message);
            }
            catch (GameUsecaseException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPatch("{id}/borrow")]
        public async Task<ActionResult> UpdateIsBorrowed(int id, [FromBody] bool isBorrowed)
        {
            try
            {
                await _gameUsecase.UpdateIsBorrowed(id, isBorrowed);
                return NoContent();
            }
            catch (NotFoundException exception)
            {
                return NotFound(exception.Message);
            }
            catch (GameUsecaseException exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}