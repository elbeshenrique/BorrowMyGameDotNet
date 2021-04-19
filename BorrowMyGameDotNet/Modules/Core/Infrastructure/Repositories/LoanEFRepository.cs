using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BorrowMyGameDotNet.Data.Contexts;
using BorrowMyGameDotNet.Modules.Core.Domain.Entities;
using BorrowMyGameDotNet.Modules.Core.Domain.Exceptions;
using BorrowMyGameDotNet.Modules.Core.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BorrowMyGameDotNet.Modules.Core.Infrastructure.Repositories
{
    public class LoanEFRepository : ILoanRepository
    {
        private ApplicationDbContext dbContext;

        public LoanEFRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Loan>> GetAllAsync()
        {
            try
            {
                var loans = await dbContext.Loans.ToListAsync();
                return loans;
            }
            catch (Exception exception)
            {
                throw new LoanRepositoryException(exception);
            }
        }

        public async Task<Loan> FindAsync(int id)
        {
            try
            {
                var loan = await dbContext.Loans.FindAsync(id);
                return loan;
            }
            catch (Exception exception)
            {
                throw new LoanRepositoryException(exception);
            }
        }

        public async Task<Loan> CreateAsync(Loan loan)
        {
            try
            {
                dbContext.Loans.Add(loan);
                await dbContext.SaveChangesAsync();
                return loan;
            }
            catch (Exception exception)
            {
                throw new LoanRepositoryException(exception);
            }
        }

        public async Task<Loan> RetrieveAsync(Loan loan)
        {
            try
            {
                var retrievedAtProperty = dbContext.Entry(loan).Property(l => l.RetrievedAt);
                retrievedAtProperty.IsModified = true;

                await dbContext.SaveChangesAsync();
                return loan;
            }
            catch (Exception exception)
            {
                throw new LoanRepositoryException(exception);
            }
        }
    }
}