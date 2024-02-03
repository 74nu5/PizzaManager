namespace PizzaManager.BlazorServer.Components.Pages.Ingredients;

using Microsoft.AspNetCore.Components;

using PizzaManager.BlazorServer.Service.Models;
using PizzaManager.BlazorServer.Service.Services;

/// <summary>
///     Represents the ingredients page.
/// </summary>
public partial class Ingredients
{
    private IngredientModel newIngredient = IngredientModel.Empty;

    private IEnumerable<IngredientModel> listeIngredients = [];

    /// <summary>
    ///     Gets the <see cref="IngredientsFrontService" />.
    /// </summary>
    [Inject]
    public IngredientsFrontService IngredientService { get; init; } = null!;

    /// <inheritdoc />
    protected override async Task OnInitializedAsync()
        => this.listeIngredients = await this.IngredientService.GetAllAsync();

    private async Task AjouterIngredientAsync()
    {
        await this.IngredientService.CreateAsync(this.newIngredient);
        this.newIngredient = IngredientModel.Empty;
        this.listeIngredients = await this.IngredientService.GetAllAsync();
    }

    private async Task SupprimerIngredientAsync(int id)
    {
        this.IngredientService.Delete(id);
        this.listeIngredients = await this.IngredientService.GetAllAsync();
    }
}