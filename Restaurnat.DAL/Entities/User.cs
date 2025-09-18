
using System.ComponentModel.DataAnnotations;

namespace Restaurnat.DAL.Entities
{
    public class User
    {
        [Key]
        public int user_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public int age { get; set; }
        public string phone_number { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public string street { get; set; }
        public string? imagepath { get; set; }
        public List<Feedback> Feedbacks { get; set; }
        public List<Reservation> Reservations { get; set; }
    }
}
