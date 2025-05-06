using System;
using Microsoft.AspNetCore.Identity;
using XanhNest.BackEndServer.Data.Entities;

namespace XanhNest.BackEndServer.Persistence.Repositories.Interfaces
{
    public interface IAuthRepository
    {
        Task<User> FindByEmailAsync(string email);
        Task<IdentityResult> CreateAsync(User user, string password);
        Task<bool> CheckPasswordAsync(User user, string password);
        Task<string> GenerateJwtToken(User user);
    }
}

