using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using BorrowMyGameDotNet.Modules.Core.Domain.Exceptions;
using BorrowMyGameDotNet.Modules.Core.Domain.Presenters;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using BorrowMyGameDotNet.Data.Contexts;
using BorrowMyGameDotNet.Modules.Core.Domain.Usecases.Game;

namespace BorrowMyGameDotNet.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class GameController : ControllerBase
    {
        private ApplicationDbContext dbContext;
        private IGameUsecase gameUsecase;
        private IFriendPresenter gamePresenter;

        public GameController(
            ApplicationDbContext dbContext,
            IGameUsecase gameUsecase,
            IFriendPresenter gamePresenter
        )
        {
            this.dbContext = dbContext;
            this.gameUsecase = gameUsecase;
            this.gamePresenter = gamePresenter;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameOutput>>> GetAsync()
        {
            try
            {
                var gameOutputs = await gameUsecase.GetAllAsync();
                return Ok(gameOutputs);
            }
            catch (GameUsecaseException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GameOutput>> GetAsync(int id)
        {
            try
            {
                var gameOutput = await gameUsecase.FindAsync(id);
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
        public async Task<ActionResult<GameOutput>> PostAsync([FromBody] GameInput gameInput)
        {
            try
            {
                var gameOutput = await gameUsecase.CreateAsync(gameInput);
                return StatusCode(StatusCodes.Status201Created, gameOutput);
            }
            catch (GameUsecaseException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(int id, [FromBody] GameInput gameInput)
        {
            try
            {
                await gameUsecase.UpdateAsync(id, gameInput);
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
        public async Task<ActionResult> UpdateIsBorrowedAsync(int id, [FromBody] bool isBorrowed)
        {
            try
            {
                await gameUsecase.UpdateIsBorrowedAsync(id, isBorrowed);
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