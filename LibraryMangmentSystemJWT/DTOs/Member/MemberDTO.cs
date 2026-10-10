using System.ComponentModel.DataAnnotations;

namespace LibraryMangmentSystemJWT.DTOs.Member
{
    public class MemberDTO
    {
       
        [Required]
        public string FullName { get; set; }
        [Required, EmailAddress]
        public string EmailAddress { get; set; }
        [Required, Phone]
        public string Phone { get; set; }
    }
}
