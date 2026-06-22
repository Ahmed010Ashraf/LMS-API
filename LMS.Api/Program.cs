
using Domain.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Presistence.Data;
using Presistence.Reposatories;
using ServicesAbstraction.CourseModule;
using ServicesImplementation;
using ServicesImplementation.CourseModule;
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

            builder.Services.AddScoped(typeof(IGenericReposatory<>), typeof(GenericReposatory<>));
            builder.Services.AddScoped<IUniteOfWork, UniteOfWork>();
            builder.Services.AddAutoMapper(ctf => { },typeof(ServiceProjectReference).Assembly);
            builder.Services.AddScoped<ICourseService, CourseService>();
            builder.Services.AddScoped<IDbInitializer, DbInitializer>();
        














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

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
