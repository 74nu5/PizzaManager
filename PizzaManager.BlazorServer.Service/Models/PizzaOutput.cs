namespace PizzaManager.BlazorServer.Service.Models;

public class PizzaOutput
{
    public int? Id { get; set; }

    public string Nom { get; set; } = string.Empty;

    public int PateId { get; set; }

    public int[] IngredientsIds { get; set; } = [];
}
