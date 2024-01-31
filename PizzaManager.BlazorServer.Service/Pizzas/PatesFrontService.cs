namespace PizzaManager.BlazorServer.Service.Pizzas;

using System.Net.Http.Json;

using PizzaManager.BlazorServer.Service.Models;

public sealed class PatesFrontService
{
    private readonly HttpClient httpClient;

    public PatesFrontService(IHttpClientFactory httpClientFactory)
    {
        this.httpClient = httpClientFactory.CreateClient();
        this.httpClient.BaseAddress = new("https://localhost:7007/pates");
    }

    public async Task<IEnumerable<Pate>> GetAllAsync()
        => await this.httpClient.GetFromJsonAsync<IEnumerable<Pate>>(string.Empty) ?? [];

    public async Task DeleteAsync(int pateId)
        => await this.httpClient.DeleteAsync($"{pateId}");

    public async Task CreateAsync(Pate newPate)
        => await this.httpClient.PostAsJsonAsync(string.Empty, newPate);

    public async Task UpdateAsync(Pate pate)
        => await this.httpClient.PutAsJsonAsync($"{pate.Id}", pate);

    public async Task<Pate> GetAsync(int pateId)
        => await this.httpClient.GetFromJsonAsync<Pate>($"{pateId}") ?? Pate.Empty;
}
