using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurnat.BLL.ModelVM.Chef
{
    public class GetChefVM
    {
        public int chef_id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public string about { get; set; }
        public int categoryId { get; set; }
        public string category { get; set; }
        public int experience_years { get; set; }
        public bool work_now { get; set; }
        //public int work_status { get; private set; } // hired - fired - retired
        public string imagepath { get; set; }
        public int restaurant_id { get; set; }
        //public Restaurant Restaurant { get; private set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public bool IsDeleted { get; set; } = false;


    }
}
