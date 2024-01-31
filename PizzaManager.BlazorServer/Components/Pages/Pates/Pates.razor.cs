namespace PizzaManager.BlazorServer.Components.Pages.Pates;

using Microsoft.AspNetCore.Components;

using PizzaManager.BlazorServer.Service.Models;
using PizzaManager.BlazorServer.Service.Pizzas;

public sealed partial class Pates
{
    private string newPateNom = string.Empty;

    [Inject]
    public PatesFrontService PatesFrontService { get; set; } = null!;

    public IEnumerable<Pate> ListePates { get; set; } = [];

    public async Task SupprimerPate(int pateId)
    {
        await this.PatesFrontService.DeleteAsync(pateId);
        this.ListePates = await this.PatesFrontService.GetAllAsync();
    }

    protected override async Task OnInitializedAsync()
    {
        this.ListePates = await this.PatesFrontService.GetAllAsync();
        await base.OnInitializedAsync();
    }

    private async Task AjouterPate()
    {
        await this.PatesFrontService.CreateAsync(new() { Nom = this.newPateNom });
        this.ListePates = await this.PatesFrontService.GetAllAsync();
    }
}
