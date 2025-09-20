using Restaurnat.BLL.Services.Apstraction;
using Restaurnat.DAL.Entities;
using Restaurnat.DAL.Repo.Apstraction;

namespace Restaurnat.BLL.Services.Implementation
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepo restaurantRepo;

        public RestaurantService(IRestaurantRepo restaurantRepo)
        {
            this.restaurantRepo = restaurantRepo;
        }

        public (bool, string) Create(Restaurant newRestaurant)
        {
            if (string.IsNullOrEmpty(newRestaurant.name) || string.IsNullOrEmpty(newRestaurant.address))
                return (false, "Name and Address are required");

            return restaurantRepo.Create(newRestaurant);
        }

        public bool Delete(int id)
        {
            return restaurantRepo.Delete(id);
        }

        public List<Restaurant> GetAll()
        {
            return restaurantRepo.GetAll();
        }

        public Restaurant GetById(int id)
        {
            return restaurantRepo.GetById(id);
        }

        public bool Update(Restaurant newRestaurant)
        {
            return restaurantRepo.Update(newRestaurant);
        }
    }
}
