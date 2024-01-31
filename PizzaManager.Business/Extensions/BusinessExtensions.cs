namespace PizzaManager.Business.Extensions;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

using PizzaManager.Business.Services;

public static class BusinessExtensions
{
    public static void AddBusinessServices(this IServiceCollection services)
    {
        services.TryAddTransient<PateService>();
        services.TryAddTransient<IngredientService>();
        services.TryAddTransient<PizzaService>();
    }
}
