using AutoMapper;
using Restaurnat.BLL.ModelVM.Restaurant;
using Restaurnat.BLL.Services.Apstraction;
using Restaurnat.DAL.Entities;
using Restaurnat.DAL.Repo.Apstraction;

namespace Restaurnat.BLL.Services.Implementation
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepo restaurantRepo;
        private readonly IMapper mapper;
        public RestaurantService(IRestaurantRepo restaurantRepo, IMapper mapper)
        {
            this.restaurantRepo = restaurantRepo;
            this.mapper = mapper;
        }

        public (bool, string) Create(CreateRestaurantVM newRestaurant)
        {
            if (string.IsNullOrEmpty(newRestaurant.name) || string.IsNullOrEmpty(newRestaurant.address))
                return (false, "Name and Address are required");
            var res = mapper.Map<Restaurant>(newRestaurant);
            var result= restaurantRepo.Create(res);
            if(!result.Item1) return (false, "Something went wrong");
            return (true, null);
        }
        public bool Delete(int id)
        {
            var result = restaurantRepo.Delete(id);
            return result;
        }

        public List<GetAllRestaurantVM> GetAll()
        {
            var result= restaurantRepo.GetAll();
            var mapp = mapper.Map<List<GetAllRestaurantVM>>(result);
            if (result.Count > 0) return (mapp);
            return null;
        }

        public bool Update(UpdateRestaurantVM newRestaurant)
        {
            var mapp = mapper.Map<Restaurant>(newRestaurant);
            var result = restaurantRepo.Update(mapp);
            return result;
        }
        GetRestaurantVM IRestaurantService.GetById(int id)
        {
            var result = restaurantRepo.GetById(id);
            var mapp = mapper.Map<GetRestaurantVM>(result);
            return mapp;
        }
    }
}
