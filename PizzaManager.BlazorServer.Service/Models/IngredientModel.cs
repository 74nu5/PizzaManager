namespace PizzaManager.BlazorServer.Service.Models;

/// <summary>
///     Represents an ingredient.
/// </summary>
public sealed class IngredientModel
{
    /// <summary>
    ///     Gets the empty <see cref="IngredientModel" /> object.
    /// </summary>
    public static IngredientModel Empty { get; } = new() { Id = -1, Nom = string.Empty, NCal = 0 };

    /// <summary>
    ///     Gets or sets the <see cref="Id" /> of the <see cref="IngredientModel" />.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    ///     Gets or sets the name of the <see cref="IngredientModel" />.
    /// </summary>
    public string Nom { get; set; } = string.Empty;

    /// <summary>
    ///     Gets or sets the number of calories of the <see cref="IngredientModel" />.
    /// </summary>
    public double NCal { get; set; }
}