using TheBank.Domain.LoanApplication;

namespace TheBank.Logic.LoanApplication
{
    public class StandardDecisionTaker : IDecisionTaker
    {
        public DecisionModel TakeDecision(LoanApplicationModel loanApplicationModel)
        {
            var result = loanApplicationModel.MonthlyIncome > 31000;

            return new DecisionModel()
            {
                Decision = result,
                Description = result ? "Your income is high enough" : "Your income is to low."
            };

        }
    }
}
