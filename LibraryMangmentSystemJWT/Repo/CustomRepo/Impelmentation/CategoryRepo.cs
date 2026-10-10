using LibraryMangmentSystemJWT.Database;
using LibraryMangmentSystemJWT.DTOs.Category;
using LibraryMangmentSystemJWT.Repo.CustomRepo.Contract;

namespace LibraryMangmentSystemJWT.Repo.CustomRepo.Impelmentation
{
    public class CategoryRepo:ICategory
    {
        private readonly App_database_Context _db;
        public CategoryRepo(App_database_Context db)
        {
            _db = db;
        }

        public List<CategoryGetAllDTO> GetAllCategories()
        {
            var res = _db.Categories.Select(x => new CategoryGetAllDTO
            {
                Name = x.Name,
                BookCount = x.Books.Count()
            }).ToList();
            return res;
        }
    }
}
