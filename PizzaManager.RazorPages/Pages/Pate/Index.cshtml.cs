namespace PizzaManager.RazorPages.Pages.Pate;

using Microsoft.AspNetCore.Mvc.RazorPages;

using PizzaManager.Business.Models;
using PizzaManager.Business.Services;

public class IndexModel : PageModel
{
    private readonly PateService pateService;

    /// <inheritdoc />
    public IndexModel(PateService pateService)
        => this.pateService = pateService;

    public List<Pate> Pates { get; set; } = [];

    public void OnGet()
        => this.Pates = [.. this.pateService.GetAll()];
}
