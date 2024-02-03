namespace PizzaManager.Data.Entities;

using System.ComponentModel.DataAnnotations;

/// <summary>
///     Represents a <see cref="Pate" />.
/// </summary>
public sealed class Pate
{
    /// <summary>
    ///     Gets or sets the <see cref="Id" /> of the <see cref="Pate" />.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    ///     Gets or sets the name of the <see cref="Pate" />.
    /// </summary>
    [Required]
    [MaxLength(55)]
    public string Nom { get; set; } = string.Empty;

    /// <summary>
    ///     Gets or sets the number of calories of the <see cref="Pate" />.
    /// </summary>
    public int? NCal { get; set; }
}