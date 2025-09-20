using Restaurnat.DAL.Entities;

namespace Restaurnat.BLL.Services.Apstraction
{
    public interface IPaymentService
    {
        List<Payment> GetAll();
        Payment GetById(int id);
        (bool, string) Create(Payment newPayment);
        bool Update(Payment newPayment);
        bool Delete(int id);
    }
}
