
using Restaurnat.DAL.Entities;

namespace Restaurnat.DAL.Repo.Apstraction
{
    public interface IChefRepo
    {
        (bool, string?) Create(Chef chef);
        (bool, string?) Update(Chef chef);
        (bool, string?) Delete(int id, string deletedBy);
        (bool, string?) Restore(int id);
        (List<Chef>, string?) GetAll();
        (Chef, string?) GetById(int id);
    }
}