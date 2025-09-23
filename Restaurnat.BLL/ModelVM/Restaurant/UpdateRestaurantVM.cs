
namespace Restaurnat.BLL.ModelVM.Restaurant
{
    public class UpdateRestaurantVM
    {
        public int restaurant_id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public int num_of_guests { get; set; }
        public string? about { get; set; }
        public bool recommended { get; set; }
        public int? num_of_vip_customers { get; set; }

    }
}
