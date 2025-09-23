
using Restaurnat.DAL.Entities;

namespace Restaurnat.DAL.Repo.Apstraction
{
    public interface IMenuRepo
    {
        (bool,string) Add(Menu menu);
        List<Menu> GetAll();
        Menu GetById(int id); 
        (bool, string) Update(Menu menu);
        (bool, string) Delete(int id);

    }
}
