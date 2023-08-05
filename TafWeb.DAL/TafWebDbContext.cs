using AspNetCore.Identity.CosmosDb;

namespace TafWeb.DAL;

public class TafWebDbContext : CosmosIdentityDbContext<TafUser, IdentityRole>
{
    public TafWebDbContext(DbContextOptions<TafWebDbContext> options) : base(options)
    {
    }

    public DbSet<VideoCategory> VideoCategories { get; set; }
    public DbSet<AboutUs> AboutUs { get; set; }
    public DbSet<FormEntry> FormEntries { get; set; }

    //protected override void OnModelCreating(ModelBuilder builder)
    //{
    //    base.OnModelCreating(builder);
    //
    //    builder.Entity<IdentityRole>()
    //        .Property(b => b.ConcurrencyStamp)
    //        .IsETagConcurrency();
    //
    //    builder.Entity<TafUser>()
    //        .Property(b => b.ConcurrencyStamp)
    //        .IsETagConcurrency();
    //}
}
