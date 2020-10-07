using FluentAssertions;
using NUnit.Framework;
using TheBank.Logic.LoanApplication;
using TheBank.TestCore.ModelFactories;

namespace TheBank.LogicTest
{
    [TestFixture]
    public class StandardDecisionTakerTest
    {
        [Test]
        public void ShouldImplementCorrectInterface()
        {
            typeof(StandardDecisionTaker).GetInterfaces().Should().Contain(typeof(IDecisionTaker));
        }

        [Test]
        public void TakeDecision_ShouldDenyIfMonthlyIncomeIsToLow()
        {
            var model = LoanApplicationModelFactory.CreateModelWithIncome(31000);
            var target = new StandardDecisionTaker();
            var result = target.TakeDecision(model);
            result.Decision.Should().BeFalse();
        }

        [Test]
        public void TakeDecision_ShouldApproveIfMonthlyIncomeIsGood()
        {
            var model = LoanApplicationModelFactory.CreateModelWithIncome(31001);
            var target = new StandardDecisionTaker();
            var result = target.TakeDecision(model);
            result.Decision.Should().BeTrue();
        }
    }
}
