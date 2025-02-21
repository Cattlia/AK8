using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;


 public class VehicleContext : DbContext
 {        public VehicleContext(DbContextOptions<VehicleContext> options) : base(options) { }

        public DbSet<Car> Cars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();

    var connectionString = configuration.GetConnectionString("DefaultConnection");
    optionsBuilder
        .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
        .LogTo(Console.WriteLine, LogLevel.Information);
}

 }
 