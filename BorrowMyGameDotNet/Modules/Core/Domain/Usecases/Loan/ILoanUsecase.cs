using System.Threading.Tasks;

namespace BorrowMyGameDotNet.Modules.Core.Domain.Usecases.Loan
{
    public interface ILoanUsecase
    {
        Task LoanGameToFriend(int gameId, int friendId);
        Task RetrieveGameFromFriend(int gameId, int friendId);
    }
}