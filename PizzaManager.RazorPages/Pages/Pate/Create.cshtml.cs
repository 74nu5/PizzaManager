namespace PizzaManager.RazorPages.Pages.Pate;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using PizzaManager.Business.Models;
using PizzaManager.Business.Services;

public class CreateModel : PageModel
{
    private readonly PateService pateService;

    public CreateModel(PateService pateService)
        => this.pateService = pateService;

    [BindProperty]
    public Pate Pate { get; set; } = Pate.Empty;

    public IActionResult OnPost()
    {
        if (!this.ModelState.IsValid)
            return this.Page();

        this.pateService.Create(this.Pate);
        return this.RedirectToPage("./Index");
    }
}
