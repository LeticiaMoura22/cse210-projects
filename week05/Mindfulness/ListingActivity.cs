using System;
using System.Collections.Generic;

/// <summary>
/// Gives the user a prompt and has them list as many related items as
/// they can before the duration runs out, then reports how many items
/// they listed.
/// </summary>
public class ListingActivity : Activity
{
    private int _count;

    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt happiest this month?",
        "Who are some of your personal heroes?"
    };

    // Tracks which prompts have already been shown this session so we
    // don't repeat one until all of them have been used at least once.
    private List<string> _usedPrompts = new List<string>();

    public ListingActivity()
        : base(
            "Listing",
            "This activity will help you reflect on the good things in your life by having you list " +
            "as many things as you can in a certain area.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        string prompt = GetRandomPrompt();
        Console.WriteLine(prompt);
        Console.Write("You will begin in: ");
        ShowCountDown(5);
        Console.WriteLine();
        Console.WriteLine();

        List<string> items = GetListFromUser();
        _count = items.Count;

        Console.WriteLine();
        Console.WriteLine($"You listed {_count} items!");

        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        return GetRandomItemNoRepeat(_prompts, _usedPrompts);
    }

    private List<string> GetListFromUser()
    {
        List<string> items = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(Duration);

        while (DateTime.Now < endTime)
        {
            string item = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(item))
            {
                items.Add(item.Trim());
            }
        }

        return items;
    }
}
