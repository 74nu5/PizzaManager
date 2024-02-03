namespace PizzaManager.BlazorServer.Components.Pages.Pizza;

using Microsoft.AspNetCore.Components;

using PizzaManager.BlazorServer.Service.Models;
using PizzaManager.BlazorServer.Service.Services;

/// <summary>
///     Represents the pizzas page.
/// </summary>
public partial class Pizzas
{
    private PizzaModelOutput newPizza = new();

    private IEnumerable<PizzaModel> listePizzas = [];

    private IEnumerable<PateModel> listePates = [];

    private IEnumerable<IngredientModel> listeIngredients = [];

    private bool hasError;

    private string errorMessage = string.Empty;

    /// <summary>
    ///     Gets the <see cref="PizzasFrontService" />.
    /// </summary>
    [Inject]
    public PizzasFrontService PizzaService { get; init; } = null!;

    /// <summary>
    ///     Gets the <see cref="IngredientsFrontService" />.
    /// </summary>
    [Inject]
    public IngredientsFrontService IngredientService { get; init; } = null!;

    /// <summary>
    ///     Gets the <see cref="PatesFrontService" />.
    /// </summary>
    [Inject]
    public PatesFrontService PateService { get; init; } = null!;

    /// <inheritdoc />
    protected override async Task OnInitializedAsync()
    {
        this.listePizzas = await this.PizzaService.GetAllAsync();
        this.listePates = await this.PateService.GetAllAsync();
        this.listeIngredients = await this.IngredientService.GetAllAsync();
    }

    private async Task AjouterPizzaAsync()
    {
        var result = await this.PizzaService.CreateAsync(this.newPizza);
        if (result is not null)
        {
            this.hasError = true;
            this.errorMessage = result;
            return;
        }

        this.hasError = false;
        this.errorMessage = string.Empty;
        this.newPizza = new();
        this.listePizzas = await this.PizzaService.GetAllAsync();
    }

    private async Task SupprimerPizzaAsync(int id)
        => await this.PizzaService.DeleteAsync(id);
}