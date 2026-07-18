using System;
using System.Collections.Generic;
using System.IO;

internal class Program
{
    private const string ScriptureFilePath = "Data/scriptures.txt";
    private const int MinWordsPerRound = 2;
    private const int MaxWordsPerRound = 4;

    private static void Main()
    {
        List<Scripture> library = LoadLibrary();
        Scripture scripture = ChooseRandomScripture(library);

        RunMemorization(scripture);
    }

    private static void RunMemorization(Scripture scripture)
    {
        Random random = new Random();

        while (!scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("Press enter to continue or type 'quit' to exit.");

            string input = Console.ReadLine();

            if (string.Equals(input, "quit", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            int wordsToHide = random.Next(MinWordsPerRound, MaxWordsPerRound + 1);
            scripture.HideRandomWords(wordsToHide);
        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine();
        Console.WriteLine("You have hidden the entire scripture. Great job memorizing it!");
    }

    private static Scripture ChooseRandomScripture(List<Scripture> library)
    {
        Random random = new Random();
        int index = random.Next(library.Count);
        return library[index];
    }


    private static List<Scripture> LoadLibrary()
    {
        List<Scripture> library = new List<Scripture>();

        if (File.Exists(ScriptureFilePath))
        {
            foreach (string line in File.ReadAllLines(ScriptureFilePath))
            {
                Scripture scripture = ParseScriptureLine(line);
                if (scripture != null)
                {
                    library.Add(scripture);
                }
            }
        }

        if (library.Count == 0)
        {
            library.Add(BuildFallbackScripture());
        }

        return library;
    }

    private static Scripture ParseScriptureLine(string line)
    {
        if (string.IsNullOrWhiteSpace(line))
        {
            return null;
        }

        string[] parts = line.Split('|');
        if (parts.Length != 5)
        {
            return null;
        }

        string book = parts[0].Trim();

        if (!int.TryParse(parts[1], out int chapter) ||
            !int.TryParse(parts[2], out int startVerse) ||
            !int.TryParse(parts[3], out int endVerse))
        {
            return null;
        }

        string text = parts[4].Trim();

        Reference reference = startVerse == endVerse
            ? new Reference(book, chapter, startVerse)
            : new Reference(book, chapter, startVerse, endVerse);

        return new Scripture(reference, text);
    }

    private static Scripture BuildFallbackScripture()
    {
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        string text = "Trust in the Lord with all your heart and lean not on your own " +
                       "understanding; in all your ways submit to him, and he will make " +
                       "your paths straight.";
        return new Scripture(reference, text);
    }
}