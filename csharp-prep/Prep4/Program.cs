using System;
using System.Collections.Generic;
using System.Formats.Asn1;

class Program
{
    static void Main(string[] args)
    {
        int answer = 1;
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        while (answer != 0)
        {
            Console.WriteLine("Enter number:");
            answer = int.Parse(Console.ReadLine());
            numbers.Add(answer);
        }
        int sum = numbers.Sum();
        double average = numbers.Average();
        int max = numbers.Max();
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");
    }
}
