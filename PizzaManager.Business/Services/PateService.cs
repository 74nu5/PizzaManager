namespace PizzaManager.Business.Services;

using PizzaManager.Business.Models;

public sealed class PateService
{
    public void Create(Pate pate)
        => Data.Pates.Add(pate);

    public void Delete(int pateId)
        => Data.Pates.RemoveAll(p => p.Id == pateId);

    public void Update(int id, Pate pate)
    {
        var found = Data.Pates.Find(p => p.Id == id);
        if (found is not null)
            found.Nom = pate.Nom;
    }

    public Pate? Get(int id)
        => Data.Pates.Find(p => p.Id == id);

    public IReadOnlyCollection<Pate> GetAll()
        => Data.Pates.AsReadOnly();
}
