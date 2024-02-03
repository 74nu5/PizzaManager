namespace PizzaManager.Business.Models;

using PizzaManager.Data.Entities;

/// <summary>
///     Class which represents a pizza.
/// </summary>
public sealed class PizzaDto
{
    /// <summary>
    ///     Gets the empty <see cref="PizzaDto" /> object.
    /// </summary>
    public static PizzaDto Empty { get; } = new() { Id = -1, Nom = string.Empty, Pate = PateDto.Empty };

    /// <summary>
    ///     Gets or sets the <see cref="Id" /> of the <see cref="Pizza" />.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    ///     Gets or sets the name of the <see cref="Pizza" />.
    /// </summary>
    public string Nom { get; set; } = string.Empty;

    /// <summary>
    ///     Gets or sets the <see cref="Pate" /> of the <see cref="Pizza" />.
    /// </summary>
    public PateDto? Pate { get; set; } = PateDto.Empty;

    /// <summary>
    ///     Gets the <see cref="Ingredients" /> of the <see cref="Pizza" />.
    /// </summary>
    public List<IngredientDto> Ingredients { get; private set; } = [];

    /// <summary>
    ///     Convert a <see cref="Pizza" /> to a <see cref="PizzaDto" />.
    /// </summary>
    /// <param name="pizza">The <see cref="Pizza" /> to convert.</param>
    /// <returns>Returns the converted <see cref="PizzaDto" /> object.</returns>
    public static PizzaDto? FromEntity(Pizza? pizza)
        => pizza is null
                   ? null
                   : new()
                   {
                       Id = pizza.Id,
                       Nom = pizza.Nom,
                       Pate = PateDto.FromEntity(pizza.Pate),
                       Ingredients = IngredientDto.FromEntities(pizza.Ingredients).ToList(),
                   };

    /// <summary>
    ///     Convert a list of <see cref="Pizza" /> to a list of <see cref="PizzaDto" />.
    /// </summary>
    /// <param name="pizzas">The <see cref="Pizza" /> to convert.</param>
    /// <returns>Returns the converted <see cref="PizzaDto" /> list.</returns>
    public static IEnumerable<PizzaDto> FromEntities(IEnumerable<Pizza> pizzas)
        => pizzas.Select(FromEntity).Where(p => p is not null)!;

    /// <summary>
    ///     Convert a <see cref="PizzaDto" /> to a <see cref="Pizza" />.
    /// </summary>
    /// <param name="pizzaDto">The <see cref="PizzaDto" /> to convert.</param>
    /// <returns>Returns the converted <see cref="Pizza" /> object.</returns>
    public static Pizza? ToEntity(PizzaDto? pizzaDto)
        => pizzaDto is null
                   ? null
                   : new()
                   {
                       Id = pizzaDto.Id,
                       Nom = pizzaDto.Nom,
                       Pate = PateDto.ToEntity(pizzaDto.Pate),
                       Ingredients = IngredientDto.ToEntities(pizzaDto.Ingredients).ToList(),
                   };

    /// <summary>
    ///     Convert a list of <see cref="PizzaDto" /> to a list of <see cref="Pizza" />.
    /// </summary>
    /// <param name="pizzaDtos">The <see cref="PizzaDto" /> to convert.</param>
    /// <returns>Returns the converted <see cref="Pizza" /> list.</returns>
    public static IEnumerable<Pizza> ToEntities(IEnumerable<PizzaDto> pizzaDtos)
        => pizzaDtos.Select(ToEntity).Where(p => p is not null)!;
}