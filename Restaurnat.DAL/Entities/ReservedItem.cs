
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurnat.DAL.Entities
{
    public class ReservedItem
    {
        [ForeignKey("Item")]
        public int ItemId { get; private set; }
        public Item Item { get; private set; }
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
        public bool Update(int itemId, int reservationId)
        {
            if (itemId == 0 || reservationId == 0) return false;

            this.ItemId = itemId;
            this.ReservationId = reservationId;
            this.ModifiedOn = DateTime.Now;

            return true;
        }
    }
}
