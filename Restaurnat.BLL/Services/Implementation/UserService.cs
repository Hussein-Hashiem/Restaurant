
using AutoMapper;
using Restaurnat.BLL.ModelVM.User;
using Restaurnat.BLL.Services.Apstraction;
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

        public (bool, string, List<GetAllUserVM>) GetAll()
        {
            try {
                var allUsers = userRepo.GetAll();
                var result = mapper.Map<List<GetAllUserVM>>(allUsers);
                return (true, "Success", result);
            }
            catch (Exception ex) { return (false, ex.Message, null); }
        }
    }
}
