using LibraryMangmentSystemJWT.Model;

namespace LibraryMangmentSystemJWT.Repo.CustomRepo.Contract
{
    public interface IUserRepo
    {
        Task<User?> GetByUserNameAsync(string userName);
    }
}
