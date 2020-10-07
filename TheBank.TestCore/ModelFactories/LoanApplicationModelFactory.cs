using TheBank.Domain.LoanApplication;

namespace TheBank.TestCore.ModelFactories
{
   public class LoanApplicationModelFactory
    {


        public static LoanApplicationModel CreateBasicModel()
        {
            var model = new LoanApplicationModel
            {
                Address = "",
                DecisionType = DecisionType.Standard,
                FirstName = "",
                Id = 0,
                Lastname = "",
                LoanAmount = "",
                LoanDuration = "",
                MonthlyIncome = 123,
                PersonalNumber = "",
                Street = "",
                Zip = "",
            };
            return model;
        }

        public static LoanApplicationModel CreateBasicModelWithDecision()
        {
            var model = CreateBasicModel();
            model.Decision = DecisionModelFactory.CreateBasicDecisionModel();
            return model;
        }


        public static LoanApplicationModel CreateModelWithIncome(int income)
        {
            var model = CreateBasicModel();
            model.MonthlyIncome = income;
            return model;
        }

        


    }
}
