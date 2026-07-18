using System;

// Ideas used to go beyond the basic requirements:
// - The prompt list has 5 different prompts.
// - The menu warns the user when the typed option is invalid instead of crashing.
public class Program
{
    public static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        bool running = true;

        while (running)
        {
            DisplayMenu();
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                WriteNewEntry(journal, promptGenerator);
            }
            else if (choice == "2")
            {
                journal.DisplayAll();
            }
            else if (choice == "3")
            {
                Console.Write("Enter a filename to save to: ");
                string saveFilename = Console.ReadLine();
                journal.SaveToFile(saveFilename);
            }
            else if (choice == "4")
            {
                Console.Write("Enter a filename to load from: ");
                string loadFilename = Console.ReadLine();
                journal.LoadFromFile(loadFilename);
            }
            else if (choice == "5")
            {
                running = false;
                Console.WriteLine("Goodbye!");
            }
            else
            {
                Console.WriteLine("That's not a valid option, please try again.");
            }
        }
    }

    private static void DisplayMenu()
    {
        Console.WriteLine();
        Console.WriteLine("1. Write a new entry");
        Console.WriteLine("2. Display the journal");
        Console.WriteLine("3. Save the journal");
        Console.WriteLine("4. Load the journal");
        Console.WriteLine("5. Quit");
        Console.Write("> ");
    }

    private static void WriteNewEntry(Journal journal, PromptGenerator promptGenerator)
    {
        string prompt = promptGenerator.GetRandomPrompt();
        Console.WriteLine(prompt);
        Console.Write("> ");
        string response = Console.ReadLine();

        string date = DateTime.Now.ToShortDateString();

        Entry newEntry = new Entry(date, prompt, response);
        journal.AddEntry(newEntry);
    }
}