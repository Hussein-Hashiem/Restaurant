
using Restaurnat.DAL.Entities;

namespace Restaurnat.DAL.Repo.Apstraction
{
    public interface IReservationRepo
    {
        (bool, string) Add(Reservation res);
        List<Reservation> GetAll();
        Reservation GetById(int id);
        (bool, string) Update(Reservation res);
        (bool, string) Delete(int id);
    }

}