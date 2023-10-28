using System.Data;

namespace WebApplication1.src.models
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string token { get; set; }
    
    public Users(){
        Name=string.Empty;
        Email=string.Empty; 
        Password=string.Empty;
        token=string.Empty;
    }
    }
}
