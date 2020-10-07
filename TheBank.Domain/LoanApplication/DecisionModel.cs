using System.Collections.Generic;
using TheBank.Utilities.TypeExtensions;

namespace TheBank.Domain.LoanApplication
{
    public class DecisionModel : ICanBeUpdated
    {
        public int Id { get; set; }
        public int LoanApplicationModelId { get; set; }
        public string Description { get; set; }
        public bool Decision { get; set; }

        public IEnumerable<string> PropertiesToIgnore() => new []{nameof(PropertiesToIgnore), nameof(Id), nameof(LoanApplicationModelId)};
    }
}
