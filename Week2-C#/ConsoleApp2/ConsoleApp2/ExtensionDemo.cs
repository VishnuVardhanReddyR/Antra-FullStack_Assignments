namespace ConsoleApp2;

public static class ExtensionDemo
{
    public static int ExtensionMethod(this int a, int b)
    {
        return a + b;
    }
}