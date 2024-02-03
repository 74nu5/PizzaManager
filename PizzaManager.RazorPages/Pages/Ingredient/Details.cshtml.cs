namespace PizzaManager.RazorPages.Pages.Ingredient;

using Microsoft.AspNetCore.Mvc.RazorPages;

using PizzaManager.Business.Models;
using PizzaManager.Business.Services;

public class DetailsModel : PageModel
{
    private readonly IngredientService ingredientService;

    public DetailsModel(IngredientService ingredientService)
        => this.ingredientService = ingredientService;

    public IngredientDto Ingredient { get; set; } = null!;

    public void OnGet(int id)
        => this.Ingredient = this.ingredientService.Get(id) ?? new() { Nom = "Ingredient inexistant" };
}
