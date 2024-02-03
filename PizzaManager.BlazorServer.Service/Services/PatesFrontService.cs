namespace PizzaManager.BlazorServer.Service.Services;

using System.Net.Http.Json;

using PizzaManager.BlazorServer.Service.Models;

/// <summary>
///    Represents the front service for the <see cref="PateModel" />.
/// </summary>
public sealed class PatesFrontService
{
    private readonly HttpClient httpClient;

    /// <summary>
    /// Initializes a new instance of the <see cref="PatesFrontService"/> class.
    /// </summary>
    /// <param name="httpClientFactory">
    /// The <see cref="IHttpClientFactory"/> to create the <see cref="HttpClient"/>.
    /// </param>
    public PatesFrontService(IHttpClientFactory httpClientFactory)
    {
        this.httpClient = httpClientFactory.CreateClient();
        this.httpClient.BaseAddress = new("https://localhost:7007/pates");
    }

    /// <summary>
    /// Gets all the <see cref="PateModel"/> asynchronously.
    /// </summary>
    /// <returns>Returns the list of <see cref="PateModel"/>.</returns>
    public async Task<IEnumerable<PateModel>> GetAllAsync()
        => await this.httpClient.GetFromJsonAsync<IEnumerable<PateModel>>(string.Empty) ?? [];

    /// <summary>
    /// Gets the <see cref="PateModel"/> asynchronously.
    /// </summary>
    /// <param name="pateId">The <see cref="PateModel.Id"/> of the <see cref="PateModel"/> to get.</param>
    /// <returns>The <see cref="PateModel"/> with the specified <paramref name="pateId"/>; otherwise, <see cref="PateModel.Empty"/>.</returns>
    public async Task<PateModel> GetAsync(int pateId)
        => await this.httpClient.GetFromJsonAsync<PateModel>($"{pateId}") ?? PateModel.Empty;

    /// <summary>
    /// Deletes a <see cref="PateModel"/> asynchronously.
    /// </summary>
    /// <param name="pateId">The <see cref="PateModel.Id"/> of the <see cref="PateModel"/> to delete.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task DeleteAsync(int pateId)
        => await this.httpClient.DeleteAsync($"{pateId}");

    /// <summary>
    /// Creates a <see cref="PateModel"/> asynchronously.
    /// </summary>
    /// <param name="newPate">The <see cref="PateModel"/> to create.</param>
    /// <returns>Returns <see langword="null"/> if the <see cref="PateModel"/> has been created; otherwise, the error message.</returns>
    public async Task<string?> CreateAsync(PateModel newPate)
    {
        var result = await this.httpClient.PostAsJsonAsync(string.Empty, newPate);

        if (result.IsSuccessStatusCode)
            return null;

        return await result.Content.ReadAsStringAsync();
    }

    /// <summary>
    /// Updates a <see cref="PateModel"/> asynchronously.
    /// </summary>
    /// <param name="pate">The <see cref="PateModel"/> to update.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task UpdateAsync(PateModel pate)
        => await this.httpClient.PutAsJsonAsync($"{pate.Id}", pate);
}