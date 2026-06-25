
using Domain.Contracts;
using Domain.Entities;
using LMS.Api.Factories;
using LMS.Api.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Presistence.Data;
using Presistence.Reposatories;
using ServicesAbstraction.Authentication;
using ServicesAbstraction.CourseModule;
using ServicesImplementation;
using ServicesImplementation.Authentication;
using ServicesImplementation.CourseModule;
using Shared.Dtos;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddIdentity<ApplicationUser, IdentityRole<Guid>>(opt =>
            {
                opt.Password.RequireUppercase = true;
                opt.Password.RequireLowercase = true;
                opt.Password.RequireNonAlphanumeric = true;
                opt.Password.RequireDigit = true;
                opt.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<AppDbContext>();

            builder.Services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("JwtOptions"));

            var jwtoptions = builder.Configuration.GetSection("JwtOptions").Get<JwtOptions>();

            builder.Services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ValidAudience = jwtoptions.Audiance,
                    ValidIssuer = jwtoptions.Issure,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtoptions.Key))
                };
            });

            builder.Services.AddAuthorization();

            builder.Services.AddScoped(typeof(IGenericReposatory<>), typeof(GenericReposatory<>));
            builder.Services.AddScoped<IUniteOfWork, UniteOfWork>();
            builder.Services.AddAutoMapper(ctf => { },typeof(ServiceProjectReference).Assembly);
            builder.Services.AddScoped<ICourseService, CourseService>();
            builder.Services.AddScoped<IDbInitializer, DbInitializer>();
            builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

            builder.Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = ApiResponseFactory.CustomResponse;
            });













            var app = builder.Build();

            using var scope = app.Services.CreateScope();
            var dbInitService = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
            await dbInitService.InitializeIdentityAsync();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<CustomExceptionMiddleware>();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
