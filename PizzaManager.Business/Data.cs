namespace PizzaManager.Business;

using PizzaManager.Business.Models;

public static class DataDtos
{
    static DataDtos()
    {
        var fine = new PateDto { Id = 1, Nom = "Fine" };
        var epaisse = new PateDto { Id = 2, Nom = "Epaisse" };

        var tomate = new IngredientDto { Id = 1, Nom = "Tomate" };
        var mozzarella = new IngredientDto { Id = 2, Nom = "Mozzarella" };
        var jambon = new IngredientDto { Id = 3, Nom = "Jambon" };
        var champignon = new IngredientDto { Id = 4, Nom = "Champignon" };
        var merguez = new IngredientDto { Id = 5, Nom = "Merguez" };
        var chevre = new IngredientDto { Id = 6, Nom = "Chèvre" };
        var ananas = new IngredientDto { Id = 7, Nom = "Ananas" };
        var bleu = new IngredientDto { Id = 8, Nom = "Bleu" };
        var reblochon = new IngredientDto { Id = 9, Nom = "Reblochon" };
        var artichaut = new IngredientDto { Id = 10, Nom = "Artichaut" };
        var olive = new IngredientDto { Id = 11, Nom = "Olive" };

        Ingredients.Add(tomate);
        Ingredients.Add(mozzarella);
        Ingredients.Add(jambon);
        Ingredients.Add(champignon);
        Ingredients.Add(merguez);
        Ingredients.Add(chevre);
        Ingredients.Add(ananas);
        Ingredients.Add(bleu);
        Ingredients.Add(reblochon);
        Ingredients.Add(artichaut);
        Ingredients.Add(olive);

        var reine = new PizzaDto { Id = 1, Nom = "Reine", Pate = fine };
        reine.Ingredients.Add(tomate);
        reine.Ingredients.Add(mozzarella);
        reine.Ingredients.Add(jambon);
        PizzaDtos.Add(reine);

        var margherita = new PizzaDto { Id = 2, Nom = "Margherita", Pate = fine };
        margherita.Ingredients.Add(tomate);
        margherita.Ingredients.Add(mozzarella);
        PizzaDtos.Add(margherita);

        var capriciosa = new PizzaDto { Id = 3, Nom = "Capriciosa", Pate = fine };
        capriciosa.Ingredients.Add(tomate);
        capriciosa.Ingredients.Add(mozzarella);
        capriciosa.Ingredients.Add(jambon);

        capriciosa.Ingredients.Add(champignon);
        PizzaDtos.Add(capriciosa);

        var peperoni = new PizzaDto { Id = 4, Nom = "Peperoni", Pate = fine };
        peperoni.Ingredients.Add(tomate);
        peperoni.Ingredients.Add(mozzarella);
        peperoni.Ingredients.Add(merguez);
        PizzaDtos.Add(peperoni);

        var chevrou = new PizzaDto { Id = 5, Nom = "Chèvre", Pate = epaisse };
        chevrou.Ingredients.Add(tomate);
        chevrou.Ingredients.Add(mozzarella);
        chevrou.Ingredients.Add(chevre);
        PizzaDtos.Add(chevrou);

        var hawai = new PizzaDto { Id = 6, Nom = "Hawai", Pate = epaisse };
        hawai.Ingredients.Add(tomate);
        hawai.Ingredients.Add(mozzarella);
        hawai.Ingredients.Add(jambon);
        hawai.Ingredients.Add(ananas);
        PizzaDtos.Add(hawai);

        var cannibale = new PizzaDto { Id = 7, Nom = "Cannibale", Pate = epaisse };
        cannibale.Ingredients.Add(tomate);
        cannibale.Ingredients.Add(mozzarella);
        cannibale.Ingredients.Add(jambon);
        cannibale.Ingredients.Add(merguez);
        PizzaDtos.Add(cannibale);

        var quatreFromages = new PizzaDto { Id = 8, Nom = "4 fromages", Pate = epaisse };
        quatreFromages.Ingredients.Add(tomate);

        quatreFromages.Ingredients.Add(mozzarella);
        quatreFromages.Ingredients.Add(chevre);
        quatreFromages.Ingredients.Add(bleu);
        quatreFromages.Ingredients.Add(reblochon);
        PizzaDtos.Add(quatreFromages);

        var végétarienne = new PizzaDto { Id = 9, Nom = "Végétarienne", Pate = epaisse };
        végétarienne.Ingredients.Add(tomate);
        végétarienne.Ingredients.Add(mozzarella);
        végétarienne.Ingredients.Add(champignon);
        végétarienne.Ingredients.Add(artichaut);
        végétarienne.Ingredients.Add(olive);
        PizzaDtos.Add(végétarienne);
    }

    public static List<PateDto> Pates { get; } = [new() { Id = 1, Nom = "Fine" }, new() { Id = 2, Nom = "Epaisse" }];

    public static List<IngredientDto> Ingredients { get; } = [];

    public static List<PizzaDto> PizzaDtos { get; } = [];
}
