using System;

class Program
{
    static void Main(string[] args)
    {
        string answer = "0";
        PromptGenerator _promptGen = new PromptGenerator();

        Journal journal = new Journal();

        Console.WriteLine("Welcome to the Journal Program");

        while (answer != "5")
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1.- Write");
            Console.WriteLine("2.- Display");
            Console.WriteLine("3.- Load");
            Console.WriteLine("4.- Save");
            Console.WriteLine("5.- Quit");
            Console.WriteLine("What would you like to do?");
            answer = Console.ReadLine();
            if (answer == "1")
            {
                Entry entry = new Entry();
                DateTime theCurrentTime = DateTime.Now;
                entry._promptText = _promptGen.GetRandomPrompt();
                Console.WriteLine(entry._promptText);
                entry._date = theCurrentTime.ToShortDateString();
                Console.Write(">");
                entry._entryText = Console.ReadLine();
                journal.AddEntry(entry);
            }
            else if (answer == "2")
            {
                journal.DisplayAll();
            }
            else if (answer == "3")
            {
                Console.WriteLine("Please enter the filename: ");
                string _filename = Console.ReadLine() + ".txt";
                journal.LoadFromFile(_filename);
            }
            else if (answer == "4")
            {
                Console.WriteLine("Please enter the filename: ");
                string _filename = Console.ReadLine() + ".txt";
                journal.SaveToFile(_filename);
            }
            else
            {
                break;
            }
        }


    }
}