namespace TARetailOrder.ApiService.Services.PasswordHash
{
    public interface IPasswordHashAppService
    {
        string HashPassword(string password);
        bool VerifyPassword(string password, string hashedPassword);
    }
}