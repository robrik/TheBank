using System.Linq;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using TheBank.Data.LoanApplication;
using TheBank.TestCore.ModelFactories;

namespace TheBank.DataTest
{
    [TestFixture]
    public class LoanApplicationContextFacadeTest
    {

        private LoanApplicationContextFacade _target;
        private LoanApplicationContext _context;

        [SetUp]
        public void Setup()
        {
            var builder = new DbContextOptionsBuilder<LoanApplicationContext>();
            builder.UseInMemoryDatabase("LoanApplicationContextFacade_Test");
            _context = new LoanApplicationContext(builder.Options);
            _target = new LoanApplicationContextFacade(_context);
        }

        [Test]
        public void GetAllLoanApplications_ShouldReturnAllLoanApplications()
        {
            _context.LoanApplications.Add(LoanApplicationModelFactory.CreateBasicModelWithDecision());
            _context.LoanApplications.Add(LoanApplicationModelFactory.CreateBasicModelWithDecision());
            _context.LoanApplications.Add(LoanApplicationModelFactory.CreateBasicModelWithDecision());
            _context.SaveChanges();
            _target.GetAllLoanApplications().Count().Should().Be(3);
        }

        // TODO: Build tests for the rest of the LoanApplicationContextFacade methods
    }
}
