
using Microsoft.AspNetCore.Http;

namespace Restaurnat.BLL.ModelVM.User
{
    public class UpdateUserVM
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public int age { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public string street { get; set; }
        public IFormFile? image { get; set; }
    }
}
