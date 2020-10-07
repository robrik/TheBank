using System.Collections.Generic;
using TheBank.Domain.LoanApplication;

namespace TheBank.Data.LoanApplication
{
    public interface ILoanApplicationContextFacade
    {
        IEnumerable<LoanApplicationModel> GetAllLoanApplications();
        LoanApplicationModel GetLoanApplication(int id);
        int CreateLoanApplication(LoanApplicationModel loanApplicationModel);
        bool DeleteLoanApplication(int id);
        int UpdateLoanApplication(LoanApplicationModel loanApplicationModel);
        DecisionModel GetLoanApplicationDecision(int id);
    }
}
