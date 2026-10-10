using LibraryMangmentSystemJWT.Database;
using LibraryMangmentSystemJWT.Model;
using LibraryMangmentSystemJWT.Repo.CustomRepo.Contract;
using LibraryMangmentSystemJWT.Repo.Generic.Contract;

namespace LibraryMangmentSystemJWT.UnitOfWork
{
    public class UnitOfWorkIMP : IUnitOfWork
    {
        private readonly App_database_Context _db;
        public IGenericRepo<Category> Categories { get; }

        public IGenericRepo<Member> Members {  get;}

        public IGenericRepo<Book> Books { get; }

        public IGenericRepo<Borrowing> Borrowings {  get;}
        public IGenericRepo<User> Users {  get;}

        public IMember CustomMembers {  get; }

        public ICategory CustomCategories { get;}

        public IBook CustomBooks { get;}

        public IBorrowing CustomBorrowings { get;}
        public IUserRepo CustomUsers { get; }

        public UnitOfWorkIMP(App_database_Context db,
            IGenericRepo<Category> Category,
            IGenericRepo<Member> Member,
            IGenericRepo<Book> Book,
            IGenericRepo<Borrowing> Borrowing,
            IMember CustomMember,
            ICategory CustomCategory,
            IBook CustomBook,
            IBorrowing CustomBorrowing,
            IUserRepo CustomUser,
            IGenericRepo<User> User

            )

        {
            _db = db;
            Categories = Category;
            Members = Member;
            Books = Book;
            Borrowings = Borrowing;
            CustomMembers = CustomMember;
            CustomCategories = CustomCategory;
            CustomBooks = CustomBook;
            CustomBorrowings = CustomBorrowing;
            CustomUsers = CustomUser;
            Users = User;
        }
        public int Save()
        {
            return _db.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await _db.SaveChangesAsync();
        }
    }
}
