using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApplication5.src.models;



namespace WebApplication5.Data
{
    public class DbContextt : DbContext
    {
        private readonly string? _connectionString;

        public DbSet<tickets> Users { get; set; }
       
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
