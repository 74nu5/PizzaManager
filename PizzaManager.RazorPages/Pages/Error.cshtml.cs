namespace PizzaManager.RazorPages.Pages;

using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
[IgnoreAntiforgeryToken]
public class ErrorModel : PageModel
{
    private readonly ILogger<ErrorModel> logger;

    public ErrorModel(ILogger<ErrorModel> logger)
        => this.logger = logger;

    public string? RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(this.RequestId);

    public void OnGet()
    {
        this.logger.LogError(this.RequestId);
        this.RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier;
    }
}