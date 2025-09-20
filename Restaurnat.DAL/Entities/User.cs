
using System.ComponentModel.DataAnnotations;

namespace Restaurnat.DAL.Entities
{
    public class User
    {
        [Key]
        public int user_id { get; private set; }
        public string first_name { get; private set; }
        public string last_name { get; private set; }
        public int age { get; private set; }
        public string phone_number { get; private set; }
        public string country { get; private set; }
        public string city { get; private set; }
        public string street { get; private set; }
        public string? imagepath { get; private set; }
        public List<Feedback> Feedbacks { get; private set; }
        public List<Reservation> Reservations { get; private set; }
    }
}
