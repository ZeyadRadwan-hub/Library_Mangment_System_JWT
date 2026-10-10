using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryMangmentSystemJWT.Model
{
    public class Borrowing
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate {  get; set; }

        [ForeignKey(nameof(BookId))]
        public int BookId {  get; set; }
        public Book Book { get; set; }

        [ForeignKey(nameof(MemberId))]
        public int MemberId { get; set; }
        public Member Member { get; set; }
    }
}
