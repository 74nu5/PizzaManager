namespace PizzaManager.Data.Entities;

using System.ComponentModel.DataAnnotations;

/// <summary>
///     Represents a <see cref="Pizza" />.
/// </summary>
public sealed class Pizza
{
    /// <summary>
    ///     Gets or sets the <see cref="Id" /> of the <see cref="Pizza" />.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    ///     Gets or sets the name of the <see cref="Pizza" />.
    /// </summary>
    [Required]
    [MaxLength(55)]
    public string Nom { get; set; } = string.Empty;

    /// <summary>
    ///     Gets or sets the <see cref="PateId" /> of the <see cref="Pizza" />.
    /// </summary>
    public int PateId { get; set; }

    /// <summary>
    ///     Gets or sets the <see cref="Pate" /> of the <see cref="Pizza" />.
    /// </summary>
    public Pate? Pate { get; set; }

    /// <summary>
    ///     Gets or sets the <see cref="Ingredients" /> of the <see cref="Pizza" />.
    /// </summary>
    [Length(2, 5)]
    public List<Ingredient> Ingredients { get; set; } = [];
}