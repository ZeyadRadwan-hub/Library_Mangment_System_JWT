using LibraryMangmentSystemJWT.Database;
using LibraryMangmentSystemJWT.DTOs.Borrowing;
using LibraryMangmentSystemJWT.Model;
using LibraryMangmentSystemJWT.Repo.CustomRepo.Contract;

namespace LibraryMangmentSystemJWT.Repo.CustomRepo.Impelmentation
{
    public class BorrowingRepo:IBorrowing
    {
        private readonly App_database_Context _db;
        public BorrowingRepo(App_database_Context db)
        {
            _db = db;
        }

        public List<BorrowingGetAllDTOs> GetAllBorrowings()
        {
            var res = _db.Borrowings.
                Select(s => new BorrowingGetAllDTOs
                {
                    Id = s.Id,
                    ReturnDate = s.ReturnDate,
                    BorrowDate = s.BorrowDate,
                    EmailAddress = s.Member.EmailAddress,
                    Phone = s.Member.Phone,
                    Author = s.Book.Author,
                    FullName = s.Member.FullName,
                    Price = s.Book.Price,
                    Title = s.Book.Title
                }).OrderByDescending(s => s.BorrowDate)
                .ToList();
                
                return res;
        }
    }
}