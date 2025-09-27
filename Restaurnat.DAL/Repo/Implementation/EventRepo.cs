
using Restaurnat.DAL.Database;
using Restaurnat.DAL.Entities;
using Restaurnat.DAL.Repo.Apstraction;

namespace Restaurnat.DAL.Repo.Implementation
{
    public class EventRepo : IEventRepo
    {
        private readonly ApplicationDbContext DB;

        public EventRepo(ApplicationDbContext DB)
        {
            this.DB = DB;
        }
        public (bool, string?) Create(Event ev)
        {
            try
            {
                var result = DB.Events.Add(ev);
                DB.SaveChanges();
                if (result.Entity.event_id > 0)
                {
                    return (true, null);
                }
                return (false, "Error Adding this event to your restaurant!");
            }
            catch
            {
                return (false, "Error Adding this event to your restaurant!");
            }
        }
        public (bool, string?) Update(Event ev)
        {
            try
            {
                var result = DB.Events.Where(evv => evv.event_id == ev.event_id).FirstOrDefault();

                if (result.event_id > 0)
                {
                    if (result.EditEvent(ev))
                    {
                        DB.SaveChanges();
                        return (true, null);
                    }
                }
                return (false, "Something went wrong");
            }
            catch
            {
                return (false, "Something went wrong");
            }
        }

        public (bool, string?) Restore(int id)
        {
            try
            {
                var result = DB.Events.Where(evv => evv.event_id == id).FirstOrDefault();

                if (result.event_id > 0)
                {
                    if (result.RestoreEvent())
                    {
                        DB.SaveChanges();
                        return (true, null);
                    }
                }
                return (false, "Something went wrong");
            }
            catch
            {
                return (false, "Something went wrong");
            }
        }


        public (bool, string?) Delete(int id)
        {

            var result = DB.Events.Where(evv => evv.event_id == id).FirstOrDefault();
            if (result.event_id != 0)
            {
                if (result.DeleteEvent())
                {
                    DB.SaveChanges();
                    return (true, null);
                }

            }
            return (false, "Something went wrong");
        }

        public (Event, string?) GetById(int id)
        {
            var result = DB.Events.Where(evv => evv.event_id == id).FirstOrDefault();
            if (result.event_id != 0)
            {
                return (result, null);
            }
            return (null, "Something went wrong");
        }

        public (List<Event>, string?) GetAll()
        {
            var result = DB.Events.ToList(); //.Where(evv => evv.IsDeleted == false)
            if (result.Count > 0)
            {
                return (result, null);
            }
            return (null, "There is no Data");
        }

    }
}
