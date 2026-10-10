using LibraryMangmentSystemJWT.Database;
using LibraryMangmentSystemJWT.Model;
using LibraryMangmentSystemJWT.Repo.CustomRepo.Contract;
using LibraryMangmentSystemJWT.Repo.CustomRepo.Impelmentation;
using LibraryMangmentSystemJWT.Repo.Generic.Contract;
using LibraryMangmentSystemJWT.Repo.Generic.Implementation;
using LibraryMangmentSystemJWT.Services;
using LibraryMangmentSystemJWT.UnitOfWork;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
namespace LibraryMangmentSystemJWT
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var jwtKeyValue = builder.Configuration["Jwt:Key"]
    ?? throw new InvalidOperationException("JWT Key is missing.");

            byte[] jwtKeyBytes;

            try
            {
                jwtKeyBytes = Convert.FromBase64String(jwtKeyValue);
            }
            catch (FormatException ex)
            {
                throw new InvalidOperationException(
                    "JWT Key must be a valid Base64 string.", ex);
            }

            if (jwtKeyBytes.Length < 32)
            {
                throw new InvalidOperationException(
                    "JWT Key must contain at least 32 bytes.");
            }

            var jwtIssuer = builder.Configuration["Jwt:Issuer"]
                ?? throw new InvalidOperationException("JWT Issuer is missing.");

            var jwtAudience = builder.Configuration["Jwt:Audience"]
                ?? throw new InvalidOperationException("JWT Audience is missing.");

            builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();

            builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

            builder.Services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme =
                        JwtBearerDefaults.AuthenticationScheme;

                    options.DefaultChallengeScheme =
                        JwtBearerDefaults.AuthenticationScheme;

                    options.DefaultForbidScheme =
                        JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = jwtIssuer,

                        ValidateAudience = true,
                        ValidAudience = jwtAudience,

                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(jwtKeyBytes),

                        ValidateLifetime = true,
                        RequireExpirationTime = true,

                        ClockSkew = TimeSpan.Zero,

                        NameClaimType = ClaimTypes.Name,
                        RoleClaimType = ClaimTypes.Role
                    };
                });

            builder.Services.AddAuthorization();


            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext
                <App_database_Context>(opt=>opt.UseSqlServer
                (builder.Configuration.GetConnectionString("Con")));
            builder.Services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));
            builder.Services.AddScoped<IMember, MemberRepo>();
            builder.Services.AddScoped<ICategory, CategoryRepo>();
            builder.Services.AddScoped<IBook, BookRepo>();
            builder.Services.AddScoped<IBorrowing,BorrowingRepo>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWorkIMP>();
            builder.Services.AddAutoMapper(typeof(Program).Assembly);
            builder.Services.AddScoped< IPasswordHasher<User>,PasswordHasher<User>>();
            builder.Services.AddScoped<IJwtTokenService,JwtTokenService>();
            builder.Services.AddScoped<IUserRepo, UserRepo>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
