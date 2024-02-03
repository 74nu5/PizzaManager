namespace PizzaManager.BlazorServer.Service.Extensions;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

using PizzaManager.BlazorServer.Service.Services;

/// <summary>
///     Provides extension methods for the <see cref="IServiceCollection" /> interface.
/// </summary>
public static class FrontServiceExtensions
{
    /// <summary>
    ///     Adds the front services to the specified <see cref="IServiceCollection" />.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection" /> to add the front services to.</param>
    public static void AddFrontServices(this IServiceCollection services)
    {
        services.TryAddTransient<PatesFrontService>();
        services.TryAddTransient<IngredientsFrontService>();
        services.TryAddTransient<PizzasFrontService>();

        services.AddHttpClient();
    }
}