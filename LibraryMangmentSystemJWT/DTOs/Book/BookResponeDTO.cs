using System.ComponentModel.DataAnnotations;

namespace LibraryMangmentSystemJWT.DTOs.Book
{
    public class BookResponeDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public int CategoryId { get; set; }
    }
}
