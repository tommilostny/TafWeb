namespace TafWeb.DAL;

#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.

public class TafWebDbContext : CosmosIdentityDbContext<TafUser, IdentityRole>
{
    public TafWebDbContext(DbContextOptions<TafWebDbContext> options) : base(options)
    {
    }

    public DbSet<Video> Videos { get; set; }
    public DbSet<VideoCategory> VideoCategories { get; set; }
    public DbSet<AboutUs> AboutUs { get; set; }
    public DbSet<OrderFormEntry> FormEntries { get; set; }
    public DbSet<OrderFormHeadline> FormHeadlines { get; set; }
    public DbSet<ClientFeedback> ClientFeedbacks { get; set; }
    public DbSet<FAQ> Faqs { get; set; }
}

#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
