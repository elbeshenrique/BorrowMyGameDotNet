using System.Collections.Generic;
using System.Threading.Tasks;
using BorrowMyGameDotNet.Modules.Core.Domain.Entities;
using BorrowMyGameDotNet.Modules.Core.Domain.Exceptions;
using BorrowMyGameDotNet.Modules.Core.Domain.Repositories;
using BorrowMyGameDotNet.Modules.Core.Domain.Usecases;

namespace BorrowMyGameDotNet.Modules.Core.Application.Usecases
{
    public class GetAllGamesUsecase : IGetAllGamesUsecase
    {

        private readonly IGamesRepository _repository;

        public GetAllGamesUsecase(IGamesRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<Game>> Execute()
        {
            try
            {
                var games = await _repository.GetAll();
                return games;
            }
            catch (GameRepositoryException)
            {
                throw new GetAllGamesException();
            }
            catch
            {
                throw new GetAllGamesException();
            }
        }
    }
}