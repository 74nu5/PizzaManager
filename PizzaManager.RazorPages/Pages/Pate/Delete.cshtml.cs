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

    public PateDto Pate { get; set; } = null!;

    public void OnGet(int id)
    {
        this.Pate = this.pateService.Get(id) ?? new() { Nom = "Pate inexistante" };
    }

    public async Task<IActionResult> OnPost(int id)
    {
        await this.pateService.DeleteAsync(id, CancellationToken.None);
        return this.RedirectToPage("./Index");
    }
}
