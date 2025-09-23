using AutoMapper;
using Restaurnat.BLL.ModelVM.Payment;
using Restaurnat.BLL.ModelVM.Restaurant;
using Restaurnat.BLL.Services.Apstraction;
using Restaurnat.DAL.Entities;
using Restaurnat.DAL.Repo.Apstraction;
using Restaurnat.DAL.Repo.Implementation;

namespace Restaurnat.BLL.Services.Implementation
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepo paymentRepo;
        private readonly IMapper mapper;
        public PaymentService(IPaymentRepo paymentRepo, IMapper mapper)
        {
            this.paymentRepo = paymentRepo;
            this.mapper = mapper;
        }
        

        public (bool, string) Create(CreatePaymentVM newPayment)
        {
            if (newPayment.amount <= 0)
                return (false, "Amount must be greater than 0");
            var result = mapper.Map<Payment>(newPayment);
            var re= paymentRepo.Create(result);
            return re;
        }

        public bool Delete(int id)
        {
            var result = paymentRepo.Delete(id);
            return result;
        }

        public List<GetAllPaymentVM> GetAll()
        {
            var result = paymentRepo.GetAll();
            var mapp = mapper.Map<List<GetAllPaymentVM>>(result);
            if (result.Count > 0) return (mapp);
            return null;
        }

        public GetPaymentVM GetById(int id)
        {
            var result = paymentRepo.GetById(id);
            var mapp = mapper.Map<GetPaymentVM>(result);
            return mapp;
        }

        public bool Update(UpdatePaymentVM newPayment)
        {
            var mapp = mapper.Map<Payment>(newPayment);
            var result = paymentRepo.Update(mapp);
            return result;
        }

    }
}
