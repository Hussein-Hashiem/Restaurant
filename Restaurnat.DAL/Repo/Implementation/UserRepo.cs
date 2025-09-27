
using Restaurnat.DAL.Database;
using Restaurnat.DAL.Entities;
using Restaurnat.DAL.Repo.Apstraction;

namespace Restaurnat.DAL.Repo.Implementation
{
    public class UserRepo : IUserRepo
    {
        private readonly ApplicationDbContext DB;

        public UserRepo(ApplicationDbContext DB)
        {
            this.DB = DB;
        }

        public (bool, string) Create(User newUser)
        {
            try
            {
                if (string.IsNullOrEmpty(newUser.first_name)|| string.IsNullOrEmpty(newUser.last_name)) return (false, "Name is equired!");
                if (newUser.age == 0) return (false, "age is equired!");
                var result = DB.Users.Add(newUser);
                DB.SaveChanges();
                return (true, null);
            }
            catch (Exception ex) { return (false, ex.Message); }
        }

        public bool Delete(string id)
        {
            try
            {
                var result = DB.Users.Where(i => i.Id == id).FirstOrDefault();
                if (result != null)
                {
                    DB.Users.Remove(result);
                    DB.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception) { throw; }
        }

        public List<User> GetAll()
        {
            try
            {
                var result = DB.Users.ToList();
                return result;
            }
            catch (Exception) { throw; }
        }

        public User GetById(string id)
        {
            try
            {
                var result = DB.Users.Where(i => i.Id == id).FirstOrDefault();
                return result;
            }
            catch (Exception) { throw; }
        }

        public bool Update(User user)
        {
            try
            {
                var result = DB.Users.Where(f => f.Id == user.Id).FirstOrDefault();
                if (result == null) return false;
                result.Update(user.first_name, user.last_name, user.age, user.country, user.city, user.street, user.imagepath);
                DB.SaveChanges();
                return true;
            }
            catch (Exception) { throw; }
        }
    }
}
