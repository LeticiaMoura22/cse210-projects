using System;

// Represents one journal entry: the date, the prompt,
// and the response the person wrote.
public class Entry
{
    private string _date;
    private string _promptText;
    private string _entryText;

    public Entry(string date, string promptText, string entryText)
    {
        _date = date;
        _promptText = promptText;
        _entryText = entryText;
    }

    public string Date
    {
        get { return _date; }
    }

    public string PromptText
    {
        get { return _promptText; }
    }

    public string EntryText
    {
        get { return _entryText; }
    }

    // Prints the entry to the screen.
    public void Display()
    {
        Console.WriteLine("Date: " + _date);
        Console.WriteLine("Prompt: " + _promptText);
        Console.WriteLine("Response: " + _entryText);
        Console.WriteLine("----------------------------------------");
    }

    // Turns the entry into one line of text to save to a file.
    // We use "~|~" as the separator between fields.
    public string ToFileLine()
    {
        return _date + "~|~" + _promptText + "~|~" + _entryText;
    }

    // Rebuilds an Entry from one line read from a file.
    public static Entry FromFileLine(string line)
    {
        string[] parts = line.Split("~|~", StringSplitOptions.None);

        string date = parts[0];
        string prompt = parts[1];
        string text = parts[2];

        return new Entry(date, prompt, text);
    }
}