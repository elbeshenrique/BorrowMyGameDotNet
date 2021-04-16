using BorrowMyGameDotNet.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using BorrowMyGameDotNet.Modules.Core.Domain.Usecases;
using BorrowMyGameDotNet.Modules.Core.Domain.Entities;
using BorrowMyGameDotNet.Modules.Core.Domain.Exceptions;
using BorrowMyGameDotNet.Modules.Core.Domain.Presenters;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace BorrowMyGameDotNet.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class GameController : ControllerBase
    {
        private ApplicationDbContext dbContext;
        private IGameUsecase gameUsecase;
        private IGamePresenter gamePresenter;

        public GameController(
            ApplicationDbContext dbContext,
            IGameUsecase gameUsecase,
            IGamePresenter gamePresenter
        )
        {
            this.dbContext = dbContext;
            this.gameUsecase = gameUsecase;
            this.gamePresenter = gamePresenter;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameOutput>>> Get()
        {
            try
            {
                var gameOutputs = await gameUsecase.GetAll();
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
                var gameOutput = await gameUsecase.Find(id);
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
                var gameOutput = await gameUsecase.Create(gameInput);
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
                await gameUsecase.Update(id, gameInput);
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
                await gameUsecase.UpdateIsBorrowed(id, isBorrowed);
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