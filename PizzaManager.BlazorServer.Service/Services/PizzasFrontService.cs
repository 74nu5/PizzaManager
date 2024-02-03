namespace PizzaManager.BlazorServer.Service.Services;

using System.Net.Http.Json;

using PizzaManager.BlazorServer.Service.Models;

/// <summary>
///     Represents the front service for the <see cref="PizzaModel" />.
/// </summary>
public sealed class PizzasFrontService
{
    private readonly HttpClient httpClient;

    /// <summary>
    ///     Initializes a new instance of the <see cref="PizzasFrontService" /> class.
    /// </summary>
    /// <param name="httpClientFactory">The <see cref="IHttpClientFactory" /> to create the <see cref="HttpClient" />.</param>
    public PizzasFrontService(IHttpClientFactory httpClientFactory)
    {
        this.httpClient = httpClientFactory.CreateClient();
        this.httpClient.BaseAddress = new("https://localhost:7007/pizza");
    }

    /// <summary>
    ///     Gets all the <see cref="PizzaModel" /> asynchronously.
    /// </summary>
    /// <returns>Returns the list of <see cref="PizzaModel" />.</returns>
    public async Task<IEnumerable<PizzaModel>> GetAllAsync()
        => await this.httpClient.GetFromJsonAsync<IEnumerable<PizzaModel>>(string.Empty) ?? [];

    /// <summary>
    ///     Deletes a <see cref="PizzaModel" /> asynchronously.
    /// </summary>
    /// <param name="id">The <see cref="PizzaModel.Id" /> of the <see cref="PizzaModel" /> to delete.</param>
    /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
    public async Task DeleteAsync(int id)
        => await this.httpClient.DeleteAsync($"{id}");

    /// <summary>
    ///     Creates a <see cref="PizzaModel" /> asynchronously.
    /// </summary>
    /// <param name="newPizza">The <see cref="PizzaModelOutput" /> to create.</param>
    /// <returns>Returns <see langword="null" /> if the <see cref="PizzaModel" /> has been created; otherwise, the error message.</returns>
    public async Task<string?> CreateAsync(PizzaModelOutput newPizza)
    {
        var result = await this.httpClient.PostAsJsonAsync(string.Empty, newPizza);

        if (result.IsSuccessStatusCode)
            return null;

        return await result.Content.ReadAsStringAsync();
    }
}