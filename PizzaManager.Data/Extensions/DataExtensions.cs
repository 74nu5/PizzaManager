namespace PizzaManager.Data.Extensions;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

/// <summary>
///     Extension methods for data services.
/// </summary>
public static class DataExtensions
{
    /// <summary>
    ///     Adds the data services to the service collection.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="dbBuilder">
    ///     The database builder action. This is optional and can be used to configure the database connection.
    /// </param>
    public static void AddDataServices(this IServiceCollection services, Action<DbContextOptionsBuilder>? dbBuilder)
    {
        services.AddDbContext<PizzaManagerContext>(dbBuilder);
        services.AddHostedService<DataInitialization>();
    }
}