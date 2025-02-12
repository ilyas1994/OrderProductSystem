using System.Linq.Expressions;
using DataBase;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.BaseEntity;

namespace Repository;

public class Repository<T> : IRepository<T>  where T : BaseEntity
{
    private readonly AppDbContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(AppDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }
    public IQueryable<T1> GetQueryable<T1>() where T1 : BaseEntity
    {
        return _context.Set<T1>().AsQueryable();
    }
   
    public void Add(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }
          _context.Add(entity);
    }
    public async Task<Guid> AddAsync(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }
        var getId = _context.Add(entity);
        await _context.SaveChangesAsync();
        return getId.Entity.Id;
    }

    public void Update(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }
        _context.Update(entity); 
    }
    public async Task UpdateAsync(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }
        _context.Update(entity);
        await _context.SaveChangesAsync();
    }
    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync(); // Commit all changes to the database
    }
}