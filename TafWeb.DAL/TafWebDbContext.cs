using AspNetCore.Identity.CosmosDb;

namespace TafWeb.DAL;

public class TafWebDbContext : CosmosIdentityDbContext<TafUser, IdentityRole>
{
    public TafWebDbContext(DbContextOptions<TafWebDbContext> options) : base(options)
    {
    }

    public DbSet<Video> Videos { get; set; }
    public DbSet<VideoCategory> VideoCategories { get; set; }
    public DbSet<AboutUs> AboutUs { get; set; }
    public DbSet<OrderFormEntry> FormEntries { get; set; }
    public DbSet<ClientFeedback> ClientFeedbacks { get; set; }
    public DbSet<FAQ> Faqs { get; set; }
}
