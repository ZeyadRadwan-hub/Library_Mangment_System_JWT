using LibraryMangmentSystemJWT.DTOs.Member;
using LibraryMangmentSystemJWT.Model;

namespace LibraryMangmentSystemJWT.Repo.CustomRepo.Contract
{
    public interface IMember
    {
        List<MemberGetAllDTO> GetAllMembers();
        MemberGetByIdDTO GetById(int id);
    }
}
