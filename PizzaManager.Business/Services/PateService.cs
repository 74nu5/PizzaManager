namespace PizzaManager.Business.Services;

using Microsoft.EntityFrameworkCore;

using PizzaManager.Business.Models;
using PizzaManager.Data;
using PizzaManager.Data.Entities;

/// <summary>
///     Class which manages the <see cref="PateDto" /> objects.
/// </summary>
public sealed class PateService
{
    private readonly SaveChangesAsync saveChangesAsync;

    private readonly DbSet<Pate> patesSet;

    /// <summary>
    ///     Initializes a new instance of the <see cref="PateService" /> class.
    /// </summary>
    /// <param name="managerContext">The manager context.</param>
    public PateService(PizzaManagerContext managerContext)
    {
        this.saveChangesAsync = managerContext.SaveChangesAsync;
        this.patesSet = managerContext.Pates;
    }

    private delegate Task SaveChangesAsync(CancellationToken cancellationToken);

    /// <summary>
    ///     Creates the specified pate.
    /// </summary>
    /// <param name="pate">The pate.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
    public async Task CreateAsync(PateDto pate, CancellationToken cancellationToken)
    {
        var entity = PateDto.ToEntity(pate);
        if (entity is not null)
            this.patesSet.Add(entity);

        await this.saveChangesAsync(cancellationToken);
    }

    /// <summary>
    ///     Deletes the specified pate identifier.
    /// </summary>
    /// <param name="pateId">The pate identifier.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
    public async Task DeleteAsync(int pateId, CancellationToken cancellationToken)
    {
        var entity = this.patesSet.FirstOrDefault(p => p.Id == pateId);
        if (entity is not null)
            _ = this.patesSet.Remove(entity);

        await this.saveChangesAsync(cancellationToken);
    }

    /// <summary>
    ///     Updates the specified identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="pate">The pate.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
    public async Task UpdateAsync(int id, PateDto pate, CancellationToken cancellationToken)
    {
        var found = this.Get(id);
        if (found is not null)
            found.Nom = pate.Nom;

        await this.saveChangesAsync(cancellationToken);
    }

    /// <summary>
    ///     Gets the specified identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>Returns the <see cref="PateDto" /> object.</returns>
    public PateDto? Get(int id)
    {
        var firstOrDefault = this.patesSet.FirstOrDefault(p => p.Id == id);
        return PateDto.FromEntity(firstOrDefault);
    }

    /// <summary>
    ///     Gets all the <see cref="PateDto" /> objects.
    /// </summary>
    /// <returns>Returns the <see cref="IReadOnlyCollection{T}" /> of <see cref="PateDto" /> objects.</returns>
    public IReadOnlyCollection<PateDto?> GetAll()
        => this.patesSet
               .Select(PateDto.FromEntity)
               .ToList()
               .AsReadOnly();
}