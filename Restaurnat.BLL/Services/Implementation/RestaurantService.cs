
using Restaurnat.BLL.Services.Apstraction;
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
    }
}
