using TheBank.Domain.LoanApplication;

namespace TheBank.TestCore.ModelExtensions
{
    public static class LoanApplicationModelExtensions
    {

        public static LoanApplicationModel WithId(this LoanApplicationModel model, int id)
        {
            model.Id = id;
            return model;
        }





    }
}
