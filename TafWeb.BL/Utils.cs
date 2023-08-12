namespace TafWeb.BL;

internal static class Utils
{
    internal static string[] SplitByNewLine(string text) => text.Split('\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

    internal static string JoinByNewLine(string[] paragraphs) => string.Join('\n', paragraphs);
}
