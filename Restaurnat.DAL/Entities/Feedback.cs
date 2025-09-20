
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurnat.DAL.Entities
{
    public class Feedback
    {
        [Key]
        public int feedback_id { get; private set; }
        [ForeignKey("User")]
        public string UserId { get; private set; }
        public User User { get; private set; }
        public int rating { get; private set; }
        public string? comment { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public string CreatedBy { get; private set; }
        public DateTime? ModifiedOn { get; private set; }
        public string? ModifiedBy { get; private set; }
        public DateTime? DeletedOn { get; private set; }
        public string? DeletedBy { get; private set; }
        public bool IsDeleted { get; private set; } = false;
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