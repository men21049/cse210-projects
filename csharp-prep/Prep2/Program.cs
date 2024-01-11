using System;

class Program
{
    static void Main(string[] args)
    {
        string letter = "-";
        string sign = "-";
        Console.WriteLine("What is your grade? ");
        float grade = Convert.ToSingle(Console.ReadLine());
        float module = grade % 10;

        if (module >= 7)
        {
            sign = "+";
        }

        if (grade >= 97)
        {
            letter = "A";
        }
        else if (grade >= 90 && grade < 97)
        {
            letter = "A" + sign;
        }
        else if (grade >= 80 && grade < 90)
        {
            letter = "B" + sign;
        }
        else if (grade >= 70 && grade < 80)
        {
            letter = "C" + sign;
        }
        else if (grade >= 60 && grade < 70)
        {
            letter = "D" + sign;
        }
        else
        {
            letter = "F";
        }
        Console.WriteLine($"{letter}");
    }
}