using System.Linq.Expressions;
using Koen.DotNet.Snake.Application.Contracts.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Koen.DotNet.Snake.Infrastructure.DataAccess.EF;

public abstract class BaseRepository<TModel>(DbContext dbContext, DbSet<TModel> dbSet)
    : IBaseRepository<TModel>
    where TModel : class
{
    protected DbContext DbContext { get; } = dbContext;
    protected DbSet<TModel> DbSet { get; } = dbSet;

    public async Task<IList<TModel>> GetAll()
    {
        return await DbSet.ToListAsync();
    }

    public async Task<IList<TModel>> Find(Expression<Func<TModel, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await DbSet.Where(predicate).ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<TModel?> Single(Expression<Func<TModel, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await DbSet.SingleOrDefaultAsync(predicate, cancellationToken);
    }

    public virtual async Task<TModel> Create(TModel toCreate, CancellationToken cancellationToken = default)
    {
        await DbSet.AddAsync(toCreate, cancellationToken);
        await DbContext.SaveChangesAsync(cancellationToken);
        return toCreate;
    }

    public async Task<IList<TModel>> Create(IList<TModel> toCreate, CancellationToken cancellationToken = default)
    {
        await DbSet.AddRangeAsync(toCreate, cancellationToken);
        await DbContext.SaveChangesAsync(cancellationToken);
        return toCreate;
    }

    public async Task Update(TModel toUpdate, CancellationToken cancellationToken = default)
    {
        DbSet.Update(toUpdate);
        await DbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task Update(IList<TModel> toUpdate, CancellationToken cancellationToken = default)
    {
        foreach (var entity in toUpdate)
            DbSet.Update(entity);
        await DbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task Delete(TModel toDelete, CancellationToken cancellationToken = default)
    {
        DbSet.Remove(toDelete);
        await DbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task Delete(IList<TModel> toDelete, CancellationToken cancellationToken = default)
    {
        DbSet.RemoveRange(toDelete);
        await DbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAll(CancellationToken cancellationToken = default)
    {
        DbSet.RemoveRange(DbSet);
        await DbContext.SaveChangesAsync(cancellationToken);
    }
}