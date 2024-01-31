namespace PizzaManager.RazorPages.Pages.Pate;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using PizzaManager.Business.Models;
using PizzaManager.Business.Services;

public class DeleteModel : PageModel
{
    private PateService pateService;

    public DeleteModel(PateService pateService)
        => this.pateService = pateService;

    public Pate Pate { get; set; } = null!;

    public void OnGet(int id)
    {
        this.Pate = this.pateService.Get(id) ?? new() { Nom = "Pate inexistante" };
    }

    public IActionResult OnPost(int id)
    {
        this.pateService.Delete(id);
        return this.RedirectToPage("./Index");
    }
}
