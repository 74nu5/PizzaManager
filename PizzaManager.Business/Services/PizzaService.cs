namespace PizzaManager.Business.Services;

using PizzaManager.Business.Models;

public class PizzaService
{
    public void Create(PizzaInput pizza)
    {
        var pate = Data.Pates.Find(p => p.Id == pizza.PateId);
        var ingredients = Data.Ingredients.FindAll(i => pizza.IngredientsIds.Contains(i.Id));
        
        var newPizza = new Pizza { Nom = pizza.Nom };

        if (pate is not null)
            newPizza.Pate = pate;

        newPizza.Ingredients.Clear();
        newPizza.Ingredients.AddRange(ingredients);

        Data.Pizzas.Add(newPizza);
    }

    public void Delete(int pizzaId)
        => Data.Pizzas.RemoveAll(p => p.Id == pizzaId);

    public void Update(int id, PizzaInput pizza)
    {
        var found = Data.Pizzas.Find(p => p.Id == id);
        if (found is null)
            return;

        var pate = Data.Pates.Find(p => p.Id == pizza.PateId);
        var ingredients = Data.Ingredients.FindAll(i => pizza.IngredientsIds.Contains(i.Id));


        found.Nom = pizza.Nom;
        if (pate is not null)
            found.Pate = pate;

        found.Ingredients.Clear();
        found.Ingredients.AddRange(ingredients);
    }

    public Pizza? Get(int id)
        => Data.Pizzas.Find(p => p.Id == id);

    public IReadOnlyCollection<Pizza> GetAll()
        => Data.Pizzas.AsReadOnly();
}
