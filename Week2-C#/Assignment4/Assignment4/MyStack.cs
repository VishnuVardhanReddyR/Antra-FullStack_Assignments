namespace Assignment4;

public class MyStack<T>
{
    private List<T> stack = new List<T>();

    // Returns the number of elements contained in the Stack
    public int Count()
    {
        return stack.Count();
    }

    // Removes and returns the object at the top of the Stack
    public T Pop()
    {
        if (stack.Count == 0)
        {
            throw new InvalidOperationException("Cannot pop from an empty stack.");
        }

        T item = stack[stack.Count - 1];
        stack.RemoveAt(stack.Count - 1);
        return item;
    }

    // Inserts an object at the top of the Stack
    public void Push(T item)
    {
        stack.Add(item);
    }
}
