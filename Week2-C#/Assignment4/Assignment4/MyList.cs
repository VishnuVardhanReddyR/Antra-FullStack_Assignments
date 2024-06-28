namespace Assignment4;

/*
 * Create a Generic List data structure MyList<T> that can store any data type.
   Implement the following methods.
   1. void Add (T element)
   2. T Remove (int index)
   3. bool Contains (T element)
   4. void Clear ()
   5. void InsertAt (T element, int index)
   6. void DeleteAt (int index)
   7. T Find (int index)
 */
public class MyList<T>
{
    private List<T> list = new List<T>();

    // Adds an element to the end of the List
    public void Add(T element)
    {
        list.Add(element);
    }

    // Removes the element at the specified index and returns it
    public T Remove(int index)
    {
        if (index < 0 || index >= list.Count)
        {
            throw new ArgumentOutOfRangeException("Index is out of range.");
        }

        T item = list[index];
        list.RemoveAt(index);
        return item;
    }

    // Checks if the List contains a specific element
    public bool Contains(T element)
    {
        return list.Contains(element);
    }

    // Clears all the elements from the List
    public void Clear()
    {
        list.Clear();
    }

    // Inserts an element at the specified index
    public void InsertAt(T element, int index)
    {
        if (index < 0 || index > list.Count)
        {
            throw new ArgumentOutOfRangeException("Index is out of range.");
        }

        list.Insert(index, element);
    }

    // Deletes the element at the specified index
    public void DeleteAt(int index)
    {
        if (index < 0 || index >= list.Count)
        {
            throw new ArgumentOutOfRangeException("Index is out of range.");
        }

        list.RemoveAt(index);
    }

    // Finds and returns the element at the specified index
    public T Find(int index)
    {
        if (index < 0 || index >= list.Count)
        {
            throw new ArgumentOutOfRangeException("Index is out of range.");
        }

        return list[index];
    }
}
