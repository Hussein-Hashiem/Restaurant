
using Microsoft.AspNetCore.Identity;
using Restaurnat.BLL.ModelVM.Account;
using Restaurnat.BLL.ModelVM.User;

namespace Restaurnat.BLL.Services.Apstraction
{
    public interface IUserService
    {
		Task<(bool, string, List<GetUserVM>)> GetAll();
        (bool, string, GetUserVM) GetByID(string id);
        (bool, string) Update(string id, UpdateUserVM curr);
        (bool, string) Delete(string id);
        Task<IdentityResult> RegisterUserAsync(RegisterVM newUser);

    }
}
