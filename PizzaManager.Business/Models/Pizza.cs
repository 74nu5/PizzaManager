namespace PizzaManager.Business.Models;

public class Pizza
{
    public static Pizza Empty { get; } = new() { Id = -1, Nom = string.Empty, Pate = Pate.Empty };

    public int Id { get; set; }

    public string Nom { get; set; } = string.Empty;

    public Pate Pate { get; set; } = Pate.Empty;

    public List<Ingredient> Ingredients { get; } = [];
}
