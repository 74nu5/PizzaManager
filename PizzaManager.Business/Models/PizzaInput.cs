namespace PizzaManager.Business.Models;

public class PizzaInput
{
    public int? Id { get; set; }

    public string Nom { get; set; } = string.Empty;

    public int PateId { get; set; }

    public List<int> IngredientsIds { get; set; } = [];
}
