using WebApplication1.src.models;

namespace WebApplication1.src.interfaces{
    public interface ILogin{
        Users Login(string email, string password);
    }
}
