namespace PizzaManager.RazorPages.Pages.Pate;

using Microsoft.AspNetCore.Mvc.RazorPages;

using PizzaManager.Business.Models;
using PizzaManager.Business.Services;

public class DetailsModel : PageModel
{
    private readonly PateService pateService;

    public DetailsModel(PateService pateService)
        => this.pateService = pateService;


    public PateDto Pate { get; set; } = null!;

    public void OnGet(int id)
    {
        this.Pate = this.pateService.Get(id) ?? new() { Nom = "Pate inexistantee" };
    }
}
