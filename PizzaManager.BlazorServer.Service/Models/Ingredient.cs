namespace PizzaManager.BlazorServer.Service.Models;
public class Ingredient
{
    public static Ingredient Empty { get; } = new() { Id = -1, Nom = string.Empty, NCal = 0 };

    public int Id { get; set; }

    public required string Nom { get; set; }

    public double NCal { get; set; }
}
