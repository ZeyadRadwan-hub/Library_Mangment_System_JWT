using AutoMapper;
using LibraryMangmentSystemJWT.DTOs.Member;
using LibraryMangmentSystemJWT.Model;

namespace LibraryMangmentSystemJWT
{
    public class MemberProfile:Profile
    {
        public MemberProfile() 
        {
            CreateMap<Member, MemberDTO>().ReverseMap();
            CreateMap<Member,MemberResponeDTO>().ReverseMap();
        }
    }
}
