namespace PizzaManager.Api.Extensions;

using Microsoft.AspNetCore.Mvc;

using PizzaManager.Business.Models;
using PizzaManager.Business.Services;

public static class MapEndpoints
{
    public static void MapPatesEndpoints(this IEndpointRouteBuilder app)
    {
        var pateGroup = app.MapGroup("/pates");

        pateGroup.MapGet("/", ([FromServices] PateService pateService) => pateService.GetAll());
        pateGroup.MapGet("/{id:int}", (int id, [FromServices] PateService pateService) => pateService.Get(id));
        pateGroup.MapPost(
            "/",
            (Pate pate, [FromServices] PateService pateService) =>
            {
                pateService.Create(pate);
                return Results.Created($"/pates/{pate.Id}", pate);
            });

        pateGroup.MapPut(
            "/{id:int}",
            (int id, Pate pate, [FromServices] PateService pateService) =>
            {
                pateService.Update(id, pate);
                return Results.NoContent();
            });

        pateGroup.MapDelete(
            "/{id:int}",
            (int id, [FromServices] PateService pateService) =>
            {
                pateService.Delete(id);
                return Results.NoContent();
            });
    }
    public static void MapIngredientsEndpoints(this IEndpointRouteBuilder app)
    {
        var ingredientGroup = app.MapGroup("/ingredients");

        ingredientGroup.MapGet("/", ([FromServices] IngredientService ingredientService) => ingredientService.GetAll());
        ingredientGroup.MapGet("/{id:int}", (int id, [FromServices] IngredientService ingredientService) => ingredientService.Get(id));
        ingredientGroup.MapPost(
            "/",
            (Ingredient ingredient, [FromServices] IngredientService ingredientService) =>
            {
                ingredientService.Create(ingredient);
                return Results.Created($"/ingredients/{ingredient.Id}", ingredient);
            });

        ingredientGroup.MapPut(
            "/{id:int}",
            (int id, Ingredient ingredient, [FromServices] IngredientService ingredientService) =>
            {
                ingredientService.Update(id, ingredient);
                return Results.NoContent();
            });

        ingredientGroup.MapDelete(
            "/{id:int}",
            (int id, [FromServices] IngredientService ingredientService) =>
            {
                ingredientService.Delete(id);
                return Results.NoContent();
            });
    }

    public static void MapPizzasEndpoints(this IEndpointRouteBuilder app)
    {
        var pizzaGroup = app.MapGroup("/pizza");

        pizzaGroup.MapGet("/", ([FromServices] PizzaService pizzaService) => pizzaService.GetAll());
        pizzaGroup.MapGet("/{id:int}", (int id, [FromServices] PizzaService pizzaService) => pizzaService.Get(id));
        pizzaGroup.MapPost(
            "/",
            (PizzaInput pizza, [FromServices] PizzaService pizzaService) =>
            {
                pizzaService.Create(pizza);
                return Results.Created($"/pizza/{pizza.Id}", pizza);
            });

        pizzaGroup.MapPut(
            "/{id:int}",
            (int id, PizzaInput pizza, [FromServices] PizzaService pizzaService) =>
            {
                pizzaService.Update(id, pizza);
                return Results.NoContent();
            });

        pizzaGroup.MapDelete(
            "/{id:int}",
            (int id, [FromServices] PizzaService pateService) =>
            {
                pateService.Delete(id);
                return Results.NoContent();
            });
    }
}
