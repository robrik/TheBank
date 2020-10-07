using System.Collections.Generic;
using System.Linq;
using TheBank.Data.LoanApplication;
using TheBank.Domain.LoanApplication;
using TheBank.Utilities.TypeExtensions;

namespace TheBank.TestCore.Fakes
{
   public class FakeLoanApplicationContextFacade : ILoanApplicationContextFacade
    {
        public readonly List<LoanApplicationModel> LoanApplicationModels = new List<LoanApplicationModel>();

        public IEnumerable<LoanApplicationModel> GetAllLoanApplications()
        {
            return LoanApplicationModels;
        }

        public LoanApplicationModel GetLoanApplication(int id)
        {
            return LoanApplicationModels.SingleOrDefault(model => model.Id == id);
        }

        public int CreateLoanApplication(LoanApplicationModel loanApplicationModel)
        {
            LoanApplicationModels.Add(loanApplicationModel);
            return loanApplicationModel.Id;
        }

        public bool DeleteLoanApplication(int id)
        {
            var model = LoanApplicationModels.SingleOrDefault(x => x.Id == id);
            return LoanApplicationModels.Remove(model);
        }

        public int UpdateLoanApplication(LoanApplicationModel loanApplicationModel)
        {
           var modelToUpdate = LoanApplicationModels.SingleOrDefault(model => model.Id == loanApplicationModel.Id);
           if (modelToUpdate == null)
               return -1;
           modelToUpdate.UpdateChangedProperties(loanApplicationModel);
           modelToUpdate.Decision.UpdateChangedProperties(loanApplicationModel.Decision);
           return modelToUpdate.Id;
        }

        public DecisionModel GetLoanApplicationDecision(int id)
        {
            return LoanApplicationModels.SingleOrDefault(model => model.Id == id)?.Decision;
        }
    }
}
