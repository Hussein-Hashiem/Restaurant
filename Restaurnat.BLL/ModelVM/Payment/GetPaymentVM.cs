
namespace Restaurnat.BLL.ModelVM.Payment
{
    public class GetPaymentVM
    {
        public int payment_id { get; set; }
        public int reservation_id { get; set; }
        public decimal amount { get; set; }
        public DateTime payment_date { get; set; }
        public string status { get; set; }
        public string PaymentMethod { get; set; }

    }
}
