using WebApplication1.src.models;

namespace WebApplication1.src.interfaces
{
    public interface IJwtService
    {
        string GenerateToken(Users user);
    }
}