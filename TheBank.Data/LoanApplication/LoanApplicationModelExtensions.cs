using TheBank.Domain.LoanApplication;

namespace TheBank.Data.LoanApplication
{
    public static class LoanApplicationModelExtensions
    {
        public static void UpdateEntity(this LoanApplicationModel current, LoanApplicationModel other, LoanApplicationContext context)
        {
            context.Attach(current);
            foreach (var property in typeof(LoanApplicationModel).GetProperties())
            {
                if(property.GetValue(current).Equals(property.GetValue(other)))
                    continue;

                property.SetValue(current, property.GetValue(other));
                context.Entry(current).Property(property.Name).IsModified = true;
            }
        }
    }
}