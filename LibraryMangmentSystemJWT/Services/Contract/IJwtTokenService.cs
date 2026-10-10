using LibraryMangmentSystemJWT.Model;

namespace LibraryMangmentSystemJWT.Services
{
    public interface IJwtTokenService
    {
        (string Token, DateTime Expiration) GenerateToken(User user);
    }
}