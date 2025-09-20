
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Restaurnat.DAL.Entities
{
    public class User : IdentityUser
    {
        public string first_name { get; private set; }
        public string last_name { get; private set; }
        public int age { get; private set; }
        public string country { get; private set; }
        public string city { get; private set; }
        public string street { get; private set; }
        public string? imagepath { get; private set; }
        public List<Feedback> Feedbacks { get; private set; }
        public List<Reservation> Reservations { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public string CreatedBy { get; private set; }
        public DateTime? ModifiedOn { get; private set; }
        public string? ModifiedBy { get; private set; }
        public DateTime? DeletedOn { get; private set; }
        public string? DeletedBy { get; private set; }
        public bool IsDeleted { get; private set; } = false;
    }
}
