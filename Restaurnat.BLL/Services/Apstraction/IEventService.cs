
using Microsoft.AspNetCore.Http;
using Restaurnat.BLL.ModelVM.Chef;
using Restaurnat.BLL.ModelVM.Event;

namespace Restaurnat.BLL.Services.Apstraction
{
    public interface IEventService
    {
        (bool, string?) Create(CreateEventVM eventy);
        public (bool, string?) Update(EditEventVM eventy);
        (bool, string?) Delete(int id);
        (bool, string?) Restore(int id);
        (List<GetEventVM>, string?) GetAllEvents();
        (GetEventVM, string?) GetById(int id);
    }
}
