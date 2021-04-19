using System.Collections.Generic;
using BorrowMyGameDotNet.Modules.Core.Domain.Entities;
using BorrowMyGameDotNet.Modules.Core.Domain.Usecases.Friend;
using BorrowMyGameDotNet.Modules.Core.Domain.Usecases.Game;

namespace BorrowMyGameDotNet.Modules.Core.Domain.Presenters
{
    public interface ILoanPresenter
    {
        LoanOutput ToOutput(Loan loan);
        IEnumerable<LoanOutput> ToOutputs(IEnumerable<Loan> loans);
    }
}