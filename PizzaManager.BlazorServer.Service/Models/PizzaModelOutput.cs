namespace PizzaManager.BlazorServer.Service.Models;

/// <summary>
///     Represents a pizza to api deserialization.
/// </summary>
public sealed class PizzaModelOutput
{
    /// <summary>
    ///     Gets or sets the empty <see cref="PizzaModelOutput" /> object.
    /// </summary>
    public int? Id { get; set; }

    /// <summary>
    ///     Gets or sets the name of the <see cref="PizzaModelOutput" />.
    /// </summary>
    public string Nom { get; set; } = string.Empty;

    /// <summary>
    ///     Gets or sets the <see cref="PateId" /> of the <see cref="PizzaModelOutput" />.
    /// </summary>
    public int PateId { get; set; }

    /// <summary>
    ///     Gets or sets the <see cref="IngredientsIds" /> of the <see cref="PizzaModelOutput" />.
    /// </summary>
    public int[] IngredientsIds { get; set; } = [];
}