using System.Linq.Expressions;
using DataBase;
using Models;
using Models.BaseEntity;

namespace Repository;

public interface IRepository<T>  where T : BaseEntity
{
    public IQueryable<T> GetQueryable<T>() where T : BaseEntity;
    public void Add(T entity);
    public Task<Guid> AddAsync(T entity);

    public void Update(T entity);
    public Task UpdateAsync(T entity);
    public Task SaveChangesAsync();
}