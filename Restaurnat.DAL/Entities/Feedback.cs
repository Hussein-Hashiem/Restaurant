
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurnat.DAL.Entities
{
    public class Feedback
    {
        [Key]
        public int feedback_id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
        public int rating { get; set; }
        public string? comment { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string? DeletedBy { get; set; }
        public bool IsDeleted { get; set; } = false;
        public bool Update(int rating, string comment, string ModifiedBy)
        {
            if (rating == 0 || string.IsNullOrEmpty(ModifiedBy)) return false;
            this.rating = rating;
            this.comment = comment;
            this.ModifiedBy = ModifiedBy;
            this.ModifiedOn = DateTime.Now;
            return true;
        }
    }
}