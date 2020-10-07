using TheBank.Domain.LoanApplication;

namespace TheBank.Logic.LoanApplication
{
    public interface IDecisionTaker
    {
        public DecisionModel TakeDecision(LoanApplicationModel loanApplicationModel);

    }
}
