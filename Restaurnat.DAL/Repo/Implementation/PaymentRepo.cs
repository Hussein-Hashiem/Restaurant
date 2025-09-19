
using Restaurnat.DAL.Database;
using Restaurnat.DAL.Repo.Apstraction;

namespace Restaurnat.DAL.Repo.Implementation
{
    public class PaymentRepo : IPaymentRepo
    {
        private readonly ApplicationDbContext DB;

        public PaymentRepo(ApplicationDbContext DB)
        {
            this.DB = DB;
        }
    }
}
