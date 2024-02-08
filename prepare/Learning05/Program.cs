using System;
using Learning05;

class Program
{
    static void Main(string[] args)
    {
        Square square = new Square("Red", 10);
        Rectangle rectangle = new Rectangle("Blue", 10, 9);
        Circle circle = new Circle("Yellow", 23);
        Console.WriteLine("Square: ");
        Console.WriteLine($"Color is: {square.GetColor()}");
        Console.WriteLine($"Area is:{square.GetArea()}");
        Console.WriteLine("Rectangle: ");
        Console.WriteLine($"Color is: {rectangle.GetColor()}");
        Console.WriteLine($"Area is:{rectangle.GetArea()}");
        Console.WriteLine("Circle: ");
        Console.WriteLine($"Color is: {circle.GetColor()}");
        Console.WriteLine($"Area is:{circle.GetArea()}");

    }
}