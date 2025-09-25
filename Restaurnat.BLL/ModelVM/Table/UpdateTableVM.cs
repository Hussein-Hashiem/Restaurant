using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurnat.BLL.ModelVM.Table
{
    public class UpdateTableVM
    {
        public string name { get; private set; }
        public string Description { get; private set; }
        public int num_of_items { get; private set; }
        public int restaurant_id { get; private set; }
    }
}
