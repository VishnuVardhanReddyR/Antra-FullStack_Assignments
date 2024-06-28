namespace Assignment3;
using System;

// Define the Color class
public class Color
{
    public int Red { get; private set; }
    public int Green { get; private set; }
    public int Blue { get; private set; }
    public int Alpha { get; private set; }

    // Constructor with alpha value
    public Color(int red, int green, int blue, int alpha)
    {
        Red = red;
        Green = green;
        Blue = blue;
        Alpha = alpha;
    }

    // Constructor without alpha value, defaults to 255 (opaque)
    public Color(int red, int green, int blue) : this(red, green, blue, 255) { }

    // Method to get the grayscale value
    public int GetGrayscaleValue()
    {
        return (Red + Green + Blue) / 3;
    }
}

// Define the Ball class
public class Ball
{
    public int Size { get; private set; }
    public Color Color { get; private set; }
    private int throwCount;

    // Constructor
    public Ball(int size, Color color)
    {
        Size = size;
        Color = color;
        throwCount = 0;
    }

    // Pop method
    public void Pop()
    {
        Size = 0;
    }

    // Throw method
    public void Throw()
    {
        if (Size > 0)
        {
            throwCount++;
        }
    }

    // Method to get the throw count
    public int GetThrowCount()
    {
        return throwCount;
    }
}

