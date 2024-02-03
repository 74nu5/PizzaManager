namespace PizzaManager.Business.Extensions;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

using PizzaManager.Business.Services;
using PizzaManager.Data.Extensions;

/// <summary>
///     Extension methods for business services.
/// </summary>
public static class BusinessExtensions
{
    /// <summary>
    ///     Adds the business services to the service collection.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="dbBuilder"> The database builder action. This is optional and can be used to configure the database connection. </param>
    public static void AddBusinessServices(this IServiceCollection services, Action<DbContextOptionsBuilder>? dbBuilder)
    {
        services.TryAddTransient<PateService>();
        services.TryAddTransient<IngredientService>();
        services.TryAddTransient<PizzaService>();

        services.AddDataServices(dbBuilder);
    }
}