namespace PizzaManager.Business.Models;

using PizzaManager.Data.Entities;

/// <summary>
///     Represents a <see cref="Pate" />.
/// </summary>
public sealed class PateDto
{
    /// <summary>
    ///     Gets the empty <see cref="PateDto" /> object.
    /// </summary>
    public static PateDto Empty { get; } = new() { Id = -1, Nom = string.Empty };

    /// <summary>
    ///     Gets the <see cref="Id" /> of the <see cref="Pate" />.
    /// </summary>
    public int Id { get; init; }

    /// <summary>
    ///     Gets or sets the name of the <see cref="Pate" />.
    /// </summary>
    public required string Nom { get; set; }

    /// <summary>
    ///     Convert a <see cref="Pate" /> to a <see cref="PateDto" />.
    /// </summary>
    /// <param name="pate">The <see cref="Pate" /> to convert.</param>
    /// <returns>Returns the converted <see cref="PateDto" /> object.</returns>
    public static PateDto? FromEntity(Pate? pate)
        => pate is null ? null : new() { Id = pate.Id, Nom = pate.Nom };

    /// <summary>
    ///     Convert a <see cref="Pate" /> to a <see cref="PateDto" />.
    /// </summary>
    /// <param name="pates">The <see cref="Pate" /> to convert.</param>
    /// <returns>Returns the converted <see cref="PateDto" /> object.</returns>
    public static IEnumerable<PateDto> FromEntities(IEnumerable<Pate> pates)
        => pates.Select(FromEntity).Where(p => p is not null)!;

    /// <summary>
    ///     Convert a list of <see cref="PateDto" /> to a list of <see cref="Pate" />.
    /// </summary>
    /// <param name="patesDtos">The <see cref="PateDto" /> to convert.</param>
    /// <returns>Returns the converted <see cref="Pate" /> list.</returns>
    public static IEnumerable<Pate> ToEntities(IEnumerable<PateDto> patesDtos)
        => patesDtos.Select(ToEntity).Where(p => p is not null)!;

    /// <summary>
    ///     Convert a <see cref="PateDto" /> to a <see cref="Pate" />.
    /// </summary>
    /// <param name="pateDto">The <see cref="PateDto" /> to convert.</param>
    /// <returns>Returns the converted <see cref="Pate" /> object.</returns>
    internal static Pate? ToEntity(PateDto? pateDto)
        => pateDto is null ? null : new() { Id = pateDto.Id, Nom = pateDto.Nom };
}