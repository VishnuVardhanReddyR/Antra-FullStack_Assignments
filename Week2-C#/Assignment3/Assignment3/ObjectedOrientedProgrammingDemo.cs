using System;

// Abstraction
/*
 * Write a program that that demonstrates use of four basic principles of
   object-oriented programming /Abstraction/, /Encapsulation/, /Inheritance/ and
   /Polymorphism/.
 */
abstract class Animal
{
    // Encapsulation
    private string Name { get; set; }

    public Animal(string name)
    {
        Name = name;
    }

    // Abstract method (Abstraction)
    public abstract void Speak();

    public void DisplayInfo()
    {
        Console.WriteLine($"I am a {Name}.");
    }
}

// Inheritance
class Dog : Animal
{
    public Dog(string name) : base(name) {}

    // Polymorphism (Overriding)
    public override void Speak()
    {
        Console.WriteLine("Woof!");
    }
}

// Inheritance
class Cat : Animal
{
    public Cat(string name) : base(name) {}

    // Polymorphism (Overriding)
    public override void Speak()
    {
        Console.WriteLine("Meow!");
    }
}
/*
 * Abstraction: The Animal class provides an abstract definition of an animal. It declares an abstract method Speak which is an abstraction of the action that animals do.
 * Encapsulation: The Name property in the Animal class is private and can only be accessed through the constructor or methods within the class, encapsulating the state of the Animal.
 * Inheritance: The Dog and Cat classes inherit from the Animal class, meaning they use the properties and methods defined in Animal.
 * Polymorphism: The Speak method is overridden in both Dog and Cat classes, providing different implementations of the same method defined in Animal. Also, Animal references can hold objects of Dog or Cat, allowing for polymorphic behavior.
 */
 