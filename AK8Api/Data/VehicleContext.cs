using Microsoft.EntityFrameworkCore;

public class VehicleContext : DbContext
{
    public VehicleContext(DbContextOptions<VehicleContext> options) : base(options) { }

    public DbSet<Car> cars { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>(entity =>
        {
            entity.ToTable("cars");
            entity.Property(c => c.Id).HasColumnName("id");
            entity.Property(c => c.Type).HasColumnName("type");
            entity.Property(c => c.Color).HasColumnName("color");
            entity.Property(c => c.WindowType).HasColumnName("window_type");
            entity.Property(c => c.CreatedAt).HasColumnName("created_at");
        });
    }
}