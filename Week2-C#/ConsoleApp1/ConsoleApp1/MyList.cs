namespace ConsoleApp1;

public interface MyList<T>
{
    void Add(T item);
    bool Remove(T item);
    IEnumerable<T> GetAllItems();
}

public class MyStack<T> : MyList<T>
{
    private List<T> Stack = new List<T>();
    public void Add(T item)
    {
           Stack.Add(item);
           Console.WriteLine("Item Added");
    }

    public bool Remove(T item)
    {
        return Stack.Remove(item);
    }

    public IEnumerable<T> GetAllItems()
    {
        return Stack;
    }
}