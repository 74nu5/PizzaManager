namespace PizzaManager.RazorPages.Pages.Pizza;

using Microsoft.AspNetCore.Mvc.RazorPages;

using PizzaManager.Business.Models;
using PizzaManager.Business.Services;

public class DetailsModel : PageModel
{
    private readonly PizzaService pizzaService;

    public DetailsModel(PizzaService pizzaService)
        => this.pizzaService = pizzaService;

    public Pizza Pizza { get; set; } = null!;

    public void OnGet(int id)
        => this.Pizza = this.pizzaService.Get(id) ?? new() { Nom = "Pizza inexistante", Pate = new() { Nom = string.Empty } };
}
