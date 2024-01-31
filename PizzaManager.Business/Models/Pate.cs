namespace PizzaManager.Business.Models;

public class Pate
{
    public static Pate Empty { get; } = new() { Id = -1, Nom = string.Empty };

    public int Id { get; set; }

    public required string Nom { get; set; }
}
