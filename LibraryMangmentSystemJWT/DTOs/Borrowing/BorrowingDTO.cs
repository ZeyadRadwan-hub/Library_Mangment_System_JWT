using System.ComponentModel.DataAnnotations;

namespace LibraryMangmentSystemJWT.DTOs.Borrowing
{
    public class BorrowingDTO
    {
        [Required]
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
