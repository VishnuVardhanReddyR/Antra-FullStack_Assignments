namespace Assignment4;

class Program
{
    static void Main(string[] args)
    {
        MyStack<String> stack = new MyStack<string>();
        stack.Push("first");
        stack.Push("second");
        Console.WriteLine(stack.Count());

        MyList<int> list = new MyList<int>();
        list.Add(5);
        list.Add(3);
    }
}