namespace PizzaManager.Data;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using PizzaManager.Data.Entities;

/// <summary>
///    The data initialization service.
/// </summary>
internal sealed class DataInitialization : IHostedService
{
    private readonly IServiceProvider provider;

    /// <summary>
    /// Initializes a new instance of the <see cref="DataInitialization"/> class.
    /// </summary>
    /// <param name="provider">The service provider.</param>
    public DataInitialization(IServiceProvider provider)
        => this.provider = provider;

    /// <inheritdoc />
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var scope = this.provider.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<PizzaManagerContext>();

        if (!await context.Database.EnsureCreatedAsync(cancellationToken))
            return;

        var pizzas = context.Pizzas;
        var pates = context.Pates;
        var ingredients = context.Ingredients;

        var fine = new Pate { Id = 1, Nom = "Fine" };
        var epaisse = new Pate { Id = 2, Nom = "Epaisse" };

        pates.Add(fine);
        pates.Add(epaisse);

        var tomate = new Ingredient { Id = 1, Nom = "Tomate" };
        var mozzarella = new Ingredient { Id = 2, Nom = "Mozzarella" };
        var jambon = new Ingredient { Id = 3, Nom = "Jambon" };
        var champignon = new Ingredient { Id = 4, Nom = "Champignon" };
        var merguez = new Ingredient { Id = 5, Nom = "Merguez" };
        var chevre = new Ingredient { Id = 6, Nom = "Chèvre" };
        var ananas = new Ingredient { Id = 7, Nom = "Ananas" };
        var bleu = new Ingredient { Id = 8, Nom = "Bleu" };
        var reblochon = new Ingredient { Id = 9, Nom = "Reblochon" };
        var artichaut = new Ingredient { Id = 10, Nom = "Artichaut" };
        var olive = new Ingredient { Id = 11, Nom = "Olive" };

        ingredients.Add(tomate);
        ingredients.Add(mozzarella);
        ingredients.Add(jambon);
        ingredients.Add(champignon);
        ingredients.Add(merguez);
        ingredients.Add(chevre);
        ingredients.Add(ananas);
        ingredients.Add(bleu);
        ingredients.Add(reblochon);
        ingredients.Add(artichaut);
        ingredients.Add(olive);

        var reine = new Pizza { Id = 1, Nom = "Reine", Pate = fine };
        reine.Ingredients.Add(tomate);
        reine.Ingredients.Add(mozzarella);
        reine.Ingredients.Add(jambon);
        pizzas.Add(reine);

        var margherita = new Pizza { Id = 2, Nom = "Margherita", Pate = fine };
        margherita.Ingredients.Add(tomate);
        margherita.Ingredients.Add(mozzarella);
        pizzas.Add(margherita);

        var capriciosa = new Pizza { Id = 3, Nom = "Capriciosa", Pate = fine };
        capriciosa.Ingredients.Add(tomate);
        capriciosa.Ingredients.Add(mozzarella);
        capriciosa.Ingredients.Add(jambon);

        capriciosa.Ingredients.Add(champignon);
        pizzas.Add(capriciosa);

        var peperoni = new Pizza { Id = 4, Nom = "Peperoni", Pate = fine };
        peperoni.Ingredients.Add(tomate);
        peperoni.Ingredients.Add(mozzarella);
        peperoni.Ingredients.Add(merguez);
        pizzas.Add(peperoni);

        var chevrou = new Pizza { Id = 5, Nom = "Chèvre", Pate = epaisse };
        chevrou.Ingredients.Add(tomate);
        chevrou.Ingredients.Add(mozzarella);
        chevrou.Ingredients.Add(chevre);
        pizzas.Add(chevrou);

        var hawai = new Pizza { Id = 6, Nom = "Hawai", Pate = epaisse };
        hawai.Ingredients.Add(tomate);
        hawai.Ingredients.Add(mozzarella);
        hawai.Ingredients.Add(jambon);
        hawai.Ingredients.Add(ananas);
        pizzas.Add(hawai);

        var cannibale = new Pizza { Id = 7, Nom = "Cannibale", Pate = epaisse };
        cannibale.Ingredients.Add(tomate);
        cannibale.Ingredients.Add(mozzarella);
        cannibale.Ingredients.Add(jambon);
        cannibale.Ingredients.Add(merguez);
        pizzas.Add(cannibale);

        var quatreFromages = new Pizza { Id = 8, Nom = "4 fromages", Pate = epaisse };
        quatreFromages.Ingredients.Add(tomate);

        quatreFromages.Ingredients.Add(mozzarella);
        quatreFromages.Ingredients.Add(chevre);
        quatreFromages.Ingredients.Add(bleu);
        quatreFromages.Ingredients.Add(reblochon);
        pizzas.Add(quatreFromages);

        var végétarienne = new Pizza { Id = 9, Nom = "Végétarienne", Pate = epaisse };
        végétarienne.Ingredients.Add(tomate);
        végétarienne.Ingredients.Add(mozzarella);
        végétarienne.Ingredients.Add(champignon);
        végétarienne.Ingredients.Add(artichaut);
        végétarienne.Ingredients.Add(olive);
        pizzas.Add(végétarienne);

        await context.SaveChangesAsync(cancellationToken);
    }

    /// <inheritdoc />
    public Task StopAsync(CancellationToken cancellationToken)
        => Task.CompletedTask;
}