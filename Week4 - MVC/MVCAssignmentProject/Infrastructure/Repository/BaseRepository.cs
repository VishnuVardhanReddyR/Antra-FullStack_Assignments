using ApplicationCore.Interfaces.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class BaseRepository<T>: IRepository<T> where T: class
{
    private readonly EMovieDbContext eMovieDbContext;
    
    public BaseRepository(EMovieDbContext eMovieDbContext)
    {
        this.eMovieDbContext = eMovieDbContext;
    }
    
    public int Insert(T entity)
    {
        eMovieDbContext.Set<T>().Add(entity);
        return eMovieDbContext.SaveChanges();
    }

    public int Delete(int id)
    {
        var entity = GetById(id);
        if (entity != null)
        {
            eMovieDbContext.Set<T>().Remove(entity);
            return 1;
        }

        return 0;
    }

    public int Update(T entity)
    {
        eMovieDbContext.Set<T>().Entry(entity).State = EntityState.Modified;
        return eMovieDbContext.SaveChanges();
    }

    public T? GetById(int id)
    {
        return eMovieDbContext.Set<T>().Find(id);
    }

    public IEnumerable<T> GetAll()
    {
        return eMovieDbContext.Set<T>()?.ToList();
    }
}