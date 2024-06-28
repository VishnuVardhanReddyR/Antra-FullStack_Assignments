namespace Assignment4;
/*
 * Implement a GenericRepository<T> class that implements IRepository<T> interface
   that will have common /CRUD/ operations so that it can work with any data source
   such as SQL Server, Oracle, In-Memory Data etc. Make sure you have a type constraint
   on T were it should be of reference type and can be of type Entity which has one
   property called Id. IRepository<T> should have following methods
   1. void Add(T item)
   2. void Remove(T item)
   3. Void Save()
   4. IEnumerable<T> GetAll()
   5. T GetById(int id)
 */
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
    private readonly List<T> _items = new List<T>();
    
    public GenericRepository(List<T> list)
    {
        _items = list;
    }

    public void Add(T item)
    {
        // Simulate the auto-increment of the Id property
        item.Id = !_items.Any() ? 1 : _items.Max(i => i.Id) + 1;
        _items.Add(item);
    }

    public void Remove(T item)
    {
        _items.Remove(item);
    }
    public void Save()
    {
        Console.WriteLine("Saved!");
        // Since this is an in-memory implementation, changes are automatically persisted in the list.
    }

    // Example: Find an item by Id
    
    public IEnumerable<T> GetAll()
    {
        return _items;
    }
    public T FindById(int id)
    {
        return _items.FirstOrDefault(i => i.Id == id);
    }
}
