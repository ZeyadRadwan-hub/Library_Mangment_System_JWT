using System.ComponentModel.DataAnnotations;

namespace LibraryMangmentSystemJWT.DTOs.Borrowing
{
    public class BorrowingGetAllDTOs
    {
        public int Id { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public string Phone { get; set; }
    }
}
