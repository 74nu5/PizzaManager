namespace PizzaManager.BlazorServer.Components.Pages.Pates;

using Microsoft.AspNetCore.Components;

using PizzaManager.BlazorServer.Service.Models;
using PizzaManager.BlazorServer.Service.Services;

/// <summary>
///     Represents the pates page.
/// </summary>
public sealed partial class Pates
{
    private string newPateNom = string.Empty;

    private IEnumerable<PateModel> listePates = [];

    /// <summary>
    ///     Gets the <see cref="PatesFrontService" />.
    /// </summary>
    [Inject]
    public PatesFrontService PatesFrontService { get; init; } = null!;

    /// <inheritdoc />
    protected override async Task OnInitializedAsync()
    {
        this.listePates = await this.PatesFrontService.GetAllAsync();
        await base.OnInitializedAsync();
    }

    private async Task SupprimerPateAsync(int pateId)
    {
        await this.PatesFrontService.DeleteAsync(pateId);
        this.listePates = await this.PatesFrontService.GetAllAsync();
    }

    private async Task AjouterPateAsync()
    {
        await this.PatesFrontService.CreateAsync(new() { Nom = this.newPateNom });
        this.listePates = await this.PatesFrontService.GetAllAsync();
    }
}