
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurnat.DAL.Entities
{
    public class Payment
    {
        [Key]
        public int payment_id { get; private set; }
        [ForeignKey("Reservation")]
        public int reservation_id { get; private set; }
        public Reservation Reservation { get; private set; }
        public decimal amount { get; private set; }
        public DateTime payment_date { get; private set; }
        public string status { get; private set; }
        public string PaymentMethod { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public string CreatedBy { get; private set; }
        public DateTime? ModifiedOn { get; private set; }
        public string? ModifiedBy { get; private set; }
        public DateTime? DeletedOn { get; private set; }
        public string? DeletedBy { get; private set; }
        public bool IsDeleted { get; private set; } = false;
    }
}
