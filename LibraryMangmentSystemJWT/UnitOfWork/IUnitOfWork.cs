using LibraryMangmentSystemJWT.Model;
using LibraryMangmentSystemJWT.Repo.CustomRepo.Contract;
using LibraryMangmentSystemJWT.Repo.Generic.Contract;

namespace LibraryMangmentSystemJWT.UnitOfWork
{
    public interface IUnitOfWork
    {
        IGenericRepo<Category> Categories {  get; }
        IGenericRepo<Member> Members {  get; }
        IGenericRepo<Book> Books {  get; }
        IGenericRepo<Borrowing> Borrowings {  get; }
        IGenericRepo<User> Users {  get; }
        IMember CustomMembers { get; }
        ICategory CustomCategories { get; }
        IBook CustomBooks { get; }
        IBorrowing CustomBorrowings { get; }
        IUserRepo CustomUsers { get; }
        int Save();
        Task<int> SaveAsync();
    }
}
