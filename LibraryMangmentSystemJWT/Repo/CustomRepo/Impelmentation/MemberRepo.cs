using LibraryMangmentSystemJWT.Database;
using LibraryMangmentSystemJWT.DTOs.Member;
using LibraryMangmentSystemJWT.Model;
using LibraryMangmentSystemJWT.Repo.CustomRepo.Contract;
using Microsoft.EntityFrameworkCore;

namespace LibraryMangmentSystemJWT.Repo.CustomRepo.Impelmentation
{
    public class MemberRepo:IMember
    {
        private readonly App_database_Context _db;
        public MemberRepo(App_database_Context db)
        {
            _db = db;
        }

        public List<MemberGetAllDTO> GetAllMembers()
        {
            var res = _db.Members.OrderByDescending
                (x => x.Borrowings.Count())
                .Take(5).Select(s => new MemberGetAllDTO
                {
                    EmailAddress = s.EmailAddress,
                    FullName = s.FullName,
                    Id = s.Id,
                    Phone = s.Phone,
                    BorrowCount = s.Borrowings.Count()
                }).ToList();
                return res;
        }

        public MemberGetByIdDTO GetById(int id)
        {
            var res = _db.Members
            .Where(m => m.Id == id)
            .Select(m => new MemberGetByIdDTO
            {
                FullName = m.FullName,
                TotalBorrowedBooks = m.Borrowings.Count(),
                ReturnedBooks = m.Borrowings.Count(b => b.ReturnDate != null),
                CurrentlyBorrowedBooks = m.Borrowings.Count(b => b.ReturnDate == null)
            }).FirstOrDefault();

            return res;
        }
    }
}
