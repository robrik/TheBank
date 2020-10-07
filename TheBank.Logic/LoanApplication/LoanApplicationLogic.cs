using System;
using System.Collections.Generic;
using TheBank.Data.LoanApplication;
using TheBank.Domain.LoanApplication;

namespace TheBank.Logic.LoanApplication
{
    public class LoanApplicationLogic : ILoanApplicationLogic
    {
        private readonly ILoanApplicationContextFacade _loanApplicationContextFacade;

        public LoanApplicationLogic(ILoanApplicationContextFacade loanApplicationContextFacade)
        {
            _loanApplicationContextFacade = loanApplicationContextFacade;
        }


        public IEnumerable<LoanApplicationModel> GetApplications()
        {
            return _loanApplicationContextFacade.GetAllLoanApplications();
        }


        public LoanApplicationModel GetApplication(int id)
        {
           return _loanApplicationContextFacade.GetLoanApplication(id);
        }

        public int CreateLoanApplication(LoanApplicationModel loanApplicationModel)
        {
            if (loanApplicationModel == null)
            {
                throw new ArgumentNullException();
            }

            var decisionTaker = DecisionFactory.CreateDecisionTaker(loanApplicationModel.DecisionType);
            loanApplicationModel.Decision = decisionTaker.TakeDecision(loanApplicationModel);
            return _loanApplicationContextFacade.CreateLoanApplication(loanApplicationModel);
        }

        public bool DeleteLoanApplication(int id)
        {
            return _loanApplicationContextFacade.DeleteLoanApplication(id);
        }

        public int UpdateLoanApplication(LoanApplicationModel loanApplicationModel)
        {
            if (loanApplicationModel == null)
            {
                throw new ArgumentNullException();
            }
            var decisionTaker = DecisionFactory.CreateDecisionTaker(loanApplicationModel.DecisionType);
            loanApplicationModel.Decision = decisionTaker.TakeDecision(loanApplicationModel);
            return _loanApplicationContextFacade.UpdateLoanApplication(loanApplicationModel);
        }

        public DecisionModel GetApplicationDecision(int id)
        {
            return _loanApplicationContextFacade.GetLoanApplicationDecision(id);
        }
    }
}
