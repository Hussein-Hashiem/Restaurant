
using Restaurnat.BLL.ModelVM.User;

namespace Restaurnat.BLL.Services.Apstraction
{
    public interface IReservationService
    {
        (bool, string) Add(ReservationDto dto);
        (List<ReservationDto>, string) GetAll();
        (ReservationDto?, string) GetById(int id);
        (bool, string) Update(ReservationDto dto);
        (bool, string) Delete(int id);

    }
}
