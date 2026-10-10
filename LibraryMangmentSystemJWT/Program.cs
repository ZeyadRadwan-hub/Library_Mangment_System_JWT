using LibraryMangmentSystemJWT.Database;
using LibraryMangmentSystemJWT.Model;
using LibraryMangmentSystemJWT.Repo.CustomRepo.Contract;
using LibraryMangmentSystemJWT.Repo.CustomRepo.Impelmentation;
using LibraryMangmentSystemJWT.Repo.Generic.Contract;
using LibraryMangmentSystemJWT.Repo.Generic.Implementation;
using LibraryMangmentSystemJWT.UnitOfWork;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
namespace LibraryMangmentSystemJWT
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);



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
            builder.Services.AddScoped<IUserRepo, UserRepo>();


            var Key = Encoding.ASCII.GetBytes(builder.Configuration["JWT:Key"]);
            builder.Services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt =>
            {
                opt.RequireHttpsMetadata = false;
                opt.SaveToken = true;
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = builder.Configuration["JWT:Issuer"],
                    ValidAudience = builder.Configuration["JWT:Audience"]
                };
            });

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
