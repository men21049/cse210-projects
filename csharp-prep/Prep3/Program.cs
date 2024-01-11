using System;
using System.Formats.Asn1;

class Program
{
    static void Main(string[] args)
    {
        bool found = true;
        while (found)
        {
            string matching;
            Console.WriteLine("What is the magic number?  18");
            Console.WriteLine("What is your guess?");
            int answer = int.Parse(Console.ReadLine());
            if (answer < 18)
            {
                matching = "Higher";
            }
            else if (answer > 18)
            {
                matching = "Lower";
            }
            else
            {
                matching = "You guessed it!";
                found = false;
            }
            Console.WriteLine($"{matching}");

        }
    }
}
