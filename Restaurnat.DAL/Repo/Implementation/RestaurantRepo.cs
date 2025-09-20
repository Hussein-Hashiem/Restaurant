using Restaurnat.DAL.Database;
using Restaurnat.DAL.Entities;
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

        public (bool, string) Create(Restaurant newRestaurant)
        {
            try
            {
                if (string.IsNullOrEmpty(newRestaurant.name))
                    return (false, "Restaurant name is required");

                DB.Restaurants.Add(newRestaurant);
                DB.SaveChanges();
                return (true, "Restaurant Created Successfully");
            }
            catch (Exception ex) { return (false, ex.Message); }
        }

        public bool Delete(int id)
        {
            try
            {
                var result = DB.Restaurants.FirstOrDefault(r => r.restaurant_id == id);
                if (result == null) return false;

                DB.Restaurants.Remove(result);
                DB.SaveChanges();
                return true;
            }
            catch (Exception) { throw; }
        }

        public List<Restaurant> GetAll()
        {
            try
            {
                return DB.Restaurants.ToList();
            }
            catch (Exception) { throw; }
        }

        public Restaurant GetById(int id)
        {
            try
            {
                return DB.Restaurants.FirstOrDefault(r => r.restaurant_id == id);
            }
            catch (Exception) { throw; }
        }

        public bool Update(Restaurant newRestaurant)
        {
            try
            {
                var result = DB.Restaurants.FirstOrDefault(r => r.restaurant_id == newRestaurant.restaurant_id);
                if (result == null) return false;


                result.Update(
                    newRestaurant.name,
                    newRestaurant.address,
                    newRestaurant.num_of_guests,
                    newRestaurant.about,
                    newRestaurant.recommended,
                    newRestaurant.num_of_vip_customers,
                    newRestaurant.ModifiedBy
                );

                DB.SaveChanges();
                return true;
            }
            catch (Exception) { throw; }
        }
    }
}
