
using Restaurnat.DAL.Database;
using Restaurnat.DAL.Repo.Apstraction;

namespace Restaurnat.DAL.Repo.Implementation
{
    public class RestaurantRepo : IRestaurantRepo
    {
        private readonly ApplicationDbContext DB;

        public RestaurantRepo(ApplicationDbContext DB)
        {
            this.DB = DB;
        }
    }
}
