
using Restaurnat.DAL.Entities;

namespace Restaurnat.DAL.Repo.Apstraction
{
    public interface IFeedbackRepo
    {
        List<Feedback> GetAll();
        Feedback GetById(int id);
        (bool, string) Create(Feedback newfeedback);
        bool Update(Feedback newfeedback);
        bool Delete(int id);
    }
}