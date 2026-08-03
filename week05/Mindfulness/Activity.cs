using System;
using System.Collections.Generic;
using System.Threading;

/// <summary>
/// Base class for all mindfulness activities. Contains the shared state
/// (name, description, duration) and the shared behaviors (starting message,
/// ending message, spinner animation, countdown animation) that every
/// activity uses. Derived classes implement their own Run() method that
/// calls back into these shared pieces.
/// </summary>
public abstract class Activity
{
    // Private fields as shown in the UML diagram. Exposed to derived classes
    // through protected properties so subclasses stay encapsulated from the
    // outside world but can still use the shared state.
    private string _name;
    private string _description;
    private int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    protected string Name => _name;
    protected string Description => _description;

    protected int Duration
    {
        get => _duration;
        set => _duration = value;
    }

    /// <summary>
    /// Displays the common starting message shared by every activity:
    /// name, description, prompts for + sets the duration, then pauses
    /// while showing a "get ready" animation.
    /// </summary>
    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} Activity.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();

        _duration = GetDurationFromUser();

        Console.WriteLine();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
        Console.WriteLine();
    }

    /// <summary>
    /// Displays the common ending message shared by every activity:
    /// congratulates the user, pauses, then reports the activity name
    /// and duration before finishing.
    /// </summary>
    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!");
        ShowSpinner(3);
        Console.WriteLine();
        Console.WriteLine($"You have completed the {_name} Activity for {_duration} seconds.");
        ShowSpinner(3);
        Console.WriteLine();
    }

    /// <summary>
    /// Displays a simple spinner animation for the given number of seconds.
    /// </summary>
    public void ShowSpinner(int seconds)
    {
        List<string> frames = new List<string> { "|", "/", "-", "\\" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int i = 0;
        while (DateTime.Now < endTime)
        {
            Console.Write(frames[i % frames.Count]);
            Thread.Sleep(250);
            Console.Write("\b \b");
            i++;
        }
    }

    /// <summary>
    /// Displays a numeric countdown animation, counting down from the
    /// given number of seconds to zero, one second at a time.
    /// </summary>
    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            string text = i.ToString();
            Console.Write(text);
            Thread.Sleep(1000);
            // Erase however many characters we just wrote (handles 2-digit numbers).
            for (int c = 0; c < text.Length; c++)
            {
                Console.Write("\b \b");
            }
        }
    }

    private int GetDurationFromUser()
    {
        int duration;
        while (true)
        {
            Console.Write("How long, in seconds, would you like for your session? ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out duration) && duration > 0)
            {
                return duration;
            }
            Console.WriteLine("Please enter a positive whole number.");
        }
    }

    /// <summary>
    /// Picks a random item from a list, without repeating any item until
    /// every item in the list has been shown at least once this session.
    /// This is one of the "exceed requirements" features of this program
    /// (see the note at the top of Program.cs).
    /// </summary>
    protected string GetRandomItemNoRepeat(List<string> allItems, List<string> usedItems)
    {
        if (usedItems.Count >= allItems.Count)
        {
            usedItems.Clear();
        }

        Random random = new Random();
        string item;
        do
        {
            item = allItems[random.Next(allItems.Count)];
        } while (usedItems.Contains(item));

        usedItems.Add(item);
        return item;
    }
}
