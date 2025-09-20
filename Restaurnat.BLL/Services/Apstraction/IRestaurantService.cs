using Restaurnat.DAL.Entities;

namespace Restaurnat.BLL.Services.Apstraction
{
    public interface IRestaurantService
    {
        List<Restaurant> GetAll();
        Restaurant GetById(int id);
        (bool, string) Create(Restaurant newRestaurant);
        bool Update(Restaurant newRestaurant);
        bool Delete(int id);
    }
}
