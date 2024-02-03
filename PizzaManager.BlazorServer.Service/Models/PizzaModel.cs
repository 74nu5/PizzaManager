namespace PizzaManager.BlazorServer.Service.Models;

/// <summary>
///     Represents a pizza.
/// </summary>
public sealed class PizzaModel
{
    /// <summary>
    ///     Gets the empty <see cref="PizzaModel" /> object.
    /// </summary>
    public static PizzaModel Empty { get; } = new() { Id = -1, Nom = string.Empty, Pate = PateModel.Empty };

    /// <summary>
    ///     Gets or sets the <see cref="Id" /> of the <see cref="PizzaModel" />.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    ///     Gets or sets the name of the <see cref="PizzaModel" />.
    /// </summary>
    public string Nom { get; set; } = string.Empty;

    /// <summary>
    ///     Gets or sets the <see cref="Pate" /> of the <see cref="PizzaModel" />.
    /// </summary>
    public PateModel Pate { get; set; } = PateModel.Empty;

    /// <summary>
    ///     Gets the <see cref="Ingredients" /> of the <see cref="PizzaModel" />.
    /// </summary>
    public List<IngredientModel> Ingredients { get; } = [];
}