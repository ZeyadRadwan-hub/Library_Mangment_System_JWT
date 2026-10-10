using LibraryMangmentSystemJWT.DTOs.Borrowing;
using LibraryMangmentSystemJWT.Model;

namespace LibraryMangmentSystemJWT.Repo.CustomRepo.Contract
{
    public interface IBorrowing
    {
        List<BorrowingGetAllDTOs> GetAllBorrowings();
    }
}
