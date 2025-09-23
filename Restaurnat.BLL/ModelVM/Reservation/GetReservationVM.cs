
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurnat.BLL.ModelVM.Reservation
{
    public class GetReservationVM
    {
        public DateTime reservation_date { get; set; }
        public int duration { get; set; }
        public int number_of_people { get; set; }
        public bool done { get; set; }
        public int fees { get; set; }
        public int total_money { get; set; }
        public int? feedback_id { get; set; }
        public string user_id { get; set; }
    }
}
