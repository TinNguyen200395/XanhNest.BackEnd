using System;
using Microsoft.AspNetCore.Identity;
using XanhNest.BackEndServer.Application.DTOs.Requests.Auth;

namespace XanhNest.BackEndServer.Application.Interfaces
{
    public interface IAuthService
    {
        Task<string> LoginAsync(string email, string password);
        Task<IdentityResult> RegisterAsync(RegisterRequest request);

    }
}

