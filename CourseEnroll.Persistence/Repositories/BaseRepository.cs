using CourseEnroll.Application.Repositories;
using CourseEnroll.Domain.Common;
using CourseEnroll.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CourseEnroll.Persistence.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    private readonly DataContext _context;

    protected BaseRepository(DataContext context)
    {
        _context = context;
    }
    
    public void Create(T entity)
    {
        _context.Add(entity);
    }

    public void Update(T entity)
    {
        _context.Update(entity);
    }

    public void Delete(T entity)
    {
        _context.Remove(entity);
    }

    public Task<T?> Get(int id, CancellationToken cancellationToken)
    {
        var entity = _context
            .Set<T>()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        entity.Wait(cancellationToken);
        
        foreach (var collectionEntry in _context.Entry(entity.Result).Collections)
        {
            collectionEntry.Load();
        }

        return entity;
    }

    public Task<List<T>> GetMultiple(IEnumerable<int> ids, CancellationToken cancellationToken)
    {
        return _context
            .Set<T>()
            .Where(x => ids.Contains(x.Id))
            .ToListAsync(cancellationToken);
    }

    public Task<List<T>> GetAll(CancellationToken cancellationToken)
    {
        var students = _context
            .Set<T>()
            .ToListAsync(cancellationToken: cancellationToken);

        students.Wait(cancellationToken);
        
        foreach (var student in students.Result)
        {
            foreach (var collectionEntry in _context.Entry(student).Collections)
            {
                collectionEntry.Load();
            }
        }

        return students;
    }
}
