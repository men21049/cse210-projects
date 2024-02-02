using System;

class Program
{
    static void Main(string[] args)
    {
        MathAssignment mathAssignment = new MathAssignment("Roberto Rodriguez", "Fractions", "7.3", "8-9");
        WritingAssingment writingAssingment = new WritingAssingment("Mary Waters", "European History", "The Causes of World War II");
        Console.WriteLine(mathAssignment.GetSummary());
        Console.WriteLine(mathAssignment.GetHomeWorkList());
        Console.WriteLine(writingAssingment.GetSummary());
        Console.WriteLine(writingAssingment.GetWritingInformation());
    }
}