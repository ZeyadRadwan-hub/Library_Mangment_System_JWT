using LibraryMangmentSystemJWT.DTOs.Category;
using LibraryMangmentSystemJWT.Model;

namespace LibraryMangmentSystemJWT.Repo.CustomRepo.Contract
{
    public interface ICategory
    {
        List<CategoryGetAllDTO> GetAllCategories();
    }
}
