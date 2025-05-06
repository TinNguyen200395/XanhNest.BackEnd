using System;
using Microsoft.AspNetCore.Identity;
using XanhNest.BackEndServer.Application.DTOs.Requests.Auth;
using XanhNest.BackEndServer.Application.Interfaces;
using XanhNest.BackEndServer.Data.Entities;
using XanhNest.BackEndServer.Persistence.Repositories.Interfaces;

namespace XanhNest.BackEndServer.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;

        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<string> LoginAsync(string email, string password)
        {
                var user = await _authRepository.FindByEmailAsync(email);
            if (user == null || !await _authRepository.CheckPasswordAsync(user, password))
                return null;

            return await _authRepository.GenerateJwtToken(user);
        }
        public async Task<IdentityResult> RegisterAsync(RegisterRequest request)
        {
            var user = new User
            {
                UserName = request.Email,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Dob = request.Dob,
                CreatedAt = DateTime.UtcNow,
                IsActive = true
            };

            return await _authRepository.CreateAsync(user, request.Password);
        }
    }

}

