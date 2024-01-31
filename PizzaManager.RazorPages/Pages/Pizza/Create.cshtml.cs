namespace PizzaManager.RazorPages.Pages.Pizza;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

using PizzaManager.Business.Models;
using PizzaManager.Business.Services;

public class CreateModel : PageModel
{
    private readonly PizzaService pizzaService;

    private readonly PateService pateService;

    private readonly IngredientService ingredientService;

    public CreateModel(PizzaService pizzaService, PateService pateService, IngredientService ingredientService)
    {
        this.pizzaService = pizzaService;
        this.pateService = pateService;
        this.ingredientService = ingredientService;
    }

    [BindProperty]
    public Pizza Pizza { get; set; } = Pizza.Empty;

    [BindProperty]
    public int[] IngredientsIds { get; set; } = [];

    public void OnGet()
    {
        this.ViewData["SelectPates"] = this.pateService.GetAll()
                                           .Select(p => new SelectListItem(p.Nom, p.Id.ToString()));
        this.ViewData["SelectIngredients"] = this.ingredientService.GetAll()
                                                 .Select(i => new SelectListItem(i.Nom, i.Id.ToString()));
    }

    public IActionResult OnPost()
    {
        if (!this.ModelState.IsValid)
            return this.Page();

        var pate = this.pateService.Get(this.Pizza.Pate.Id);
        if (pate is not null)
            this.Pizza.Pate = pate;

        foreach (var ingredientsId in this.IngredientsIds)
        {
            var ingredient = this.ingredientService.Get(ingredientsId);
            if (ingredient is not null)
                this.Pizza.Ingredients.Add(ingredient);
        }

        //this.pizzaService.Create(this.Pizza);
        return this.RedirectToPage("./Index");
    }
}
