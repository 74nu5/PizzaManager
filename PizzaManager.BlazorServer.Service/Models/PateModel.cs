namespace PizzaManager.BlazorServer.Service.Models;

/// <summary>
///     Represents a pate from api deserialization.
/// </summary>
public sealed class PateModel
{
    /// <summary>
    ///     Gets an empty pate.
    /// </summary>
    public static PateModel Empty { get; } = new() { Id = -1, Nom = string.Empty };

    /// <summary>
    ///     Gets or sets the pate id.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    ///     Gets or sets the pate name.
    /// </summary>
    public string Nom { get; set; } = string.Empty;

    /// <summary>
    ///     Gets or sets the pate price.
    /// </summary>
    public double NCal { get; set; }
}