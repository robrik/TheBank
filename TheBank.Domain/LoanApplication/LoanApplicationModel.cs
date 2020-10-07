using System.Collections.Generic;
using TheBank.Utilities.TypeExtensions;

namespace TheBank.Domain.LoanApplication
{
    public class LoanApplicationModel : ICanBeUpdated
    {
        // TODO: Add validations
        public int Id { get; set; }
        public string PersonalNumber { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string Zip { get; set; }
        public string Street { get; set; }
        public string LoanAmount { get; set; }
        public string LoanDuration { get; set; }
        public int MonthlyIncome { get; set; }
        public DecisionType DecisionType { get; set; }
        public DecisionModel Decision { get; set; }

        public IEnumerable<string> PropertiesToIgnore() => new[] { nameof(PropertiesToIgnore), nameof(Id), nameof(Decision) };
    }
}
