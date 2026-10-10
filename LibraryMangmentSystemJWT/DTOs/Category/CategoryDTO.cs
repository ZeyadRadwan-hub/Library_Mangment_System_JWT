using System.ComponentModel.DataAnnotations;

namespace LibraryMangmentSystemJWT.DTOs.Category
{
    public class CategoryDTO
    {
       
        [Required]
        public string Name { get; set; }
        [MaxLength(200)]
        public string? Description { get; set; }
    }
}
