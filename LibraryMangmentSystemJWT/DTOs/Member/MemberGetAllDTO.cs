using System.ComponentModel.DataAnnotations;

namespace LibraryMangmentSystemJWT.DTOs.Member
{
    public class MemberGetAllDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public string Phone { get; set; }
        public DateTime BorrowDate { get; set; }
        public int BorrowCount { get; set; }
    }
}
