using System.Linq.Expressions;

namespace Koen.DotNet.Snake.Application.Contracts.DataAccess;

public interface IBaseRepository<TModel> where TModel : class
{
    Task<IList<TModel>> GetAll();
    Task<IList<TModel>> Find(Expression<Func<TModel, bool>> predicate, CancellationToken cancellationToken = default);
    Task<TModel?> Single(Expression<Func<TModel, bool>> predicate, CancellationToken cancellationToken = default);
    
    Task<TModel> Create(TModel toCreate, CancellationToken cancellationToken = default);
    Task<IList<TModel>> Create(IList<TModel> toCreate, CancellationToken cancellationToken = default);

    Task Update(TModel toUpdate, CancellationToken cancellationToken = default);
    Task Update(IList<TModel> toUpdate, CancellationToken cancellationToken = default);

    Task Delete(TModel toDelete, CancellationToken cancellationToken = default);
    Task Delete(IList<TModel> toDelete, CancellationToken cancellationToken = default);
    Task DeleteAll(CancellationToken cancellationToken = default);
}