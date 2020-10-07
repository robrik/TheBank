using Microsoft.EntityFrameworkCore;
using TheBank.Domain.LoanApplication;


namespace TheBank.Data.LoanApplication
{
    public class LoanApplicationContext : DbContext
    {
        public LoanApplicationContext(DbContextOptions<LoanApplicationContext> contextOptions) : base(contextOptions)
        {
        }

        public DbSet<LoanApplicationModel> LoanApplications { get; set; }
        public DbSet<DecisionModel> Decisions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoanApplicationModel>().HasKey(model => model.Id);
            modelBuilder.Entity<DecisionModel>().HasKey(model => model.Id);
        }

    }
}
