using Shared.Dtos.UserModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesAbstraction.Authentication
{
    public interface IAuthenticationService
    {
        Task<UserResultDto>Login(LoginDto loginDto);

        Task<UserResultDto>Register(RegisterDto registerDto);
    }
}
