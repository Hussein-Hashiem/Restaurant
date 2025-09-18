
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurnat.DAL.Entities
{
    public class Payment
    {
        [Key]
        public int payment_id { get; set; }
        [ForeignKey("Reservation")]
        public int reservation_id { get; set; }
        public Reservation Reservation { get; set; }
        public decimal amount { get; set; }
        public DateTime payment_date { get; set; }
        public string status { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string? DeletedBy { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
