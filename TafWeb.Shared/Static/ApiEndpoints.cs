namespace TafWeb.Shared.Static;

public static class ApiEndpoints
{
#if DEBUG
    public const string ServerBaseUrl = "https://localhost:7110/";
#else
    public const string ServerBaseUrl = "https://skupinataf.azurewebsites.net/";
#endif

    public const string AboutUsBaseUrl = $"{ServerBaseUrl}aboutus";
    public const string AboutUsMainUrl = $"{AboutUsBaseUrl}/main";
    public const string AboutUsDetailUrl = $"{AboutUsBaseUrl}/detail";
    public const string AboutUsEditUrl = $"{AboutUsBaseUrl}/edit";

    public const string ClientFeedbackBaseUrl = $"{ServerBaseUrl}clientfeedback";

    public const string OrderFormBaseUrl = $"{ServerBaseUrl}orderform";
    public const string OrderFormIdUrl = $"{OrderFormBaseUrl}/{{0}}";

    public const string VideoBaseUrl = $"{ServerBaseUrl}video";
    public const string VideoFromCategoryUrl = $"{VideoBaseUrl}/fromcategory/{{0}}";
    public const string VideoFromCategoryAndCountUrl = $"{VideoBaseUrl}/fromcategory/{{0}}/{{1}}";
    public const string VideoDetailUrl = $"{VideoBaseUrl}/detail/{{0}}";
    public const string VideoEditGetUrl = $"{VideoBaseUrl}/edit/{{0}}";
    public const string VideoEditPutUrl = $"{VideoBaseUrl}/edit";
    public const string VideoAddPostUrl = $"{VideoBaseUrl}/add";
    public const string VideoThumbnailUrl = $"{VideoBaseUrl}/thumbnail/{{0}}";

    public const string VideoCategoryBaseUrl = $"{ServerBaseUrl}videocategory";
    public const string VideoCategoryDetailUrl = $"{VideoCategoryBaseUrl}/{{0}}";
    public const string VideoCategoryEditGetUrl = $"{VideoCategoryBaseUrl}/edit/{{0}}";
}
