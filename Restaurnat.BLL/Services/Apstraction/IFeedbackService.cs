
using Restaurnat.BLL.ModelVM.Feedback;

namespace Restaurnat.BLL.Services.Apstraction
{
    public interface IFeedbackService
    {
        (bool, string, List<GetAllFeedbackVM>) GetAll();
        (bool, string, GetFeedbackVM) GetByID(int id);
        (bool, string) Delete(int id);
        (bool, string) Update(int id, UpdateFeedbackVM curr);
        (bool, string) Create(CreateFeedbackVM newfeedback);
    }
}