using Restaurnat.BLL.ModelVM.Restaurant;
using Restaurnat.DAL.Entities;

namespace Restaurnat.BLL.Services.Apstraction
{
    public interface IRestaurantService
    {
        List<GetAllRestaurantVM> GetAll();
        GetRestaurantVM GetById(int id);
        (bool, string) Create(CreateRestaurantVM newRestaurant);
        bool Update(UpdateRestaurantVM newRestaurant);
        bool Delete(int id);
    }
}
