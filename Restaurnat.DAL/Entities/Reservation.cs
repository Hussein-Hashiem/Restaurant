
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurnat.DAL.Entities
{
    public class Reservation
    {
        [Key]
        public int reservation_id { get; set; }
        public DateTime reservation_date { get; set; }
        public int duration { get; set; }
        public int number_of_people { get; set; }
        public bool done { get; set; }
        public int fees { get; set; }
        public int total_money { get; set; }
        [ForeignKey("Feedback")]
        public int? feedback_id { get; set; }
        public Feedback Feedback { get; set; }
        [ForeignKey("User")]
        public int user_id { get; set; }
        public User User { get; set; }
        public List<ReservedTable> ReservedTables { get; set; }
        public List<ReservedItem> ReservedItems { get; set; }
        public Payment Payment { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string? DeletedBy { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
