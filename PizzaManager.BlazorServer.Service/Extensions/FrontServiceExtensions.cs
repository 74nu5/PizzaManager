namespace PizzaManager.BlazorServer.Service.Extensions;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

using PizzaManager.BlazorServer.Service.Pizzas;

public static class FrontServiceExtensions
{
    public static void AddFrontServices(this IServiceCollection services)
    {
        services.TryAddTransient<PatesFrontService>();
        services.TryAddTransient<IngredientsFrontService>();
        services.TryAddTransient<PizzasFrontService>();

        services.AddHttpClient();
    }
}
