
using AutoMapper;
using Restaurnat.BLL.Helper;
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
        public UserService(IUserRepo userRepo, IMapper mapper)
        {
            this.userRepo = userRepo;
            this.mapper = mapper;
        }

        public (bool, string) Create(CreateUserVM newuser)
        {
            try
            {
                var imagepath = Upload.UploadFile("Files", newuser.image);
                User user = new User(newuser.first_name, newuser.last_name, newuser.age, newuser.country, newuser.city, newuser.street);
                var result = userRepo.Create(user);
                if (result.Item1) return (true, "User Created Successfully");
                else return (false, result.Item2);
            }
            catch (Exception ex) { return (false, ex.Message); }
        }

        public (bool, string) Delete(int id)
        {
            try
            {
                var result = userRepo.Delete(id);
                if (!result) return (false, "Not Found");
                return (true, "Deleted Successfully");
            }
            catch (Exception ex) { return (false, ex.Message); }
        }

        public (bool, string, List<GetUserVM>) GetAll()
        {
            try
            {
                var allUsers = userRepo.GetAll();
                var result = mapper.Map<List<GetUserVM>>(allUsers);
                return (true, "Success", result);
            }
            catch (Exception ex) { return (false, ex.Message, null); }
        }

        public (bool, string, GetUserVM) GetByID(int id)
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
                var user = userRepo.GetById(int.Parse(id));
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
