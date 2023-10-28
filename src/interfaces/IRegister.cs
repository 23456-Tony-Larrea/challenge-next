using WebApplication1.src.models;

namespace WebApplication1.src.interfaces{
    public interface IRegister{
        Users Register(string email, string password,string name);
    }
}
