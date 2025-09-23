using Restaurnat.BLL.ModelVM.Payment;
using Restaurnat.DAL.Entities;

namespace Restaurnat.BLL.Services.Apstraction
{
    public interface IPaymentService
    {
        List<GetAllPaymentVM> GetAll();
        GetPaymentVM GetById(int id);
        (bool, string) Create(CreatePaymentVM newPayment);
        bool Update(UpdatePaymentVM newPayment);
        bool Delete(int id);
    }
}
