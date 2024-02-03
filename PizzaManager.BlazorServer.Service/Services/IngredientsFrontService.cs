namespace PizzaManager.BlazorServer.Service.Services;

using System.Net.Http.Json;

using PizzaManager.BlazorServer.Service.Models;

/// <summary>
///     Represents the front service for the <see cref="IngredientModel" />.
/// </summary>
public sealed class IngredientsFrontService
{
    private readonly HttpClient httpClient;

    /// <summary>
    ///     Initializes a new instance of the <see cref="IngredientsFrontService" /> class.
    /// </summary>
    /// <param name="httpClientFactory">The <see cref="IHttpClientFactory" /> to create the <see cref="HttpClient" />.</param>
    public IngredientsFrontService(IHttpClientFactory httpClientFactory)
    {
        this.httpClient = httpClientFactory.CreateClient();
        this.httpClient.BaseAddress = new("https://localhost:7007/");
    }

    /// <summary>
    ///     Gets all the <see cref="IngredientModel" />.
    /// </summary>
    /// <returns>Returns the list of <see cref="IngredientModel" />.</returns>
    public async Task<IEnumerable<IngredientModel>> GetAllAsync()
        => await this.httpClient.GetFromJsonAsync<IEnumerable<IngredientModel>>("ingredients") ?? [];

    /// <summary>
    ///     Gets the <see cref="IngredientModel" /> asynchronously.
    /// </summary>
    /// <param name="ingredientId">The <see cref="PateModel.Id" /> of the <see cref="IngredientModel" /> to get.</param>
    /// <returns>The <see cref="IngredientModel" /> with the specified <paramref name="ingredientId" />; otherwise, <see cref="IngredientModel.Empty" />.</returns>
    public async Task<IngredientModel?> GetAsync(int ingredientId)
        => await this.httpClient.GetFromJsonAsync<IngredientModel>($"ingredients/{ingredientId}");

    /// <summary>
    ///     Deletes the <see cref="IngredientModel" /> with the specified <paramref name="ingredientId" />.
    /// </summary>
    /// <param name="ingredientId">The <see cref="IngredientModel" /> identifier.</param>
    public void Delete(int ingredientId)
        => this.httpClient.DeleteAsync($"ingredients/{ingredientId}");

    /// <summary>
    ///     Creates the <paramref name="newIngredient" />.
    /// </summary>
    /// <param name="newIngredient">The <see cref="IngredientModel" /> to create.</param>
    /// <returns>Return null or an error message.</returns>
    public async Task<string?> CreateAsync(IngredientModel newIngredient)
    {
        var result = await this.httpClient.PostAsJsonAsync("ingredients", newIngredient);
        if (result.IsSuccessStatusCode)
            return null;

        return await result.Content.ReadAsStringAsync();
    }

    /// <summary>
    ///     Updates a <see cref="IngredientModel" /> asynchronously.
    /// </summary>
    /// <param name="ingredient">The <see cref="IngredientModel" /> to update.</param>
    /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
    public async Task UpdateAsync(IngredientModel ingredient)
        => await this.httpClient.PutAsJsonAsync($"ingredients/{ingredient.Id}", ingredient);
}