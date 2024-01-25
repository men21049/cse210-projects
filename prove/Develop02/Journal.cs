using System;
using System.IO;

class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (var _entry in _entries)
        {
            _entry.Display();
        }
    }
    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (var _entry in _entries)
            {
                outputFile.WriteLine($"Date: {_entry._date} | - Prompt: {_entry._promptText} | {_entry._entryText}");
            }
        }
    }
    public void LoadFromFile(string filename)
    {
        string[] lines = System.IO.File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            string[] parts = line.Split("|");
            Entry _fetchEntry = new Entry();
            _fetchEntry._date = parts[0];
            _fetchEntry._promptText = parts[1];
            _fetchEntry._entryText = parts[2];
            AddEntry(_fetchEntry);

        }
        DisplayAll();
    }
}