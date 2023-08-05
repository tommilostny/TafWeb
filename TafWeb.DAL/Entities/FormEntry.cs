namespace TafWeb.DAL.Entities;

public record FormEntry
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Message { get; set; }
    public VideoCategoryType VideoCategory { get; set; }
    public DateOnly Date { get; set; }
    public string? Place { get; set; }
}
