namespace PizzaManager.Business.Services;

using Microsoft.EntityFrameworkCore;

using PizzaManager.Business.Models;
using PizzaManager.Data;
using PizzaManager.Data.Entities;

/// <summary>
///     Class which manages the <see cref="IngredientDto" />.
/// </summary>
public sealed class IngredientService
{
    private readonly SaveChangesAsync saveChangesAsync;

    private readonly DbSet<Ingredient> ingredientsSet;

    /// <summary>
    ///     Initializes a new instance of the <see cref="IngredientService" /> class.
    /// </summary>
    /// <param name="managerContext">The pizza manager context.</param>
    public IngredientService(PizzaManagerContext managerContext)
    {
        this.saveChangesAsync = managerContext.SaveChangesAsync;
        this.ingredientsSet = managerContext.Ingredients;
    }

    private delegate Task SaveChangesAsync(CancellationToken cancellationToken);

    /// <summary>
    ///     Creates the specified ingredient.
    /// </summary>
    /// <param name="ingredient">The ingredient.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
    public async Task CreateAsync(IngredientDto ingredient, CancellationToken cancellationToken)
    {
        var entity = IngredientDto.ToEntity(ingredient);
        if (entity is null)
            return;

        this.ingredientsSet.Add(entity);
        await this.saveChangesAsync(cancellationToken);
    }

    /// <summary>
    ///     Deletes the specified ingredient with identifier.
    /// </summary>
    /// <param name="ingredientId">The ingredient identifier.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
    public async Task DeleteAsync(int ingredientId, CancellationToken cancellationToken)
    {
        var ingredientFound = this.ingredientsSet.FirstOrDefault(i => i.Id == ingredientId);
        if (ingredientFound is null)
            return;

        this.ingredientsSet.Remove(ingredientFound);
        await this.saveChangesAsync(cancellationToken);
    }

    /// <summary>
    ///     Updates the specified ingredient with identifier.
    /// </summary>
    /// <param name="id">The identifier of the <see cref="IngredientDto" /> to update.</param>
    /// <param name="ingredient">The <see cref="IngredientDto" /> to update.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
    public async Task UpdateAsync(int id, IngredientDto ingredient, CancellationToken cancellationToken)
    {
        var ingredientFound = this.ingredientsSet.FirstOrDefault(i => i.Id == id);
        if (ingredientFound is null)
            return;

        ingredientFound.Nom = ingredient.Nom;
        ingredientFound.NCal = ingredient.NCal;
        await this.saveChangesAsync(cancellationToken);
    }

    /// <summary>
    ///     Gets the specified ingredient with identifier.
    /// </summary>
    /// <param name="id">The identifier of the <see cref="IngredientDto" /> to get.</param>
    /// <returns>Returns the <see cref="IngredientDto" /> object.</returns>
    public IngredientDto? Get(int id)
        => IngredientDto.FromEntity(this.ingredientsSet.FirstOrDefault(i => i.Id == id));

    /// <summary>
    ///     Gets all the <see cref="IngredientDto" /> objects.
    /// </summary>
    /// <returns>Returns the <see cref="IngredientDto" /> list.</returns>
    public IReadOnlyCollection<IngredientDto?> GetAll()
        => this.ingredientsSet
               .Select(IngredientDto.FromEntity)
               .ToList()
               .AsReadOnly();
}