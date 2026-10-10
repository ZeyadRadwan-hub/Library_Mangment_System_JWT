using LibraryMangmentSystemJWT.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace LibraryMangmentSystemJWT.Services
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly IConfiguration _configuration;

        public JwtTokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public (string Token, DateTime Expiration) GenerateToken(User user)
        {
            var keyValue = _configuration["Jwt:Key"];
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var expirationValue = _configuration["Jwt:ExpirationMinutes"];

            if (string.IsNullOrWhiteSpace(keyValue))
            {
                throw new InvalidOperationException("JWT Key is missing.");
            }

            if (string.IsNullOrWhiteSpace(issuer) ||
                string.IsNullOrWhiteSpace(audience))
            {
                throw new InvalidOperationException(
                    "JWT Issuer and Audience are required.");
            }

            if (!int.TryParse(expirationValue, out var minutes) ||
                minutes <= 0)
            {
                throw new InvalidOperationException(
                    "JWT ExpirationMinutes must be positive.");
            }

            byte[] keyBytes;

            try
            {
                keyBytes = Convert.FromBase64String(keyValue);
            }
            catch (FormatException ex)
            {
                throw new InvalidOperationException(
                    "JWT Key must be a valid Base64 string.", ex);
            }

            if (keyBytes.Length < 32)
            {
                throw new InvalidOperationException(
                    "JWT Key must contain at least 32 bytes.");
            }

            var claims = new List<Claim>
            {
                new Claim(
                    ClaimTypes.NameIdentifier,
                    user.Id.ToString()),

                new Claim(
                    ClaimTypes.Name,
                    user.UserName),

                new Claim(
                    ClaimTypes.Role,
                    user.Role)
            };

            var securityKey = new SymmetricSecurityKey(keyBytes);

            var credentials = new SigningCredentials(
                securityKey,
                SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddMinutes(minutes);

            var tokenObject = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: expiration,
                signingCredentials: credentials);

            var token = new JwtSecurityTokenHandler()
                .WriteToken(tokenObject);

            return (token, expiration);
        }
    }
}