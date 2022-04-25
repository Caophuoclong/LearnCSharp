using Microsoft.EntityFrameworkCore;
using aspcore.Models;
namespace aspcore.Data
{
    public class MovieContext : DbContext
    {
        public DbSet<Movie> Movie { get; set; }
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var configurationRoot = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            optionsBuilder.UseSqlServer(configurationRoot.GetConnectionString("db1"));
        }

    }
}