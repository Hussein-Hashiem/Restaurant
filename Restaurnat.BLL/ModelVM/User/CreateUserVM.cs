
using Microsoft.AspNetCore.Http;

namespace Restaurnat.BLL.ModelVM.User
{
    public class CreateUserVM
    {
        public string first_name { get; private set; }
        public string last_name { get; private set; }
        public int age { get; private set; }
        public string country { get; private set; }
        public string city { get; private set; }
        public string street { get; private set; }
        public IFormFile? image { get; private set; }
    }
}
