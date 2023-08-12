namespace TafWeb.DAL.Entities;

public record FAQ
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Question { get; init; } = string.Empty;
    public string Answer { get; init; } = string.Empty;
    public VideoCategoryType Category { get; init; }
}
