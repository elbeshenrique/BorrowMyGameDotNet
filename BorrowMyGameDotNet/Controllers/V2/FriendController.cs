using System.Collections.Generic;
using System.Threading.Tasks;
using BorrowMyGameDotNet.Data.Contexts;
using BorrowMyGameDotNet.Modules.Core.Domain.Exceptions;
using BorrowMyGameDotNet.Modules.Core.Domain.Presenters;
using BorrowMyGameDotNet.Modules.Core.Domain.Usecases.Friend;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BorrowMyGameDotNet.Controllers.V2
{
    [Route("api/v2/[controller]")]
    [ApiController]
    [Authorize]
    public class FriendController : ControllerBase
    {
        private ApplicationDbContext dbContext;
        private IFriendUsecase FriendUsecase;
        private IFriendPresenter FriendPresenter;

        public FriendController(
            ApplicationDbContext dbContext,
            IFriendUsecase FriendUsecase,
            IFriendPresenter FriendPresenter
        )
        {
            this.dbContext = dbContext;
            this.FriendUsecase = FriendUsecase;
            this.FriendPresenter = FriendPresenter;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FriendOutput>>> GetAsync()
        {
            try
            {
                var FriendOutputs = await FriendUsecase.GetAllAsync();
                return Ok(FriendOutputs);
            }
            catch (FriendUsecaseException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FriendOutput>> GetAsync(int id)
        {
            try
            {
                var FriendOutput = await FriendUsecase.FindAsync(id);
                return Ok(FriendOutput);
            }
            catch (NotFoundException exception)
            {
                return NotFound(exception.Message);
            }
            catch (FriendUsecaseException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<FriendOutput>> PostAsync([FromBody] FriendInput FriendInput)
        {
            try
            {
                var FriendOutput = await FriendUsecase.CreateAsync(FriendInput);
                return StatusCode(StatusCodes.Status201Created, FriendOutput);
            }
            catch (FriendUsecaseException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(int id, [FromBody] FriendInput FriendInput)
        {
            try
            {
                await FriendUsecase.UpdateAsync(id, FriendInput);
                return NoContent();
            }
            catch (NotFoundException exception)
            {
                return NotFound(exception.Message);
            }
            catch (FriendUsecaseException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                await FriendUsecase.DeleteAsync(id);
                return NoContent();
            }
            catch (NotFoundException exception)
            {
                return NotFound(exception.Message);
            }
            catch (FriendUsecaseException exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}