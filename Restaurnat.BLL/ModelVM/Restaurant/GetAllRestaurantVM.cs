using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurnat.BLL.ModelVM.Restaurant
{
    public class GetAllRestaurantVM
    {
        public int restaurant_id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public int num_of_guests { get; set; }
        public bool recommended { get; set; }

    }
}
