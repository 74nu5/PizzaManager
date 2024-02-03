namespace PizzaManager.Data;

using Microsoft.EntityFrameworkCore;

using PizzaManager.Data.Entities;

/// <summary>
///     The database context for the pizza manager.
/// </summary>
public class PizzaManagerContext : DbContext
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="PizzaManagerContext" /> class.
    /// </summary>
    /// <param name="options">The options for this context.</param>
    public PizzaManagerContext(DbContextOptions options)
            : base(options)
    {
    }

    /// <summary>
    ///     Gets the pizzas.
    /// </summary>
    public DbSet<Pizza> Pizzas => this.Set<Pizza>();

    /// <summary>
    ///     Gets the pates.
    /// </summary>
    public DbSet<Pate> Pates => this.Set<Pate>();

    /// <summary>
    ///     Gets the ingredients.
    /// </summary>
    public DbSet<Ingredient> Ingredients => this.Set<Ingredient>();
}