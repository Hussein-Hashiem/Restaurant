
using Restaurnat.BLL.Services.Apstraction;
using Restaurnat.DAL.Repo.Apstraction;

namespace Restaurnat.BLL.Services.Implementation
{
    public class EventService : IEventService
    {
        private readonly IEventRepo eventRepo;
        public EventService(IEventRepo eventRepo)
        {
            this.eventRepo = eventRepo;
        }
    }
}
