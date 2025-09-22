using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurnat.BLL.ModelVM.Chef
{
    public class EditChefVM
    {
        public int chef_id { get;  set; }

        [Required(ErrorMessage = "Name is required")]
        public string name { get; set; }

        [Required(ErrorMessage = "Age is required, range between 20-80")]
        [Range(20, 80)]
        public string age { get; set; }

        [Required(ErrorMessage = "Write a short paragraph about the chef")]
        public string about { get; set; }

        [Required(ErrorMessage = "Category is required")]
        [Range(-1, 100)] //if -1 this means he is still training
        public int categoryId { get; set; }
        public string category { get; set; } //training = general || in specific category -> hardcoded

        [Required(ErrorMessage = "Years of Experience is required, Ebherna yaa chef")]
        [Range(0, 100)]
        public int experience_years { get; set; } // if 0 he is training by default 
        public bool work_now { get; set; } // later will be enum

        [Required(ErrorMessage = "Image is required")]
        public string imagepath { get; set; }

        [Required(ErrorMessage = "Should belong to the restaurant")]
        [Range(0, 100)]
        public int restaurant_id { get; set; }
    }
}
