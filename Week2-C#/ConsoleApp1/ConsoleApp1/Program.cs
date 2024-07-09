namespace ConsoleApp1;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        MyList<String> list = new MyStack<string>();
        list.Add("first element");
        list.Add("Second element");
        list.Add("Third element");
        Console.WriteLine(list.Remove("first element"));
        foreach (var element in list.GetAllItems())
        {
            Console.WriteLine(element);
        }
    }
}