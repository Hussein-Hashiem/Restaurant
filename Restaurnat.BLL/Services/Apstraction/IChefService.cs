using Microsoft.AspNetCore.Http;
using Restaurnat.BLL.ModelVM.Chef;
using Restaurnat.BLL.ModelVM.User;
using Restaurnat.DAL.Entities;

namespace Restaurnat.BLL.Services.Apstraction
{
    public interface IChefService
    {
        (bool, string?) Create(CreateChefVM chef, IFormFile image);
        public (bool, string?) Update(EditChefVM chef, IFormFile image);
        (bool, string?) Delete(int id);
        (bool, string?) Restore(int id);
        (List<GetChefVM>, string?) GetAll();
        (GetChefVM, string?) GetById(int id);
    }
}
