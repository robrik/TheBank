using System;
using TheBank.Domain.LoanApplication;

namespace TheBank.Logic.LoanApplication
{
    public class DecisionFactory
    {
        public static IDecisionTaker CreateDecisionTaker(DecisionType decisionType)
        {
            return decisionType switch
            {
                DecisionType.Standard => new StandardDecisionTaker(),
                _ => throw new NotImplementedException()
            };
        }
    }
}
