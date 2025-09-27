using Restaurnat.DAL.Entities;

namespace Restaurnat.DAL.Repo.Apstraction
{
    public interface IUserRepo
    {
        List<User> GetAll();
        User GetById(string id);
        (bool, string) Create(User emp);
        bool Update(User emp);
        bool Delete(string id);
    }
}