using Domain.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistence.Data
{
    public class DbInitializer(UserManager<ApplicationUser> _usermanager, RoleManager<IdentityRole<Guid>> _rolemanager) : IDbInitializer
    {
        public async Task InitializeIdentityAsync()
        {
            if (!_rolemanager.Roles.Any())
            {

                var AdminRole = new IdentityRole<Guid>("Admin");
                var UserRole = new IdentityRole<Guid>("User");

                await _rolemanager.CreateAsync(AdminRole);
                await _rolemanager.CreateAsync(UserRole);

            }
            if (!_usermanager.Users.Any())
            {

                var AdminUser = new ApplicationUser()
                {
                    FullName = "TeamBrandify",

                    Age = 22,

                    Gender = "Male",

                    Country = "Egypt",

                    City = "Cairo",

                    LevelId = null,

                    Email = "Brandify@gmail.com",
                    UserName = "Brandify",

                    PhoneNumber = "01558921462"

                   
                };

                await _usermanager.CreateAsync(AdminUser,"BrandifyTeam2026@LMS");
                await _usermanager.AddToRoleAsync(AdminUser , "Admin");
            }
        }
    }
}
