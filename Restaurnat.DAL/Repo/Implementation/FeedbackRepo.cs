
using Restaurnat.DAL.Database;
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
    }
}
