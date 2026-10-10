using AutoMapper;
using LibraryMangmentSystemJWT.DTOs.Borrowing;
using LibraryMangmentSystemJWT.Model;

namespace LibraryMangmentSystemJWT
{
    public class BorrowProfile:Profile
    {
        public BorrowProfile()
        {
            CreateMap<Borrowing,BorrowingDTO>().ReverseMap();
            CreateMap<Borrowing,BorrowingResponeDTO>().ReverseMap();
        }
    }
}
