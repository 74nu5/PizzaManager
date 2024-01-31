namespace PizzaManager.BlazorServer.Service.Pizzas;

using System.Net.Http.Json;

using PizzaManager.BlazorServer.Service.Models;

public sealed class IngredientsFrontService
{
    private readonly HttpClient httpClient;

    public IngredientsFrontService(IHttpClientFactory httpClientFactory)
    {
        this.httpClient = httpClientFactory.CreateClient();
        this.httpClient.BaseAddress = new("https://localhost:7007/");
    }

    public async Task<IEnumerable<Ingredient>> GetAllAsync()
        => await this.httpClient.GetFromJsonAsync<IEnumerable<Ingredient>>("ingredients") ?? [];

    public void Delete(int ingredientId)
        => this.httpClient.DeleteAsync($"ingredients/{ingredientId}");

    public void Create(Ingredient newIngredient)
        => this.httpClient.PostAsJsonAsync("ingredients", newIngredient);
}
