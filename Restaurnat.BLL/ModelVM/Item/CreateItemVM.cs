
using Microsoft.AspNetCore.Http;

namespace Restaurnat.BLL.ModelVM.Item
{
    public class CreateItemVM
    {
        public string name { get; set; }
        public decimal price { get; set; }
        public string description { get; set; }
        public IFormFile image { get; set; }
        public int menu_id { get; set; }
        public bool recommended { get; set; }
    }
}
