using System.Collections.Generic;
using TheBank.Domain.LoanApplication;

namespace TheBank.Logic.LoanApplication
{
    public interface ILoanApplicationLogic
    {
        public IEnumerable<LoanApplicationModel> GetApplications();
        public LoanApplicationModel GetApplication(int id);
        public int CreateLoanApplication(LoanApplicationModel loanApplicationModel);
        public bool DeleteLoanApplication(int id);
        public int UpdateLoanApplication(LoanApplicationModel loanApplicationModel);
        public DecisionModel GetApplicationDecision(int id);
    }
}
