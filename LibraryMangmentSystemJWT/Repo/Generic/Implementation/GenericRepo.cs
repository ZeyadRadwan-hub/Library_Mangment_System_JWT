using LibraryMangmentSystemJWT.Database;
using LibraryMangmentSystemJWT.Repo.Generic.Contract;

namespace LibraryMangmentSystemJWT.Repo.Generic.Implementation
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly App_database_Context _db;
        public GenericRepo(App_database_Context db)
        {
            _db = db;
        }
        public void AddObject(T obj)
        {
            _db.Set<T>().Add(obj);
        }

        public void DeleteObject(int id)
        {
            var res = _db.Set<T>().Find(id);
            if (res == null)
            {
                return;
            }
            _db.Set<T>().Remove(res);
        }

        public void UpdateObject(T obj)
        {
            _db.Set<T>().Update(obj);
        }
    }
}
