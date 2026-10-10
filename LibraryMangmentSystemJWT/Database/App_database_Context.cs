using LibraryMangmentSystemJWT.Model;
using Microsoft.EntityFrameworkCore;

namespace LibraryMangmentSystemJWT.Database
{
    public class App_database_Context:DbContext
    {
        public App_database_Context(DbContextOptions<App_database_Context> options):base(options) { }

        public DbSet<Member> Members { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Borrowing> Borrowings { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().
                HasOne(x => x.Category)
                .WithMany(x => x.Books)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Borrowing>()
                .HasOne(x => x.Book)
                .WithMany(x => x.Borrowings)
                .HasForeignKey(x => x.BookId);

            modelBuilder.Entity<Borrowing>()
                .HasOne(x => x.Member)
                .WithMany(x => x.Borrowings)
                .HasForeignKey(x => x.MemberId);

            modelBuilder.Entity<Book>().
                Property(x => x.IsAvailable)
                .HasDefaultValue(true);

            modelBuilder.Entity<User>()
            .HasIndex(u => u.UserName)
            .IsUnique();


            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Programming",
                    Description = "Programming and software development books"
                },
                new Category
                {
                    Id = 2,
                    Name = "Database",
                    Description = "Database and data management books"
                }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Title = "C++ Basics",
                    Author = "John Smith",
                    ISBN = "ISBN001",
                    Price = 450,
                    IsAvailable = true,
                    CategoryId = 1
                },
                new Book
                {
                    Id = 2,
                    Title = "SQL Fundamentals",
                    Author = "Sarah Ali",
                    ISBN = "ISBN002",
                    Price = 500,
                    IsAvailable = false,
                    CategoryId = 2
                }
            );

            modelBuilder.Entity<Member>().HasData(
                new Member
                {
                    Id = 1,
                    FullName = "Ahmed Hassan",
                    EmailAddress = "ahmed@example.com",
                    Phone = "01012345678"
                },
                new Member
                {
                    Id = 2,
                    FullName = "Sara Mohamed",
                    EmailAddress = "sara@example.com",
                    Phone = "01198765432"
                }
            );

            modelBuilder.Entity<Borrowing>().HasData(
                new Borrowing
                {
                    Id = 1,
                    BorrowDate = DateTime.Parse("2026-09-20"),
                    ReturnDate = DateTime.Parse("2026-09-25"),
                    MemberId = 1,
                    BookId = 1
                },
                new Borrowing
                {
                    Id = 2,
                    BorrowDate = DateTime.Parse("2026-09-22"),
                    ReturnDate = null,
                    MemberId = 2,
                    BookId = 2
                }
            );
        }
    }
}
