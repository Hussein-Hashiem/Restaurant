
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurnat.DAL.Entities
{
    public class ReservedTable
    {
        [ForeignKey("Table")]
        public int TableId { get;  set; }
        public Table Table { get; private set; }
        [ForeignKey("Reservation")]
        public int ReservationId { get; set; }
        public Reservation Reservation { get;  set; }
        public DateTime? CreatedOn { get;  set; }
        public string? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get;  set; }
        public string? ModifiedBy { get; set; }
        public DateTime? DeletedOn { get;  set; }
        public string? DeletedBy { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
