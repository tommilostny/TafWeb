namespace TafWeb.DAL.Entities;

public record OrderFormHeadline
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Text { get; init; } = string.Empty;
    public int VideoCategory { get; init; } = -1;
}
