using Microsoft.AspNetCore.Identity;
using TARetailOrder.ApiService.DataContext.Models;

namespace TARetailOrder.ApiService.Services.PasswordHash
{
    public class PasswordHashAppService: IPasswordHashAppService
    {
        private readonly IPasswordHasher<User> _passwordHasher;
        public PasswordHashAppService()
        {
            _passwordHasher = new PasswordHasher<User>();
        }

        public string HashPassword(string password)
        {
            return _passwordHasher.HashPassword(null, password);
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            var result = _passwordHasher.VerifyHashedPassword(null, hashedPassword, password);
            return result == PasswordVerificationResult.Success ||
                   result == PasswordVerificationResult.SuccessRehashNeeded;
        }
    }
}
