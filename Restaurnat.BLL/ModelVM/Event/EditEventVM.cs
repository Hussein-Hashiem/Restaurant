using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurnat.BLL.ModelVM.Event
{
    public class EditEventVM
    {
        public int event_id { get; set; }
        [Required(ErrorMessage = "Event Name is required")]
        [MinLength(3)]
        public string name { get; set; }

        [Required(ErrorMessage = "Event Description is required")]
        [MinLength(10)]
        public string description { get; set; }
        [Required(ErrorMessage = "Event Date is required")]
        public DateTime date { get; set; }
        [Required(ErrorMessage = "Should add Duartion -in minutes- for Event")]
        [Range(30, 180, ErrorMessage = "Should be minimum 30 min & max 180 min")]
        public int duration { get; set; }

        [Range(0, 100)]
        public int restaurant_id { get; set; }
    }
}
