
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurnat.DAL.Entities
{
    public class Chef
    {

        [Key]
        public int chef_id { get; private set; }
        public string name { get; private set; }
        public int age { get; private set; }
        public string about { get; private set; }
        public int categoryId { get; private set; }
        public string category { get; private set; }
        public int experience_years { get; private set; }
        public bool work_now { get; private set; }
        //public int work_status { get; private set; } // hired - fired - retired
        public string imagepath { get; private set; }
        //[ForeignKey("Restaurant")]
        public int restaurant_id { get; private set; }
        //public Restaurant Restaurant { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public string CreatedBy { get; private set; }
        public DateTime? ModifiedOn { get; private set; }
        public string? ModifiedBy { get; private set; }
        public DateTime? DeletedOn { get; private set; }
        public string? DeletedBy { get; private set; }
        public bool IsDeleted { get; private set; } = false;

        public bool EditChef(Chef chef)
        {
            if (chef != null)
            {
                name = chef.name;
                age = chef.age;
                about = chef.about;
                work_now = chef.work_now;
                category = chef.category;
                experience_years = chef.experience_years;
                imagepath = chef.imagepath;
                restaurant_id = chef.restaurant_id;
                ModifiedOn = DateTime.Now;
                ModifiedBy = "Admin";
                return true;
            }
            return false;
        }

        public bool DeleteChef(string deletedBy)
        {
            if (!IsDeleted)
            {
                IsDeleted = true;
                DeletedOn = DateTime.Now;
                DeletedBy = deletedBy;
                return true;
            }
            return false;
        }
        public bool RestoreChef()
        {
            if (IsDeleted)
            {
                IsDeleted = false;
                DeletedOn = null;
                DeletedBy = null;
                return true;
            }
            return false;
        }
    }
}
