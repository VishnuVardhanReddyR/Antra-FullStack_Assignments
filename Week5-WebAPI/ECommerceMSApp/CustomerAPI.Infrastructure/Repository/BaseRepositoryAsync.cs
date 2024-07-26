using CustomerAPI.ApplicationCore.Contracts.Respository;
using CustomerAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CustomerAPI.Infrastructure.Repository;

public class BaseRepositoryAsync<T>: IRepositoryAsync<T> where T:class
{
    private readonly CustomerDbContext _dbContext;

    public BaseRepositoryAsync(CustomerDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<int> InsertAsync(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        return await _dbContext.SaveChangesAsync();
    }

    public Task<int> UpdateAsync(T entity)
    {
        _dbContext.Set<T>().Entry(entity).State = EntityState.Modified;
        return _dbContext.SaveChangesAsync();
    }

    public async Task<int> DeleteAsync(int id)
    {
        var result = await GetByIdAsync(id);
        if (result != null)
        {
            _dbContext.Set<T>().Remove(result);
            return await _dbContext.SaveChangesAsync();
        }
        return 0;
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }
}