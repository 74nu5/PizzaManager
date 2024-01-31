namespace PizzaManager.RazorPages.Pages.Pate;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using PizzaManager.Business.Models;
using PizzaManager.Business.Services;

public class EditModel : PageModel
{
    private readonly PateService pateService;

    public EditModel(PateService pateService)
        => this.pateService = pateService;

    [BindProperty]
    public Pate Pate { get; set; } = new() { Nom = "Pate par défaut" };

    public void OnGet(int id)
        => this.Pate = this.pateService.Get(id) ?? new() { Nom = "Pate inexistant" };

    public IActionResult OnPost(int id)
    {
        this.pateService.Update(id, this.Pate);
        return this.RedirectToPage("./Index");
    }
}
