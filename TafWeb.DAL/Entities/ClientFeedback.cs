namespace TafWeb.DAL.Entities;

public record ClientFeedback
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Name { get; init; } = string.Empty;
    public string Text { get; init; } = string.Empty;
    public string ImageBase64 { get; init; } = string.Empty;
}
