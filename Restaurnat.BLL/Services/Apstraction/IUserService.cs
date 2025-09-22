
using Restaurnat.BLL.ModelVM.User;

namespace Restaurnat.BLL.Services.Apstraction
{
    public interface IUserService
    {
        (bool, string, List<GetUserVM>) GetAll();
        (bool, string, GetUserVM) GetByID(int id);
        (bool, string) Create(CreateUserVM newuser);
        (bool, string) Update(int id, UpdateUserVM curr);
        (bool, string) Delete(int id);
    }
}
