using System.ComponentModel.DataAnnotations;

namespace LibraryMangmentSystemJWT.DTOs.Auth
{
    public class LoginDto
    {
        [Required, MaxLength(100)]
        public string UserName { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}