
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurnat.DAL.Entities
{
    public class Event
    {
        [Key]
        public int event_id { get; private set; }
        public string name { get; private set; }
        public string description { get; private set; }
        public DateTime date { get; private set; }
        public int duration { get; private set; }
        [ForeignKey("Restaurant")]
        public int restaurant_id { get; private set; }
        public Restaurant Restaurant { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public string CreatedBy { get; private set; }
        public DateTime? ModifiedOn { get; private set; }
        public string? ModifiedBy { get; private set; }
        public DateTime? DeletedOn { get; private set; }
        public string? DeletedBy { get; private set; }
        public bool IsDeleted { get; private set; } = false;
    }
}
