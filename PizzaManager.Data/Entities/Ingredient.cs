namespace PizzaManager.Data.Entities;

using System.ComponentModel.DataAnnotations;

/// <summary>
///     Represents an <see cref="Ingredient" />.
/// </summary>
public sealed class Ingredient
{
    /// <summary>
    ///     Gets or sets the <see cref="Id" /> of the <see cref="Ingredient" />.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    ///     Gets or sets the name of the <see cref="Ingredient" />.
    /// </summary>
    [Required]
    [MaxLength(55)]
    public string Nom { get; set; } = string.Empty;

    /// <summary>
    ///     Gets or sets the number of calories of the <see cref="Ingredient" />.
    /// </summary>
    [Range(0, 2000)]
    public double NCal { get; set; }
}