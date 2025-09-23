using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurnat.BLL.ModelVM.Payment
{
    public class GetAllPaymentVM
    {
        public int payment_id { get; set; }
        public int reservation_id { get; set; }
        public decimal amount { get; set; }
        public DateTime payment_date { get; set; }
        public string status { get; set; }
        public string PaymentMethod { get; set; }

    }
}
