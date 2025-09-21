
using Restaurnat.BLL.ModelVM.Feedback;
using Restaurnat.BLL.ModelVM.User;

namespace Restaurnat.BLL.Services.Apstraction
{
    public interface IFeedbackService
    {
        (bool, string, List<GetAllFeedbackVM>) GetAll();
    }
}