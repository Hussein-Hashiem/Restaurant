
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Restaurnat.BLL.Helper;
using Restaurnat.BLL.ModelVM.Account;
using Restaurnat.BLL.ModelVM.User;
using Restaurnat.BLL.Services.Apstraction;
using Restaurnat.DAL.Entities;
using Restaurnat.DAL.Repo.Apstraction;

namespace Restaurnat.BLL.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepo userRepo;
        private readonly IMapper mapper;
		private readonly UserManager<User> userManager;

		public UserService(IUserRepo userRepo, IMapper mapper, UserManager<User> userManager)
        {
            this.userRepo = userRepo;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        public async Task<IdentityResult> RegisterUserAsync(RegisterVM newUser)
        {
            var user = new User(newUser.first_name, newUser.last_name, newUser.age, newUser.country, newUser.city, newUser.street)
            {
                UserName = newUser.UserName,
                Email = newUser.email
            };

            var result = await userManager.CreateAsync(user, newUser.password);

            if (result.Succeeded)
            {
                // Add default role
                await userManager.AddToRoleAsync(user, "User");
            }

            return result;
        }

        public (bool, string) Delete(string id)
        {
            try
            {
                var result = userRepo.Delete(id);
                if (!result) return (false, "Not Found");
                return (true, "Deleted Successfully");
            }
            catch (Exception ex) { return (false, ex.Message); }
        }


		public async Task<(bool, string, List<GetUserVM>)> GetAll()
		{
			try
			{
				var allUsers = userRepo.GetAll();
				var result = mapper.Map<List<GetUserVM>>(allUsers);

				foreach (var userVM in result)
				{
					var user = await userManager.FindByIdAsync(userVM.Id);
					var roles = await userManager.GetRolesAsync(user);
					userVM.role = roles.FirstOrDefault() ?? "User";
				}

				return (true, "Success", result);
			}
			catch (Exception ex)
			{
				return (false, ex.Message, null);
			}
		}

		public (bool, string, GetUserVM) GetByID(string id)
        {
            try
            {
                var user = userRepo.GetById(id);
                if (user == null) return (false, "Not Found", null);
                var result = mapper.Map<GetUserVM>(user);
                return (true, "Success", result);
            }
            catch (Exception ex) { return (false, ex.Message, null); }
        }

        public (bool, string) Update(string id, UpdateUserVM curr)
        {
            try
            {
                var user = userRepo.GetById(id);
                var imagepath = Upload.UploadFile("Files", curr.image);
                var result = user.Update(curr.first_name, curr.last_name, curr.age, curr.country, curr.city, curr.street, imagepath);
                if (result)
                {
                    userRepo.Update(user);
                    return (true, "Updated Successfully");
                }
                else { return (false, "Update Failed"); }
            }
            catch (Exception ex) { return (false, ex.Message); }
        }
    }
}
