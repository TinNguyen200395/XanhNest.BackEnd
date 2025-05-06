using System;
namespace XanhNest.BackEndServer.Application.DTOs.Requests
{
    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }
    }
}

