using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using TheBank.Logic.LoanApplication;
using TheBank.TestCore.Fakes;
using TheBank.TestCore.ModelExtensions;
using TheBank.TestCore.ModelFactories;

namespace TheBank.LogicTest
{
    [TestFixture]
    public class LoanApplicationLogicTest
    {
        private FakeLoanApplicationContextFacade _fakeLoanApplicationContextFacade;
        private ILoanApplicationLogic _target;

        [SetUp]
        public void Setup()
        {
            _fakeLoanApplicationContextFacade = new FakeLoanApplicationContextFacade();
            _target = new LoanApplicationLogic(_fakeLoanApplicationContextFacade);
        }

        [Test]
        public void GetApplication_ShouldReturnModelOrNull()
        {
            const int id = 123;
            var model = LoanApplicationModelFactory.CreateBasicModel().WithId(id);
            _fakeLoanApplicationContextFacade.LoanApplicationModels.Add(model);
            _target.GetApplication(id).Should().NotBeNull();
            _target.GetApplication(123123).Should().BeNull();
        }

        [Test]
        public void CreateLoanApplication_ShouldReturnIdOfAddedModel()
        {
            const int id = 123;
            var model = LoanApplicationModelFactory.CreateBasicModel().WithId(id);
            var newModelId = _target.CreateLoanApplication(model);
            newModelId.Should().Be(id);
        }

        [Test]
        public void CreateLoanApplication_ShouldSetDecision()
        {
            const int id = 123;
            var model = LoanApplicationModelFactory.CreateBasicModel();
            var newModelId = _target.CreateLoanApplication(model);
            var createdModel = _fakeLoanApplicationContextFacade.LoanApplicationModels.SingleOrDefault(x => x.Id == newModelId);
            createdModel.Should().NotBeNull();
            createdModel.Decision.Should().NotBeNull();
        }

        [Test]
        public void CreateLoanApplication_ShouldThrowOnNull()
        {
            Assert.Throws<ArgumentNullException>( () => _target.CreateLoanApplication(null));
        }

        [Test]
        public void DeleteLoanApplication_ShouldReturnTrueIfDeleteWorked()
        {
            const int idToDelete = 123;
            var model = LoanApplicationModelFactory.CreateBasicModel().WithId(idToDelete);
            _fakeLoanApplicationContextFacade.LoanApplicationModels.Add(model);
            _fakeLoanApplicationContextFacade.LoanApplicationModels.Count().Should()
                .Be(1);
            _target.DeleteLoanApplication(idToDelete).Should().BeTrue();
            _fakeLoanApplicationContextFacade.LoanApplicationModels.Count().Should()
                .Be(0);
        }

        [Test]
        public void DeleteLoanApplication_ShouldReturnFalseIfNoModelCouldBeFound()
        {
            _target.DeleteLoanApplication(1234).Should().BeFalse();
        }

        [Test]
        public void UpdateLoanApplication_ShouldReturnIdOfUpdatedModel()
        {
            const int id = 123;
            var dbModel = LoanApplicationModelFactory.CreateBasicModelWithDecision().WithId(id);
            _fakeLoanApplicationContextFacade.LoanApplicationModels.Add(dbModel);
            var model = LoanApplicationModelFactory.CreateBasicModel().WithId(id);
            var newModelId = _target.UpdateLoanApplication(model);
            newModelId.Should().Be(id);
        }

        [Test]
        public void UpdateLoanApplication_ShouldSetDecision()
        {
            const int id = 123;
            var dbModel = LoanApplicationModelFactory.CreateBasicModelWithDecision().WithId(id);
            _fakeLoanApplicationContextFacade.LoanApplicationModels.Add(dbModel);
            var model = LoanApplicationModelFactory.CreateBasicModel().WithId(id);
            _target.UpdateLoanApplication(model);
            var createdModel = _fakeLoanApplicationContextFacade.LoanApplicationModels.SingleOrDefault(x => x.Id == id);
            createdModel.Should().NotBeNull();
            createdModel.Decision.Should().NotBeNull();
        }

        [Test]
        public void GetLoanApplicationDecision_ShouldReturnDecision()
        {
            var model = LoanApplicationModelFactory.CreateBasicModelWithDecision().WithId(123);
            _fakeLoanApplicationContextFacade.LoanApplicationModels.Add(model);
            var result = _target.GetApplicationDecision(123);
            result.Should().NotBeNull();
            result.Decision.Should().BeFalse();
        }
        

    }
}
