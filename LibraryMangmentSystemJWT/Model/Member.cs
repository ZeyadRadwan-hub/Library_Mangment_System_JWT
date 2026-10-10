using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LibraryMangmentSystemJWT.Model
{
    [Index(nameof(EmailAddress),IsUnique = true)]
    [Index(nameof(Phone),IsUnique = true)]
    public class Member
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required,EmailAddress]
        public string EmailAddress { get; set; }
        [Required,Phone]
        public string Phone {  get; set; }
        public ICollection<Borrowing> Borrowings { get; set; } = new List<Borrowing>();
    }
}
