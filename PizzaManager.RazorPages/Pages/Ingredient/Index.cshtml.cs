namespace PizzaManager.RazorPages.Pages.Ingredient;

using Microsoft.AspNetCore.Mvc.RazorPages;

using PizzaManager.Business.Models;
using PizzaManager.Business.Services;

public class IndexModel : PageModel
{
    private readonly IngredientService ingredientService;

    /// <inheritdoc />
    public IndexModel(IngredientService ingredientService)
        => this.ingredientService = ingredientService;

    public List<Ingredient> Ingredients { get; set; } = [];

    public void OnGet()
        => this.Ingredients = [.. this.ingredientService.GetAll()];
}
