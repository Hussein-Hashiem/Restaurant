
using Restaurnat.DAL.Entities;

namespace Restaurnat.DAL.Repo.Apstraction
{
    public interface IEventRepo
    {
        (bool, string?) Create(Event ev);
        (bool, string?) Update(Event ev);
        (bool, string?) Delete(int id);
        (bool, string?) Restore(int id);
        (List<Event>, string?) GetAll();
        (Event, string?) GetById(int id);
    }
}