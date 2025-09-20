using Restaurnat.DAL.Entities;

namespace Restaurnat.DAL.Repo.Apstraction
{
    public interface IPaymentRepo
    {
        List<Payment> GetAll();
        Payment GetById(int id);
        (bool, string) Create(Payment newPayment);
        bool Update(Payment newPayment);
        bool Delete(int id);
    }
}
