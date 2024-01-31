namespace PizzaManager.RazorPages.Pages.Pizza;

using Microsoft.AspNetCore.Mvc.RazorPages;

using PizzaManager.Business.Models;
using PizzaManager.Business.Services;

public class IndexModel : PageModel
{
    private readonly PizzaService pizzaService;

    /// <inheritdoc />
    public IndexModel(PizzaService pizzaService)
        => this.pizzaService = pizzaService;

    public List<Pizza> Pizzas { get; set; } = [];

    public void OnGet()
        => this.Pizzas = [.. this.pizzaService.GetAll()];
}
