
namespace Restaurnat.BLL.ModelVM.Reservation
{
    public class EditReservationVM
    {
        public int reservation_id { get; set; }
        public DateTime reservation_date { get; set; }
        public int duration { get; set; }
        public int number_of_people { get; set; }
        public bool done { get; set; }
        public int fees { get; set; }
        public int total_money { get; set; }
    }
}
