namespace PizzaManager.Business.Models;

/// <summary>
///     Represents a <see cref="PizzaInput" />.
/// </summary>
public sealed class PizzaInput
{
    /// <summary>
    ///     Gets or sets the <see cref="Id" /> of the <see cref="PizzaInput" />.
    /// </summary>
    public int? Id { get; set; }

    /// <summary>
    ///     Gets or sets the name of the <see cref="PizzaInput" />.
    /// </summary>
    public string Nom { get; set; } = string.Empty;

    /// <summary>
    ///     Gets or sets the <see cref="PateId" /> of the <see cref="PizzaInput" />.
    /// </summary>
    public int PateId { get; set; }

    /// <summary>
    ///     Gets or sets the <see cref="IngredientsIds" /> of the <see cref="PizzaInput" />.
    /// </summary>
    public List<int> IngredientsIds { get; set; } = [];
}