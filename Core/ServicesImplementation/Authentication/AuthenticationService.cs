using Domain.Entities;
using Domain.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ServicesAbstraction.Authentication;
using Shared.Dtos;
using Shared.Dtos.UserModule;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ServicesImplementation.Authentication
{
    public class AuthenticationService(UserManager<ApplicationUser> _usermanager , IOptions<JwtOptions> options) : IAuthenticationService
    {
        public async Task<UserResultDto> Login(LoginDto loginDto)
        {
            var User = await _usermanager.FindByEmailAsync(loginDto.Email);

            if (User == null) {
                throw new UnauthorizedException();
            }

            var res = await _usermanager.CheckPasswordAsync(User, loginDto.Password);
            if (!res)
            {
                throw new UnauthorizedException();
            }

            var UserResult = new UserResultDto() { 
                FulllName = User.FullName,
                Email = User.Email,
                Token= await CreateToken(User)
            };

            return UserResult;
        }

        public async Task<UserResultDto> Register(RegisterDto registerDto)
        {
            var newUser = new ApplicationUser()
            {
                FullName = registerDto.FullName,
                Email = registerDto.Email,
                Age = registerDto.Age,
                LevelId = registerDto.LevelId,
                Country = registerDto.Country,
                City = registerDto.City,
                Gender = registerDto.Gender,
                PhoneNumber = registerDto.PhoneNumber,
                UserName= registerDto.Email.Split('@')[0]

            };

            var res = await _usermanager.CreateAsync(newUser,registerDto.Password);

            if (res.Succeeded) {
                var userResult = new UserResultDto()
                {
                    FulllName = newUser.FullName,
                    Email = newUser.Email,
                    Token = await CreateToken(newUser)
                };

                return userResult;
            }
            //throw new Exception("Can't Create The User");
            var errors = res.Errors.Select(e=>e.Description).ToList();

            throw new ValidationException(errors);
        }

        private async Task<string> CreateToken(ApplicationUser user)
        {
            var jwtoptions = options.Value;
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(ClaimTypes.Email , user.Email)
            };

            var roles = await _usermanager.GetRolesAsync(user);
            foreach(var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtoptions.Key));

            var signcreds = new SigningCredentials(key , SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                    issuer:jwtoptions.Issure,
                    audience:jwtoptions.Audiance,
                    claims:claims,
                    expires: DateTime.UtcNow.AddDays(jwtoptions.Expiration),
                    signingCredentials:signcreds

                
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
