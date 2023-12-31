﻿namespace TafWeb.DAL.Entities;

public class TafUser : IdentityUser
{
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public string ImageBase64 { get; init; } = string.Empty;
    public string TwitterUrl { get; init; } = string.Empty;
    public string MastodonUrl { get; init; } = string.Empty;
    public string FacebookUrl { get; init; } = string.Empty;
    public string InstagramUrl { get; init; } = string.Empty;
    public string LinkedInUrl { get; init; } = string.Empty;
    public string GitHubUrl { get; init; } = string.Empty;

    public override bool Equals(object? obj)
    {
        var user = obj as TafUser ?? throw new ArgumentException("obj is not a User");
        return Id == user.Id;
    }

    public override int GetHashCode() => HashCode.Combine(Id);
}
