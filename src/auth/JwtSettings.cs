using Microsoft.Extensions.Configuration;

namespace WebApplication1.Configuration
{
    public class JwtSettings
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string SecretKey { get; set; }
        public int ExpirationInMinutes { get; set; }

        public static JwtSettings FromConfiguration(IConfiguration configuration)
        {
            return configuration.GetSection("JwtSettings").Get<JwtSettings>();
        }
        public JwtSettings(){
            Issuer=string.Empty;
            Audience=string.Empty;
            SecretKey=string.Empty;
            ExpirationInMinutes=0;
        }
    }
}