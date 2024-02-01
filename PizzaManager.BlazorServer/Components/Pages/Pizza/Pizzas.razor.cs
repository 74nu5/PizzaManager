namespace PizzaManager.BlazorServer.Components.Pages.Pizza;

using Microsoft.AspNetCore.Components;

using PizzaManager.BlazorServer.Service.Models;
using PizzaManager.BlazorServer.Service.Pizzas;

public partial class Pizzas
{
    private PizzaOutput newPizza = new();

    private IEnumerable<Pizza> listePizzas = [];

    private IEnumerable<Pate> listePates = [];

    private IEnumerable<Ingredient> listeIngredients = [];

    private bool hasError;

    private string errorMessage;

    [Inject]
    private PizzasFrontService PizzaService { get; set; } = null!;

    [Inject]
    private IngredientsFrontService IngredientService { get; set; } = null!;

    [Inject]
    private PatesFrontService PateService { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        this.listePizzas = await this.PizzaService.GetAllAsync();
        this.listePates = await this.PateService.GetAllAsync();
        this.listeIngredients = await this.IngredientService.GetAllAsync();
    }

    private async Task AjouterPizza()
    {
        var result = await this.PizzaService.CreateAsyc(this.newPizza);
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

    private async Task SupprimerPizza(int id)
    {
        await this.PizzaService.DeleteAsync(id);
    }
}
