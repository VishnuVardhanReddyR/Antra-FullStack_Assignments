namespace Assignment4;

public abstract class Entity
{
    public int Id { get; set; }
}

public interface IRepository<T> where T : Entity
{
    void Add(T item);
    void Remove(T item);
}

public class GenericRepository<T> : IRepository<T> where T : Entity
{
    // Assuming _context is your data source/context, like a DbContext in Entity Framework
    private readonly YourDataContext _context;

    public GenericRepository(YourDataContext context)
    {
        _context = context;
    }

    public void Add(T item)
    {
        _context.Set<T>().Add(item);
        _context.SaveChanges();
    }

    public void Remove(T item)
    {
        _context.Set<T>().Remove(item);
        _context.SaveChanges();
    }

    // Other CRUD methods can be implemented here...
}
