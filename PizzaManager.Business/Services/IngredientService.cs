namespace PizzaManager.Business.Services;

using PizzaManager.Business.Models;

public class IngredientService
{
    public void Create(Ingredient ingredient) => Data.Ingredients.Add(ingredient);

    public void Delete(int ingredientId)
        => Data.Ingredients.RemoveAll(i => i.Id == ingredientId);

    public void Update(int id, Ingredient ingredient)
    {
        var found = Data.Ingredients.Find(i => i.Id == id);
        if (found is null)
            return;

        found.Nom = ingredient.Nom;
        found.NCal = ingredient.NCal;
    }

    public Ingredient? Get(int id)
        => Data.Ingredients.Find(i => i.Id == id);

    public IReadOnlyCollection<Ingredient> GetAll()
        => Data.Ingredients.AsReadOnly();
}
