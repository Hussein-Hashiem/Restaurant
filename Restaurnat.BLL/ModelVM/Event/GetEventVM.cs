using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurnat.BLL.ModelVM.Event
{
    public class GetEventVM
    {
        public int event_id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTime date { get; set; }
        public int duration { get; set; }
        public int restaurant_id { get; set; }
        //public Restaurant Restaurant { get; private set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
