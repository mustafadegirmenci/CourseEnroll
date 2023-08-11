using CourseEnroll.Application.Repositories;
using CourseEnroll.Domain.Common;
using CourseEnroll.Domain.Entities;
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
        entity.DateCreated = DateTime.Now;
        _context.Add(entity);
    }

    public void Update(T entity)
    {
        _context.Update(entity);
        _context.SaveChanges();
    }

    public void Delete(T entity)
    {
        _context.Remove(entity);
        _context.SaveChanges();
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

    public Task<T?> GetAsNoTracking(int id, CancellationToken cancellationToken)
    {
        var entity = _context
            .Set<T>()
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        entity.Wait(cancellationToken);
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
        var entitiesTask = _context
            .Set<T>()
            .ToListAsync(cancellationToken: cancellationToken);

        entitiesTask.Wait(cancellationToken);
        
        foreach (var entity in entitiesTask.Result)
        {
            foreach (var collectionEntry in _context.Entry(entity).Collections)
            {
                collectionEntry.Load();
            }
        }

        return entitiesTask;
    }
}
