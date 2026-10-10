namespace LibraryMangmentSystemJWT.DTOs.Member
{
    public class MemberGetByIdDTO
    {
        public string FullName { get; set; }
        public int TotalBorrowedBooks { get; set; }
        public int ReturnedBooks { get; set; }
        public int CurrentlyBorrowedBooks { get; set; }
    }
}
