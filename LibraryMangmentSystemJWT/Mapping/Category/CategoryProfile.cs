using AutoMapper;
using LibraryMangmentSystemJWT.DTOs.Category;
using LibraryMangmentSystemJWT.Model;

namespace LibraryMangmentSystemJWT
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile() 
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Category, CategoryResponeDTO>().ReverseMap();
        }
    }
}
