using CourseEnroll.Domain.Common;

namespace CourseEnroll.Application.Repositories;

public interface IBaseRepository<T> where T : BaseEntity
{
    public void Create(T entity);
    public void Update(T entity);
    public void Delete(T entity);
    public Task<T?> Get(int id, CancellationToken cancellationToken);
    public Task<T?> GetAsNoTracking(int id, CancellationToken cancellationToken);
    public Task<List<T>> GetAll(CancellationToken cancellationToken);
    public Task<List<T>> GetMultiple(IEnumerable<int> ids, CancellationToken cancellationToken);
}
