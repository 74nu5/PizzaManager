namespace PizzaManager.BlazorServer.Components.Pages.Ingredients;

using Microsoft.AspNetCore.Components;

using PizzaManager.BlazorServer.Service.Models;
using PizzaManager.BlazorServer.Service.Pizzas;

public partial class Ingredients
{
    private Ingredient newIngredient = Ingredient.Empty;

    [Inject]
    public IngredientsFrontService IngredientService { get; set; } = null!;

    private IEnumerable<Ingredient> ListeIngredients { get; set; } = [];

    protected override async Task OnInitializedAsync()
    {
        this.ListeIngredients = await this.IngredientService.GetAllAsync();
    }

    private async Task AjouterIngredient()
    {
        this.IngredientService.Create(this.newIngredient);
        this.newIngredient = Ingredient.Empty;
        this.ListeIngredients = await this.IngredientService.GetAllAsync();
    }

    private async Task SupprimerIngredient(int id)
    {
        this.IngredientService.Delete(id);
        this.ListeIngredients = await this.IngredientService.GetAllAsync();
    }
}
