using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurnat.BLL.ModelVM.Event
{
    public class CreateEventVM
    {
        [Required(ErrorMessage = "Name is required")]
        public string name { get; private set; }
        public string description { get; private set; }
        public DateTime date { get; private set; }
        public int duration { get; private set; }
        [ForeignKey("Restaurant")]
        public int restaurant_id { get; private set; }
        //public Restaurant Restaurant { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public string CreatedBy { get; private set; }
        public DateTime? ModifiedOn { get; private set; }
        public string? ModifiedBy { get; private set; }
        public DateTime? DeletedOn { get; private set; }
        public string? DeletedBy { get; private set; }
        public bool IsDeleted { get; private set; } = false;

    }
}
