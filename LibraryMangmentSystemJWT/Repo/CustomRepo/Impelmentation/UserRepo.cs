using LibraryMangmentSystemJWT.Database;
using LibraryMangmentSystemJWT.Model;
using LibraryMangmentSystemJWT.Repo.CustomRepo.Contract;
using LibraryMangmentSystemJWT.Repo.Generic.Contract;
using Microsoft.EntityFrameworkCore;

namespace LibraryMangmentSystemJWT.Repo.CustomRepo.Impelmentation
{
    public class UserRepo :IUserRepo
    {
        private readonly App_database_Context _db;
        public UserRepo(App_database_Context db)
        {
            _db = db;
        }

        //public void AddObject(User obj)
        //{
        //    _db.Users.Add(obj);
        //}

        //public void DeleteObject(int id)
        //{
        //    var user = _db.Users.Find(id);
        //    _db.Users.Remove(user);
        //}

        //public void UpdateObject(User obj)
        //{
        //    _db.Users.Update(obj);
        //}

        public async Task<User> GetByUserNameAsync(string userName)
        {
            return await _db.Users.FirstOrDefaultAsync(u => u.UserName == userName);
        }

       
    }
}
