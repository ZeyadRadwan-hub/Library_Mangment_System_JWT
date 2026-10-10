using LibraryMangmentSystemJWT.Database;
using LibraryMangmentSystemJWT.DTOs.Book;
using LibraryMangmentSystemJWT.Model;
using LibraryMangmentSystemJWT.Repo.CustomRepo.Contract;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace LibraryMangmentSystemJWT.Repo.CustomRepo.Impelmentation
{
    public class BookRepo : IBook
    {
        private readonly App_database_Context _db;
        public BookRepo(App_database_Context db)
        {
            _db = db;
        }

        public List<BookDTOSearch> GetAllBooks(string Keyword)
        {
            var res = _db.Books
                .Where(b => b.Title.Contains(Keyword) || b.Author.Contains(Keyword))
                .OrderBy(b => b.Title)
                .Select(b => new BookDTOSearch
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    Price = b.Price,
                    CategoryId = b.CategoryId,
                })
                .ToList();

            return res;
        }

        public Book GetByHighestPrice()
        {
            return _db.Books
                .OrderByDescending(b => b.Price).Take(1)
                .FirstOrDefault();
        }
    }
}
