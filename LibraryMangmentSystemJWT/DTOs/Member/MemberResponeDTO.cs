using System.ComponentModel.DataAnnotations;

namespace LibraryMangmentSystemJWT.DTOs.Member
{
    public class MemberResponeDTO
    {
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required, EmailAddress]
        public string EmailAddress { get; set; }
        [Required, Phone]
        public string Phone { get; set; }
    }
}
