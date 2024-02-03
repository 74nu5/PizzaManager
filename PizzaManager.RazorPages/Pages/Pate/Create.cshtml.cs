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
    public PateDto Pate { get; set; } = PateDto.Empty;

    public async Task<IActionResult> OnPost()
    {
        if (!this.ModelState.IsValid)
            return this.Page();

        await this.pateService.CreateAsync(this.Pate, CancellationToken.None);
        return this.RedirectToPage("./Index");
    }
}
