
namespace Restaurnat.BLL.ModelVM.Menu
{
    public class GetMenuVM
    {
        public int menu_id { get; set; }
        public string name { get; set; }
        public string Description { get; set; }
        public List<Restaurnat.DAL.Entities.Item> Items { get; set; }
    }
}
