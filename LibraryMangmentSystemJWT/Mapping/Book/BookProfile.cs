using AutoMapper;
using LibraryMangmentSystemJWT.DTOs.Book;
using LibraryMangmentSystemJWT.Model;
namespace LibraryMangmentSystemJWT
{
    public class BookProfile:Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookCreateDTO>().ReverseMap();
            CreateMap<Book,BookResponeDTO>().ReverseMap();
            CreateMap<Book, BookUpdateDTO>().ReverseMap();
        }
    }
}
