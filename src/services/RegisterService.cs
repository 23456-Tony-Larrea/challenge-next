using Microsoft.AspNetCore.Identity;
using WebApplication1.Data;
using WebApplication1.src.interfaces;
using WebApplication1.src.models;

namespace WebApplication1.src.services{
public class RegisterService:IRegister{
    private readonly DbContextt _context;
    private readonly IPasswordHasher<Users> _passwordHasher;

    public RegisterService(DbContextt context, IPasswordHasher<Users> passwordHasher)
    {
        _context = context;
        _passwordHasher = passwordHasher;
    }
    //usa un login 
public Users Register(string email, string password, string name)
{
    try
    {
        var user = _context.Users.FirstOrDefault(u => u.Email == email);
        if (user == null)
        {
            var newUser = new Users
            {
                Email = email,
                Password = _passwordHasher.HashPassword(null!, password),
                Name = name
            };
            _context.Users.Add(newUser);
            _context.SaveChanges();
            return newUser;
        }
        return null!;
    }
    catch (Exception ex)
    {
        // Log the exception
        Console.WriteLine(ex.Message);
        return null!;
    }
}
}
}