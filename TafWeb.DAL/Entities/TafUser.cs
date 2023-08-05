namespace TafWeb.DAL.Entities;

public class TafUser : IdentityUser
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public string? TwitterUrl { get; set; }
    public string? MastodonUrl { get; set; }
    public string? FacebookUrl { get; set; }
    public string? InstagramUrl { get; set; }
    public string? LinkedInUrl { get; set; }
    public string? GitHubUrl { get; set; }

    public override bool Equals(object? obj)
    {
        var user = obj as TafUser ?? throw new ArgumentException("obj is not a User");
        return Id == user.Id;
    }

    public override int GetHashCode() => HashCode.Combine(Id);
}
