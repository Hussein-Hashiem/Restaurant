
using AutoMapper;
using Restaurnat.BLL.ModelVM.Feedback;
using Restaurnat.BLL.Services.Apstraction;
using Restaurnat.DAL.Repo.Apstraction;

namespace Restaurnat.BLL.Services.Implementation
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepo feedbackRepo;
        private readonly IMapper mapper;
        public FeedbackService(IFeedbackRepo feedbackRepo, IMapper mapper)
        {
            this.feedbackRepo = feedbackRepo;
            this.mapper = mapper;
        }

        public (bool, string, List<GetAllFeedbackVM>) GetAll()
        {
            try { 
                var allfeedback = feedbackRepo.GetAll();
                var result = mapper.Map<List<GetAllFeedbackVM>>(allfeedback);
                return (true, "Success", result);
            }
            catch (Exception ex) { return (false, ex.Message, null); }
        }
    }
}
