using LibraryMangmentSystemJWT.DTOs.Book;
using LibraryMangmentSystemJWT.Model;

namespace LibraryMangmentSystemJWT.Repo.CustomRepo.Contract
{
    public interface IBook
    {
        List<BookDTOSearch> GetAllBooks(string Keyword);
        Book GetByHighestPrice();
    }
}
