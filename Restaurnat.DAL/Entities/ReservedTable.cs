
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurnat.DAL.Entities
{
    public class ReservedTable
    {
        [ForeignKey("Table")]
        public int TableId { get; private set; }
        public Table Table { get; private set; }
        [ForeignKey("Reservation")]
        public int ReservationId { get; private set; }
        public Reservation Reservation { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public string CreatedBy { get; private set; }
        public DateTime? ModifiedOn { get; private set; }
        public string? ModifiedBy { get; private set; }
        public DateTime? DeletedOn { get; private set; }
        public string? DeletedBy { get; private set; }
        public bool IsDeleted { get; private set; } = false;
    }
}
