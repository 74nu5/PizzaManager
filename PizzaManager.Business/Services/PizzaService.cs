namespace PizzaManager.Business.Services;

using Microsoft.EntityFrameworkCore;

using PizzaManager.Business.Models;
using PizzaManager.Data;
using PizzaManager.Data.Entities;

/// <summary>
///     Provides a service to manage the pizzas.
/// </summary>
public sealed class PizzaService
{
    private readonly DbSet<Pate> patesSet;

    private readonly SaveChangesAsync saveChangesAsync;

    private readonly DbSet<Ingredient> ingredientsSet;

    private readonly DbSet<Pizza> pizzasSet;

    /// <summary>
    ///     Initializes a new instance of the <see cref="PizzaService" /> class.
    /// </summary>
    /// <param name="managerContext">The manager context.</param>
    public PizzaService(PizzaManagerContext managerContext)
    {
        this.saveChangesAsync = managerContext.SaveChangesAsync;
        this.patesSet = managerContext.Pates;
        this.ingredientsSet = managerContext.Ingredients;
        this.pizzasSet = managerContext.Pizzas;
    }

    private delegate Task SaveChangesAsync(CancellationToken cancellationToken);

    /// <summary>
    ///     Creates the specified pizza.
    /// </summary>
    /// <param name="pizza">The pizza to create.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
    public async Task<(bool Success, string ErrorMessage)> CreateAsync(PizzaInput pizza, CancellationToken cancellationToken)
    {
        if (pizza.IngredientsIds.Count > 5)
            return (false, "Une pizza ne peut pas avoir plus de 5 ingrédients");

        var pizzas = this.GetAll();

        // vérification du nom de la pizza
        if (pizzas.Any(p => p.Nom == pizza.Nom))
            return (false, "Une pizza avec ce nom existe déjà");

        // vérification des ingrédients de la pizza (si la pizza existe déjà)
        if (pizzas.Any(pizzaFromDb => pizzaFromDb.Ingredients.Select(p => p.Id).SequenceEqual(pizza.IngredientsIds)))
            return (false, "Une pizza avec ces ingrédients existe déjà");

        var pate = this.patesSet.FirstOrDefault(p => p.Id == pizza.PateId);
        var ingredients = this.ingredientsSet.Where(i => pizza.IngredientsIds.Contains(i.Id));

        var newPizza = new Pizza { Nom = pizza.Nom };

        if (pate is not null)
            newPizza.Pate = pate;

        newPizza.Ingredients.Clear();
        newPizza.Ingredients.AddRange(ingredients);

        this.pizzasSet.Add(newPizza);
        await this.saveChangesAsync(cancellationToken);
        return (true, string.Empty);
    }

    /// <summary>
    ///     Deletes the specified pizza with identifier.
    /// </summary>
    /// <param name="pizzaId">The pizza identifier.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
    public async Task DeleteAsync(int pizzaId, CancellationToken cancellationToken)
    {
        var pizzaFound = this.pizzasSet.FirstOrDefault(p => p.Id == pizzaId);
        if (pizzaFound is null)
            return;

        this.pizzasSet.Remove(pizzaFound);
        await this.saveChangesAsync(cancellationToken);
    }

    /// <summary>
    ///     Updates the specified pizza with identifier.
    /// </summary>
    /// <param name="id">The identifier of the <see cref="PizzaDto" /> to update.</param>
    /// <param name="pizza">The <see cref="PizzaDto" /> to update.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
    public async Task UpdateAsync(int id, PizzaInput pizza, CancellationToken cancellationToken)
    {
        var found = this.pizzasSet.FirstOrDefault(p => p.Id == id);
        if (found is null)
            return;

        var pate = this.patesSet.FirstOrDefault(p => p.Id == pizza.PateId);
        var ingredients = this.ingredientsSet.Where(i => pizza.IngredientsIds.Contains(i.Id));

        found.Nom = pizza.Nom;
        if (pate is not null)
            found.Pate = pate;

        found.Ingredients.Clear();
        found.Ingredients.AddRange(ingredients);

        await this.saveChangesAsync(cancellationToken);
    }

    /// <summary>
    ///     Gets the specified pizza with identifier.
    /// </summary>
    /// <param name="id">The pizza identifier.</param>
    /// <returns>Returns the <see cref="PizzaDto" /> object.</returns>
    public PizzaDto? Get(int id)
        => PizzaDto.FromEntity(this.pizzasSet.FirstOrDefault(p => p.Id == id));

    /// <summary>
    ///     Gets all the <see cref="PizzaDto" /> objects.
    /// </summary>
    /// <returns>Returns the <see cref="IReadOnlyCollection{T}" /> of <see cref="PizzaDto" /> objects.</returns>
    public IReadOnlyCollection<PizzaDto> GetAll()
        => this.pizzasSet
               .Select(PizzaDto.FromEntity)
               .Where(p => p is not null)
               .ToList()
               .AsReadOnly()!;
}