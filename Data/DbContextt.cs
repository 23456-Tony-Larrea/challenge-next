using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApplication1.src.models;



namespace WebApplication1.Data
{
    public class DbContextt : DbContext
    {
        private readonly string? _connectionString;

        public DbSet<Users> Users { get; set; }
       
        public DbContextt(DbContextOptions<DbContextt> options, IConfiguration configuration) : base(options)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
