namespace PizzaManager.Business.Models;

using PizzaManager.Data.Entities;

/// <summary>
///     Represents an <see cref="Ingredient" />.
/// </summary>
public sealed class IngredientDto
{
    /// <summary>
    ///     Gets the empty <see cref="IngredientDto" /> object.
    /// </summary>
    public static IngredientDto Empty { get; } = new() { Id = -1, Nom = string.Empty, NCal = 0 };

    /// <summary>
    ///     Gets the <see cref="Id" /> of the <see cref="Ingredient" />.
    /// </summary>
    public int Id { get; init; }

    /// <summary>
    ///     Gets or sets the name of the <see cref="Ingredient" />.
    /// </summary>
    public required string Nom { get; set; }

    /// <summary>
    ///     Gets or sets the number of calories of the <see cref="Ingredient" />.
    /// </summary>
    public double NCal { get; set; }

    /// <summary>
    ///     Convert a <see cref="Ingredient" /> to a <see cref="IngredientDto" />.
    /// </summary>
    /// <param name="ingredient">The <see cref="Ingredient" /> to convert.</param>
    /// <returns>Returns the converted <see cref="IngredientDto" /> object.</returns>
    public static IngredientDto? FromEntity(Ingredient? ingredient)
        => ingredient is null ? null : new() { Id = ingredient.Id, Nom = ingredient.Nom, NCal = ingredient.NCal };

    /// <summary>
    ///     Convert a <see cref="Ingredient" /> to a <see cref="IngredientDto" />.
    /// </summary>
    /// <param name="ingredients">The <see cref="Ingredient" /> to convert.</param>
    /// <returns>Returns the converted <see cref="IngredientDto" /> object.</returns>
    public static IEnumerable<IngredientDto> FromEntities(IEnumerable<Ingredient> ingredients)
        => ingredients.Select(FromEntity).Where(p => p is not null)!;

    /// <summary>
    ///     Convert a <see cref="IngredientDto" /> to a <see cref="Ingredient" />.
    /// </summary>
    /// <param name="ingredientDto">The <see cref="IngredientDto" /> to convert.</param>
    /// <returns>Returns the converted <see cref="Ingredient" /> object.</returns>
    public static Ingredient? ToEntity(IngredientDto? ingredientDto)
        => ingredientDto is null ? null : new() { Id = ingredientDto.Id, Nom = ingredientDto.Nom, NCal = ingredientDto.NCal };

    /// <summary>
    ///     Convert a list of <see cref="IngredientDto" /> to a list of <see cref="Ingredient" />.
    /// </summary>
    /// <param name="ingredientsDtos">The <see cref="IngredientDto" /> to convert.</param>
    /// <returns>Returns the converted <see cref="Ingredient" /> list.</returns>
    public static IEnumerable<Ingredient> ToEntities(IEnumerable<IngredientDto> ingredientsDtos)
        => ingredientsDtos.Select(ToEntity).Where(p => p is not null)!;
}