using System;

class Program
{
    private static void Main(string[] args)
    {
        string _book;
        int _chapter;
        int _verse;
        int _endVerse;

        string _text = LoadFromFile();
        string[] content = _text.Split("|");
        int _commasCounter = content.Length;

        if (_commasCounter == 4)
        {
            _book = content[0];
            _chapter = int.Parse(content[1]);
            _verse = int.Parse(content[2]);
            Reference reference = new Reference(_book, _chapter, _verse);
            Scripture scripture = new Scripture(reference, content[3]);
            /*scripture.SetText(content[3]);*/
            Console.WriteLine(scripture.GetDisplayText());
        }
        else
        {
            _book = content[0];
            _chapter = int.Parse(content[1]);
            _verse = int.Parse(content[2]);
            _endVerse = int.Parse(content[3]);
            Reference reference = new Reference(_book, _chapter, _verse, _endVerse);
            Scripture scripture = new Scripture(reference, content[4]);
            /*scripture.SetText(content[4]);*/
            Console.WriteLine(scripture.GetDisplayText());
        }


    }

    public static string LoadFromFile()
    {
        string[] lines = System.IO.File.ReadAllLines("Scriptures.txt");

        Random _rnd = new Random();
        return lines[_rnd.Next(0, lines.Length)];
    }

    public static int CommasCounter(string line)
    {
        return line.Split(",").Length - 1;
    }
}