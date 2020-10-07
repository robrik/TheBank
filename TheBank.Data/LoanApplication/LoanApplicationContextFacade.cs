using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TheBank.Domain.LoanApplication;
using TheBank.Utilities.TypeExtensions;

namespace TheBank.Data.LoanApplication
{
    public class LoanApplicationContextFacade : ILoanApplicationContextFacade
    {
        private readonly LoanApplicationContext _loanApplicationContext;

        public LoanApplicationContextFacade(LoanApplicationContext loanApplicationContext)
        {
            _loanApplicationContext = loanApplicationContext;
        }

        public IEnumerable<LoanApplicationModel> GetAllLoanApplications()
        {
            return _loanApplicationContext.LoanApplications.Include(model => model.Decision).ToList();
        }

        public LoanApplicationModel GetLoanApplication(int id)
        {
            return _loanApplicationContext.LoanApplications
                .Include(application => application.Decision)
                .SingleOrDefault(application => application.Id == id);
        }

        public int CreateLoanApplication(LoanApplicationModel loanApplicationModel)
        {
           _loanApplicationContext.LoanApplications.Add(loanApplicationModel);
           _loanApplicationContext.SaveChanges();
           return loanApplicationModel.Id;
        }

        public bool DeleteLoanApplication(int id)
        {
            var application = _loanApplicationContext.LoanApplications.Find(id);
            if (application == null)
            {
                return false;
            }
            _loanApplicationContext.Remove(application);
            _loanApplicationContext.SaveChanges();
            return true;
        }

        public int UpdateLoanApplication(LoanApplicationModel loanApplicationModel)
        { 
            var modelFromDb = _loanApplicationContext.LoanApplications
                .Include(model => model.Decision)
                .FirstOrDefault(model => model.Id == loanApplicationModel.Id);
            if (modelFromDb == null)
                return -1;
         
            _loanApplicationContext.LoanApplications.Update(modelFromDb);
            modelFromDb.UpdateChangedProperties(loanApplicationModel);
            modelFromDb.Decision.UpdateChangedProperties(loanApplicationModel.Decision);
            _loanApplicationContext.SaveChanges();
            return modelFromDb.Id;
        }

        public DecisionModel GetLoanApplicationDecision(int id)
        {
            return _loanApplicationContext.Decisions.SingleOrDefault(x => x.LoanApplicationModelId == id);
        }
    }
}
