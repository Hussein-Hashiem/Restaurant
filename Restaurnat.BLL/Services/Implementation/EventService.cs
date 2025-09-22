
using AutoMapper;
using Restaurnat.BLL.Helper;
using Restaurnat.BLL.ModelVM.Chef;
using Restaurnat.BLL.ModelVM.Event;
using Restaurnat.BLL.Services.Apstraction;
using Restaurnat.DAL.Entities;
using Restaurnat.DAL.Repo.Apstraction;
using Restaurnat.DAL.Repo.Implementation;
using static System.Net.Mime.MediaTypeNames;

namespace Restaurnat.BLL.Services.Implementation
{
    public class EventService : IEventService
    {
        private readonly IEventRepo eventRepo;
        private readonly IMapper event_mapper;
        public EventService(IEventRepo eventRepo, IMapper mapper)
        {
            this.eventRepo = eventRepo;
            event_mapper = mapper;
        }

        public (bool, string?) Create(CreateEventVM eventy)
        {
            if (eventy == null) return (false, "No event is entered");
            var event_mapped = event_mapper.Map<Event>(eventy);
            var result = eventRepo.Create(event_mapped);
            if (result.Item1) return (true, null);
            return (false, result.Item2);
        }

        public (bool, string?) Delete(int id)
        {
            if ( id < 0) return (false, "No id is entered");
            var result = eventRepo.Delete(id);
            if (result.Item1) return (true, null);
            return (false, result.Item2);
        }

        public (List<GetEventVM>, string?) GetAllEvents()
        {
            var result = eventRepo.GetAll();
            var eventList_mapped = event_mapper.Map<List<GetEventVM>>(result);
            if (eventList_mapped.Count < 1)
            {
                return (null, "No data found");
            }
            return (eventList_mapped, null);
        }

        public (GetEventVM, string?) GetById(int id)
        {
            if (id < 0) return (null, "No id is entered");
            var result = eventRepo.GetById(id);
            var event_mapped = event_mapper.Map<GetEventVM>(result);
            if (event_mapped == null)
            {
                return (null, "No data found");
            }
            return (event_mapped, null);
        }

        public (bool, string?) Restore(int id)
        {
            if (id < 0) return (false, "No id is entered");
            var result = eventRepo.Restore(id);
            if (result.Item1) return (true, null);
            return (false, result.Item2);
        }

        public (bool, string?) Update(EditEventVM eventy)
        {
            if (eventy == null) { return (false, "You passed null argument"); }
            
            var event_mapped = event_mapper.Map<Event>(eventy);
            var result = eventRepo.Update(event_mapped);
            if (result.Item1) return (true, null);
            return (false, result.Item2);
        }
    }
}
