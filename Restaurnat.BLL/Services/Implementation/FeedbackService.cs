
using Restaurnat.BLL.Services.Apstraction;
using Restaurnat.DAL.Repo.Apstraction;

namespace Restaurnat.BLL.Services.Implementation
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepo feedbackRepo;
        public FeedbackService(IFeedbackRepo feedbackRepo)
        {
            this.feedbackRepo = feedbackRepo;
        }
    }
}
