
namespace Restaurnat.BLL.ModelVM.Payment
{
    public class UpdatePaymentVM
    {
        public int payment_id { get; set; }
        public decimal amount { get; set; }
        public string status { get; set; }
        public string PaymentMethod { get; set; }

    }
}
