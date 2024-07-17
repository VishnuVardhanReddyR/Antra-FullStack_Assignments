namespace ApplicationCore.Interfaces.Repositories;

public interface IRepository<T> where T: class
{
    int Insert(T entity);
    int Delete(int id);
    int Update(T entity);
    T? GetById(int id);
    IEnumerable<T> GetAll();
}