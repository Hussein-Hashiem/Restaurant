
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Restaurnat.DAL.Entities
{
    public class User : IdentityUser
    {
        public User()
        {
            
        }
        public User(string first_name, string last_name, int age, string country, string city, string street)
        {
            if (string.IsNullOrEmpty(first_name) || string.IsNullOrEmpty(last_name) || age == 0 || string.IsNullOrEmpty(country) || string.IsNullOrEmpty(city) || string.IsNullOrEmpty(street))
                throw new ArgumentException("Invalid arguments to create a User");
            this.first_name = first_name;
            this.last_name = last_name;
            this.age = age;
            this.country = country;
            this.city = city;
            this.street = street;
            this.CreatedOn = DateTime.Now;
            this.imagepath = "avatar.png";
        }
        public string first_name { get; private set; }
        public string last_name { get; private set; }
        public int age { get; private set; }
        public string country { get; private set; }
        public string city { get; private set; }
        public string street { get; private set; }
        public string? imagepath { get; private set; }
        public List<Feedback> Feedbacks { get; private set; }
        public List<Reservation> Reservations { get; private set; }
        public DateTime? CreatedOn { get; private set; }
        public string? CreatedBy { get; private set; }
        public DateTime? ModifiedOn { get; private set; }
        public string? ModifiedBy { get; private set; }
        public DateTime? DeletedOn { get; private set; }
        public string? DeletedBy { get; private set; }
        public bool? IsDeleted { get; private set; } = false;
        public bool Update(string first_name, string last_name, int age, string country, string city, string street, string imagepath)
        {
            if (string.IsNullOrEmpty(first_name) || string.IsNullOrEmpty(last_name) || age == 0 || string.IsNullOrEmpty(country) || string.IsNullOrEmpty(city) || string.IsNullOrEmpty(street)) return false;
            this.first_name = first_name;
            this.last_name = last_name;
            this.age = age;
            this.country = country;
            this.city = city;
            this.street = street;
            this.imagepath = imagepath;
            this.ModifiedOn = DateTime.Now;
            return true;
        }
    }
}
