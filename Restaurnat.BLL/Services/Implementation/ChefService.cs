
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Restaurnat.BLL.Helper;
using Restaurnat.BLL.ModelVM.Chef;
using Restaurnat.BLL.ModelVM.User;
using Restaurnat.BLL.Services.Apstraction;
using Restaurnat.DAL.Entities;
using Restaurnat.DAL.Repo.Apstraction;
using static System.Net.Mime.MediaTypeNames;

namespace Restaurnat.BLL.Services.Implementation
{
    public class ChefService : IChefService
    {
        private readonly IChefRepo chefRepo;
        private readonly IMapper chef_mapper;
        public ChefService(IChefRepo chefRepo, IMapper mapper)
        {
            this.chefRepo = chefRepo;
            chef_mapper = mapper;
        }

        public (bool, string?) Create(CreateChefVM chef, IFormFile image)
        {
            if (chef == null) return (false, "No chef is entered");
            if (image == null) return (false, "image not uploaded!");
            if (chef.categoryId == -1)
            {
                chef.categoryId = 0;
                chef.category = "General Chef";
            }
            else
            {
                var categ = "GetMenuById(chef.categoryId)";
                chef.category = categ;
            }
            chef.work_now = true;
            chef.imagepath = Upload.UploadFile("Files", image);
            chef.restaurant_id = 0;
            var chef_mapped = chef_mapper.Map<Chef>(chef);
            var result = chefRepo.Create(chef_mapped);
            if (result.Item1) return (true, null);
            return (false, result.Item2);
        }

        public (bool, string?) Delete(int id)
        {
            if (id == null || id < 0) return (false, "No id is entered");
            var result = chefRepo.Delete(id, "Admin");
            if (result.Item1) return (true, null);
            return (false, result.Item2);
        }
        public (bool, string?) Restore(int id)
        {
            if (id == null || id < 0) return (false, "No id is entered");
            var result = chefRepo.Restore(id);
            if (result.Item1) return (true, null);
            return (false, result.Item2);
        }

        public (List<GetChefVM>, string?) GetAll()
        {
            var result = chefRepo.GetAll();
            var chefList_mapped = chef_mapper.Map<List<GetChefVM>>(result.Item1);
            if (chefList_mapped.Count < 1)
            {
                return (null, "No data found");
            }
            return (chefList_mapped, null);
        }

        public (GetChefVM, string?) GetById(int id)
        {
            if (id == null || id < 0) return (null, "No id is entered");
            var result = chefRepo.GetById(id);
            var chef_mapped = chef_mapper.Map<GetChefVM>(result.Item1);
            if (chef_mapped == null)
            {
                return (null, "No data found");
            }
            return (chef_mapped, null);
        }

        public (bool, string?) Update(EditChefVM chef, IFormFile image)
        {
            if (chef == null) { return (false, "You passed null argument"); }
            if (chef.categoryId == -1)
            {
                chef.categoryId = 0;
                chef.category = "General Chef";
            }
            else
            {
                var categ = "Cook";//"GetMenuById(chef.categoryId)";
                chef.category = categ;
            }
            chef.imagepath = Upload.UploadFile("Files", image);
            var chef_mapped = chef_mapper.Map<Chef>(chef);
            var result = chefRepo.Update(chef_mapped);
            if (result.Item1) return (true, null);
            return (false, result.Item2);
        }
    }
}
