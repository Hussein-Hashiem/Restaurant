
using Restaurnat.BLL.ModelVM.User;

namespace Restaurnat.BLL.Services.Apstraction
{
    public interface IUserService
    {
        (bool, string, List<GetAllUserVM>) GetAll();

    }
}
