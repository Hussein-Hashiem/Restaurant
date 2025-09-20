
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurnat.DAL.Entities
{
    public class Reservation
    {
        [Key]
        public int reservation_id { get; private set; }
        public DateTime reservation_date { get; private set; }
        public int duration { get; private set; }
        public int number_of_people { get; private set; }
        public bool done { get; private set; }
        public int fees { get; private set; }
        public int total_money { get; private set; }
        [ForeignKey("Feedback")]
        public int? feedback_id { get; private set; }
        public Feedback Feedback { get; private set; }
        [ForeignKey("User")]
        public string user_id { get; private set; }
        public User User { get; private set; }
        public List<ReservedTable> ReservedTables { get; private set; }
        public List<ReservedItem> ReservedItems { get; private set; }
        public Payment Payment { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public string CreatedBy { get; private set; }
        public DateTime? ModifiedOn { get; private set; }
        public string? ModifiedBy { get; private set; }
        public DateTime? DeletedOn { get; private set; }
        public string? DeletedBy { get; private set; }
        public bool IsDeleted { get; private set; } = false;
    }
}
