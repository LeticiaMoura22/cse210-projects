using System;
using System.Collections.Generic;
using System.IO;

// Holds all the journal entries and knows how to
// display them, save them, and load them from a file.
public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("The journal is empty.");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        List<string> lines = new List<string>();

        foreach (Entry entry in _entries)
        {
            lines.Add(entry.ToFileLine());
        }

        File.WriteAllLines(filename, lines);
        Console.WriteLine("Journal saved to " + filename);
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("That file does not exist.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);

        _entries = new List<Entry>();

        foreach (string line in lines)
        {
            _entries.Add(Entry.FromFileLine(line));
        }

        Console.WriteLine("Journal loaded from " + filename);
    }
}