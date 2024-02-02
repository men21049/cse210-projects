using System;

class Program
{
    private static void Main(string[] args)
    {
        string _book;
        int _chapter;
        int _verse;
        int _endVerse;
        int idxToHide;

        string _text = LoadFromFile();
        string[] content = _text.Split("|");
        int _pipeCounter = content.Length;


        Reference reference;
        Scripture scripture;

        if (_pipeCounter == 4)
        {
            _book = content[0];
            _chapter = int.Parse(content[1]);
            _verse = int.Parse(content[2]);
            reference = new Reference(_book, _chapter, _verse);
            scripture = new Scripture(reference, content[3]);
        }
        else
        {
            _book = content[0];
            _chapter = int.Parse(content[1]);
            _verse = int.Parse(content[2]);
            _endVerse = int.Parse(content[3]);
            reference = new Reference(_book, _chapter, _verse, _endVerse);
            scripture = new Scripture(reference, content[4]);
        }

        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("Please enter to continue or type 'quit' to finish");
        string _quit = Console.ReadLine();

        if (!string.Equals(_quit, "quit"))
        {
            while (!scripture.IscompletelyHidden())
            {
                idxToHide = GenerateRandomNumber(scripture.NumberWords());
                scripture.HideRandomWords(idxToHide);

                if (scripture.IsWordHidden(idxToHide))
                {
                    Console.Clear();
                    Console.WriteLine(scripture.GetDisplayText());
                }
                Console.WriteLine("Please enter to continue or type 'quit' to finish");
                _quit = Console.ReadLine();
                if (string.Equals(_quit, "quit"))
                {
                    break;
                }
                Console.Clear();

            }
            Environment.Exit(0);
        }
        Environment.Exit(0);

    }
    public static string LoadFromFile()
    {
        string[] lines = System.IO.File.ReadAllLines("Scriptures.txt");

        Random _rnd = new Random();
        return lines[_rnd.Next(0, lines.Length)];
    }

    public static int GenerateRandomNumber(int seed)
    {
        Random _rnd = new Random();
        int _randomNumber = _rnd.Next(0, seed);
        return _randomNumber;
    }

}