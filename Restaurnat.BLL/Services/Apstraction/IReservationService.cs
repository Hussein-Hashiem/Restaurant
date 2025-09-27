

using Restaurnat.BLL.ModelVM.Reservation;

namespace Restaurnat.BLL.Services.Apstraction
{
    public interface IReservationService
    {
        (bool, string) Add(CreateReservationVM dto);
        (List<GetReservationVM>, string) GetAll();
        (GetReservationVM, string) GetById(int id);
        (bool, string) Update(int id,EditReservationVM dto);
        (bool, string) Delete(int id);
        List<GetReservationVM> GetByUserId(string userId);


    }
}
