using Restaurnat.DAL.Entities;

namespace Restaurnat.DAL.Repo.Apstraction
{
    public interface IRestaurantRepo
    {
        List<Restaurant> GetAll();
        Restaurant GetById(int id);
        (bool, string) Create(Restaurant newRestaurant);
        bool Update(Restaurant newRestaurant);
        bool Delete(int id);
    }
}
