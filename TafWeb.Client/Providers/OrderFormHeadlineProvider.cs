using System.ComponentModel;
using TafWeb.Shared.Static;

namespace TafWeb.Client.Providers;

public class OrderFormHeadlineProvider
{
    private readonly HttpClient _httpClient;

    public string HeadlineText { get; private set; } = "Objednávkový formulář";

    public OrderFormHeadlineProvider(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task FetchOrderFormHeadlineAsync()
    {
        var response = await _httpClient.GetAsync(ApiEndpoints.OrderFormHeadlineUrl);
        if (response.IsSuccessStatusCode)
        {
            HeadlineText = await response.Content.ReadAsStringAsync();
        }
    }

    public async Task FetchOrderFormHeadlineAsync(string categoryRoute)
    {
        var response = await _httpClient.GetAsync(string.Format(ApiEndpoints.OrderFormHeadlineFromCategoryUrl, categoryRoute));
        if (response.IsSuccessStatusCode)
        {
            HeadlineText = await response.Content.ReadAsStringAsync();
        }
    }
}