using Restaurnat.BLL.Services.Apstraction;
using Restaurnat.DAL.Entities;
using Restaurnat.DAL.Repo.Apstraction;

namespace Restaurnat.BLL.Services.Implementation
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepo paymentRepo;

        public PaymentService(IPaymentRepo paymentRepo)
        {
            this.paymentRepo = paymentRepo;
        }

        public (bool, string) Create(Payment newPayment)
        {
            if (newPayment.amount <= 0)
                return (false, "Amount must be greater than 0");

            return paymentRepo.Create(newPayment);
        }

        public bool Delete(int id)
        {
            return paymentRepo.Delete(id);
        }

        public List<Payment> GetAll()
        {
            return paymentRepo.GetAll();
        }

        public Payment GetById(int id)
        {
            return paymentRepo.GetById(id);
        }

        public bool Update(Payment newPayment)
        {
            return paymentRepo.Update(newPayment);
        }
    }
}
