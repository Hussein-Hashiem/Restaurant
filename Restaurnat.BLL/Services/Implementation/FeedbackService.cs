
using AutoMapper;
using Restaurnat.BLL.ModelVM.Feedback;
using Restaurnat.BLL.Services.Apstraction;
using Restaurnat.DAL.Entities;
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
            try
            {
                var allfeedback = feedbackRepo.GetAll();
                var result = mapper.Map<List<GetAllFeedbackVM>>(allfeedback);
                return (true, "Success", result);
            }
            catch (Exception ex) { return (false, ex.Message, null); }
        }

        public (bool, string, GetFeedbackVM) GetByID(int id)
        {
            try
            {
                var feedback = feedbackRepo.GetById(id);
                if (feedback == null) return (false, "Not Found", null);
                var result = mapper.Map<GetFeedbackVM>(feedback);
                return (true, "Success", result);
            }
            catch (Exception ex) { return (false, ex.Message, null); }
        }
        public (bool, string) Delete(int id)
        {
            try {
                var result = feedbackRepo.Delete(id);
                if (!result) return (false, "Not Found");
                return (true, "Deleted Successfully");
            }
            catch (Exception ex) { return (false, ex.Message); }
        }

        public (bool, string) Update(int id, UpdateFeedbackVM curr)
        {
            try {
                var feedback = feedbackRepo.GetById(id);
                if (feedback == null) return (false, "Not Found");
                var isUpdated = feedback.Update(curr.rating, curr.comment);
                if (!isUpdated) return (false, "Update Failed");
                feedbackRepo.Update(feedback);
                return (true, "Updated Successfully");
            }
            catch (Exception ex) { return (false, ex.Message); }
        }

        public (bool, string) Create(CreateFeedbackVM newfeedback)
        {
            try {
                var newf = mapper.Map<Feedback>(newfeedback);
                var result = feedbackRepo.Create(newf);
                if(!result.Item1) return (false, result.Item2);
                return result;
            }
            catch (Exception ex) { return (false, ex.Message); }
        }
    }
}
