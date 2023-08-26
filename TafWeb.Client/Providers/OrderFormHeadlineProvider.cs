using Microsoft.JSInterop;
using TafWeb.Shared.Static;

namespace TafWeb.Client.Providers;

public class OrderFormHeadlineProvider : IAsyncDisposable
{
    private readonly HttpClient _httpClient;
    private readonly IJSRuntime _jsRuntime;
    private IJSObjectReference? _jsModule;

    public OrderFormHeadlineProvider(HttpClient httpClient, IJSRuntime jsRuntime)
    {
        _httpClient = httpClient;
        _jsRuntime = jsRuntime;
    }

    public async ValueTask DisposeAsync()
    {
        if (_jsModule is not null)
        {
            await _jsModule.DisposeAsync();
        }
        GC.SuppressFinalize(this);
    }

    public async Task FetchOrderFormHeadlineAsync()
    {
        var response = await _httpClient.GetAsync(ApiEndpoints.OrderFormHeadlineUrl);
        await SetHeadlineElementAsync(response);
    }

    public async Task FetchOrderFormHeadlineAsync(string categoryRoute)
    {
        var response = await _httpClient.GetAsync(string.Format(ApiEndpoints.OrderFormHeadlineFromCategoryUrl, categoryRoute));
        await SetHeadlineElementAsync(response);
    }

    private async Task SetHeadlineElementAsync(HttpResponseMessage response)
    {
        if (!response.IsSuccessStatusCode)
            return;

        _jsModule ??= await _jsRuntime.InvokeAsync<IJSObjectReference>("import", "/js/orderFormHeadline.js");
        var content = await response.Content.ReadAsStringAsync();
        await _jsModule.InvokeVoidAsync("setOrderFormHeadline", content);
    }
}
