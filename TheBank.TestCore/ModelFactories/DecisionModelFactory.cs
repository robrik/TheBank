using TheBank.Domain.LoanApplication;

namespace TheBank.TestCore.ModelFactories
{
    public class DecisionModelFactory
    {
        public static DecisionModel CreateBasicDecisionModel()
        {
            var model = new DecisionModel()
            {
                Id = 0,
                LoanApplicationModelId = 0,
                Decision = false,
                Description = ""
            };
            return model;
        }
    }
}
