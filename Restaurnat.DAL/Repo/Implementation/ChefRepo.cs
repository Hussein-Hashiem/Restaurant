
using Restaurnat.DAL.Database;
using Restaurnat.DAL.Entities;
using Restaurnat.DAL.Repo.Apstraction;

namespace Restaurnat.DAL.Repo.Implementation
{
    public class ChefRepo : IChefRepo
    {
        private readonly ApplicationDbContext DB;

        public ChefRepo(ApplicationDbContext DB)
        {
            this.DB = DB;
        }

        public (bool, string?) Create(Chef chef)
        {
            try
            {
                var result = DB.Chefs.Add(chef);
                DB.SaveChanges();
                if (result.Entity.chef_id > 0)
                {
                    return (true, null);
                }
                return (false, "Error Adding this chef!");
            }
            catch
            {
                return (false, "Error Adding this chef!");
            }
        }
        public (bool, string?) Update(Chef chef)
        {
            try
            {
                var result = DB.Chefs.Where(ch => ch.chef_id == chef.chef_id).FirstOrDefault();

                if (result.chef_id > 0)
                {
                    if (result.EditChef(chef))
                    {
                        DB.SaveChanges();
                        return (true, null);
                    }
                }
                return (false, "Something went wrong");
            }
            catch
            {
                return (false, "Something went wrong");
            }
        }

        public (bool, string?) Restore(int id)
        {
            try
            {
                var result = DB.Chefs.Where(ch => ch.chef_id == id).FirstOrDefault();

                if (result.chef_id > 0)
                {
                    if (result.RestoreChef())
                    {
                        DB.SaveChanges();
                        return (true, null);
                    }
                }
                return (false, "Something went wrong");
            }
            catch
            {
                return (false, "Something went wrong");
            }
        }


        public (bool, string?) Delete(int id, string deletedBy)
        {

            var result = DB.Chefs.Where(ch => ch.chef_id == id).FirstOrDefault();
            if (result.chef_id != 0)
            {
                if (result.DeleteChef(deletedBy))
                { //soft delete
                    DB.SaveChanges();
                    return (true, null);
                }

            }
            return (false, "Something went wrong");
        }

        public (Chef, string?) GetById(int id)
        {
            var result = DB.Chefs.Where(ch => ch.chef_id == id).FirstOrDefault();
            if (result.chef_id != 0)
            {
                return (result, null);
            }
            return (null, "Something went wrong");
        }

        public (List<Chef>, string?) GetAll()
        {
            //var result = DB.Chefs.Where(ch => ch.IsDeleted== false).ToList();
            var result = DB.Chefs.ToList();
            if (result.Count > 0)
            {
                return (result, null);
            }
            return (null, "There is no Data");
        }
        //public (List<Chef>, string?) GetAllAdmin()
        //{
        //    var result = DB.Chefs.ToList();
        //    if (result.Count > 0)
        //    {
        //        return (result, null);
        //    }
        //    return (null, "There is no Data");
        //}


    }
}
