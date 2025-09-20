using Restaurnat.DAL.Database;
using Restaurnat.DAL.Entities;
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

        public (bool, string) Create(Payment newPayment)
        {
            try
            {
                if (newPayment.amount <= 0) return (false, "Amount must be greater than 0");
                DB.Payments.Add(newPayment);
                DB.SaveChanges();
                return (true, "Payment Created Successfully");
            }
            catch (Exception ex) { return (false, ex.Message); }
        }

        public bool Delete(int id)
        {
            try
            {
                var result = DB.Payments.Where(p => p.payment_id == id).FirstOrDefault();
                if (result == null) return false;
                DB.Payments.Remove(result);
                DB.SaveChanges();
                return true;
            }
            catch (Exception) { throw; }
        }

        public List<Payment> GetAll()
        {
            try
            {
                var result = DB.Payments.ToList();
                return result;
            }
            catch (Exception) { throw; }
        }

        public Payment GetById(int id)
        {
            try
            {
                var result = DB.Payments.Where(p => p.payment_id == id).FirstOrDefault();
                return result;
            }
            catch (Exception) { throw; }
        }

        public bool Update(Payment newPayment)
        {
            try
            {
                var result = DB.Payments.Where(p => p.payment_id == newPayment.payment_id).FirstOrDefault();
                if (result == null) return false;

                result.Update(
                    newPayment.amount,
                    newPayment.payment_date,
                    newPayment.status,
                    newPayment.PaymentMethod,
                    newPayment.ModifiedBy
                );

                DB.SaveChanges();
                return true;
            }
            catch (Exception) { throw; }
        }
    }
}
