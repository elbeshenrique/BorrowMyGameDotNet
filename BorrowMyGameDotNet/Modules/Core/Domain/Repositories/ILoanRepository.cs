using System.Collections.Generic;
using System.Threading.Tasks;
using BorrowMyGameDotNet.Modules.Core.Domain.Entities;

namespace BorrowMyGameDotNet.Modules.Core.Domain.Repositories
{
    public interface ILoanRepository
    {
        Task<IEnumerable<Loan>> GetAllAsync();
        Task<Loan> FindAsync(int id);
        Task<Loan> CreateAsync(Loan loan);
        Task<Loan> RetrieveAsync(Loan loan);
    }
}