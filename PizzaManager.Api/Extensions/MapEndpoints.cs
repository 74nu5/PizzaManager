namespace PizzaManager.Api.Extensions;

using Microsoft.AspNetCore.Mvc;

using PizzaManager.Business.Models;
using PizzaManager.Business.Services;

/// <summary>
///     Static class to map the endpoints of the API to the services methods and DTOs to be used.
/// </summary>
public static class MapEndpoints
{
    /// <summary>
    ///     Static extension method to map the pates endpoints to the services methods and DTOs to be used.
    /// </summary>
    /// <param name="app">The <see cref="IEndpointRouteBuilder" /> to map the endpoints.</param>
    public static void MapPatesEndpoints(this IEndpointRouteBuilder app)
    {
        var pateGroup = app.MapGroup("/pates");

        pateGroup.MapGet("/", ([FromServices] PateService pateService) => pateService.GetAll());
        pateGroup.MapGet("/{id:int}", (int id, [FromServices] PateService pateService) => pateService.Get(id));
        pateGroup.MapPost(
            "/",
            async (PateDto pate, [FromServices] PateService pateService, CancellationToken cancellationToken) =>
            {
                await pateService.CreateAsync(pate, cancellationToken);
                return Results.Created($"/pates/{pate.Id}", pate);
            });

        pateGroup.MapPut(
            "/{id:int}",
            async (int id, PateDto pate, [FromServices] PateService pateService, CancellationToken cancellationToken) =>
            {
                await pateService.UpdateAsync(id, pate, cancellationToken);
                return Results.NoContent();
            });

        pateGroup.MapDelete(
            "/{id:int}",
            async (int id, [FromServices] PateService pateService, CancellationToken cancellationToken) =>
            {
                await pateService.DeleteAsync(id, cancellationToken);
                return Results.NoContent();
            });
    }

    /// <summary>
    ///     Static extension method to map the ingredients endpoints to the services methods and DTOs to be used.
    /// </summary>
    /// <param name="app">The <see cref="IEndpointRouteBuilder" /> to map the endpoints.</param>
    public static void MapIngredientsEndpoints(this IEndpointRouteBuilder app)
    {
        var ingredientGroup = app.MapGroup("/ingredients");

        ingredientGroup.MapGet("/", ([FromServices] IngredientService ingredientService) => ingredientService.GetAll());
        ingredientGroup.MapGet("/{id:int}", (int id, [FromServices] IngredientService ingredientService) => ingredientService.Get(id));
        ingredientGroup.MapPost(
            "/",
            async (IngredientDto ingredient, [FromServices] IngredientService ingredientService, CancellationToken cancellationToken) =>
            {
                await ingredientService.CreateAsync(ingredient, cancellationToken);
                return Results.Created($"/ingredients/{ingredient.Id}", ingredient);
            });

        ingredientGroup.MapPut(
            "/{id:int}",
            async (int id, IngredientDto ingredient, [FromServices] IngredientService ingredientService, CancellationToken cancellationToken) =>
            {
                await ingredientService.UpdateAsync(id, ingredient, cancellationToken);
                return Results.NoContent();
            });

        ingredientGroup.MapDelete(
            "/{id:int}",
            async (int id, [FromServices] IngredientService ingredientService, CancellationToken cancellationToken) =>
            {
                await ingredientService.DeleteAsync(id, cancellationToken);
                return Results.NoContent();
            });
    }

    /// <summary>
    ///     Static extension method to map the pizzas endpoints to the services methods and DTOs to be used.
    /// </summary>
    /// <param name="app">The <see cref="IEndpointRouteBuilder" /> to map the endpoints.</param>
    public static void MapPizzasEndpoints(this IEndpointRouteBuilder app)
    {
        var pizzaGroup = app.MapGroup("/pizza");

        pizzaGroup.MapGet("/", ([FromServices] PizzaService pizzaService) => pizzaService.GetAll());
        pizzaGroup.MapGet("/{id:int}", (int id, [FromServices] PizzaService pizzaService) => pizzaService.Get(id));
        pizzaGroup.MapPost(
            "/",
            async (PizzaInput pizza, [FromServices] PizzaService pizzaService, CancellationToken cancellationToken) =>
            {
                var (success, errorMessage) = await pizzaService.CreateAsync(pizza, cancellationToken);
                return (success, errorMessage) switch
                {
                    (true, _) => Results.Created($"/pizza/{pizza.Id}", pizza),
                    (_, _) => Results.BadRequest(errorMessage),
                };
            });

        pizzaGroup.MapPut(
            "/{id:int}",
            async (int id, PizzaInput pizza, [FromServices] PizzaService pizzaService, CancellationToken cancellationToken) =>
            {
                await pizzaService.UpdateAsync(id, pizza, cancellationToken);
                return Results.NoContent();
            });

        pizzaGroup.MapDelete(
            "/{id:int}",
            async (int id, [FromServices] PizzaService pateService, CancellationToken cancellationToken) =>
            {
                await pateService.DeleteAsync(id, cancellationToken);
                return Results.NoContent();
            });
    }
}