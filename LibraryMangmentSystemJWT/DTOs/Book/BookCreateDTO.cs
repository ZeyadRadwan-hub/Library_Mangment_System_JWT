using System.ComponentModel.DataAnnotations;

namespace LibraryMangmentSystemJWT.DTOs.Book
{
    public class BookCreateDTO
    {
        
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required, Range(0.1, (double)decimal.MaxValue)]
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }
}
