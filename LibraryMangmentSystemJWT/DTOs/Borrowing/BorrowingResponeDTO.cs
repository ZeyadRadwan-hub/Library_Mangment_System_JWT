using System.ComponentModel.DataAnnotations;

namespace LibraryMangmentSystemJWT.DTOs.Borrowing
{
    public class BorrowingResponeDTO
    {
        public int Id { get; set; }
        [Required]
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
