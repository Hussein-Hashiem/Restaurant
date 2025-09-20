
using Restaurnat.DAL.Database;
using Restaurnat.DAL.Entities;
using Restaurnat.DAL.Repo.Apstraction;

namespace Restaurnat.DAL.Repo.Implementation
{
    public class FeedbackRepo : IFeedbackRepo
    {
        private readonly ApplicationDbContext DB;

        public FeedbackRepo(ApplicationDbContext DB)
        {
            this.DB = DB;
        }

        public (bool, string) Create(Feedback newfeedback)
        {
            try
            {
                if (newfeedback.rating == 0) return (false, "Rating is required");
                DB.Feedbacks.Add(newfeedback);
                DB.SaveChanges();
                return (true, "Feedback Created Successfully");
            }
            catch (Exception ex) { return (false, ex.Message); }
        }

        public bool Delete(int id)
        {
            try
            {
                var result = DB.Feedbacks.Where(f => f.feedback_id == id).FirstOrDefault();
                if (result == null) return false;
                DB.Feedbacks.Remove(result);
                DB.SaveChanges();
                return true;
            }
            catch (Exception) { throw; }
        }

        public List<Feedback> GetAll()
        {
            try
            {
                var result = DB.Feedbacks.ToList();
                return result;
            }
            catch (Exception) { throw; }
        }

        public Feedback GetById(int id)
        {
            try {
                var result = DB.Feedbacks.Where(f => f.feedback_id == id).FirstOrDefault();
                return result;
            }
            catch (Exception) { throw; }
        }

        public bool Update(Feedback newfeedback)
        {
            try { 
                var result = DB.Feedbacks.Where(f => f.feedback_id == newfeedback.feedback_id).FirstOrDefault();
                if (result == null) return false;
                result.Update(newfeedback.rating, newfeedback.comment, newfeedback.ModifiedBy);
                DB.SaveChanges();
                return true;
            }
            catch (Exception) { throw; }
        }
    }
}
