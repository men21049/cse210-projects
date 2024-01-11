using System;
using System.Net;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string name = PromptUserName();
        int number = SquareNumber(PromptUserNumber());
        DisplayResult(name, number);
    }

    public static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }
    public static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }

    public static int PromptUserNumber()
    {
        Console.WriteLine("Please enter your favorite number:");
        int favNum = int.Parse(Console.ReadLine());
        return favNum;
    }

    public static int SquareNumber(int num)
    {
        return num * num;
    }

    public static void DisplayResult(string name, int num)
    {
        Console.WriteLine($"{name}, the square of your number is {num}");
    }
}