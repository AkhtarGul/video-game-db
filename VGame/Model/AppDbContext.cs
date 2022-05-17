using Microsoft.EntityFrameworkCore;

using VGame.Model;

namespace Models
{
  public class AppDbContext : DbContext
  {
    private readonly IConfiguration configuration;

    public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) : base(options)
    {
      this.configuration = configuration;
      this.Database.Migrate();
    }
    public DbSet<Game> Games { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Trailer> Trailers { get; set; }
    public DbSet<Rating> Ratings { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<ParentPlatform> ParentPlatforms { get; set; }
    public DbSet<ScreenShort> ScreenShorts { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      string connectionString = this.configuration.GetConnectionString("DefaultConnection");
      optionsBuilder.UseSqlServer(connectionString);
    }
  }

}
