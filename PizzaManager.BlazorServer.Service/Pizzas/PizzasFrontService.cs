namespace PizzaManager.BlazorServer.Service.Pizzas;

using System.Net.Http.Json;

using PizzaManager.BlazorServer.Service.Models;

public sealed class PizzasFrontService
{
    private readonly HttpClient httpClient;

    public PizzasFrontService(IHttpClientFactory httpClientFactory)
    {
        this.httpClient = httpClientFactory.CreateClient();
        this.httpClient.BaseAddress = new("https://localhost:7007/pizza");
    }

    public async Task<IEnumerable<Pizza>> GetAllAsync()
        => await this.httpClient.GetFromJsonAsync<IEnumerable<Pizza>>(string.Empty) ?? [];

    public async Task DeleteAsync(int id)
        => await this.httpClient.DeleteAsync($"{id}");

    public async Task<string?> CreateAsyc(PizzaOutput newPizza)
    {
        var result = await this.httpClient.PostAsJsonAsync(string.Empty, newPizza);

        if(result.IsSuccessStatusCode)
            return null;

        return await result.Content.ReadAsStringAsync();
    }
}
