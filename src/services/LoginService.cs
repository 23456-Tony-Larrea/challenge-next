using Microsoft.AspNetCore.Identity;
using WebApplication1.Data;

using WebApplication1.src.models;
using WebApplication1.src.interfaces;

public class LoginService : ILogin
{
    private readonly DbContextt _context;
    private readonly IPasswordHasher<Users> _passwordHasher;

    public LoginService(DbContextt context, IPasswordHasher<Users> passwordHasher)
    {
        _context = context;
        _passwordHasher = passwordHasher;
    }
    //usa un login 
    public Users Login(string email, string password)
    {
        var user = _context.Users.FirstOrDefault(u => u.Email == email);
        if (user != null)
        {
            var result = _passwordHasher.VerifyHashedPassword(user, user.Password, password);
            if (result == PasswordVerificationResult.Success)
            {
                return user!;
            }
        }
        return null!;
    }
}
