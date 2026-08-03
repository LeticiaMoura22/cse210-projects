using System;
using System.Collections.Generic;

/// <summary>
/// Shows the user a random reflection prompt, then walks them through a
/// series of random follow-up questions (each followed by a spinner
/// pause) until the requested duration has elapsed.
/// </summary>
public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    // Tracks used prompts/questions so nothing repeats until the full
    // list has been shown at least once this session.
    private List<string> _usedPrompts = new List<string>();
    private List<string> _usedQuestions = new List<string>();

    public ReflectingActivity()
        : base(
            "Reflecting",
            "This activity will help you reflect on times in your life when you have shown strength and " +
            "resilience. This will help you recognize the power you have and how you can use it in other " +
            "aspects of your life.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();
        DisplayPrompt();
        DisplayQuestions();
        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        return GetRandomItemNoRepeat(_prompts, _usedPrompts);
    }

    private string GetRandomQuestion()
    {
        return GetRandomItemNoRepeat(_questions, _usedQuestions);
    }

    private void DisplayPrompt()
    {
        Console.WriteLine(GetRandomPrompt());
        Console.WriteLine();
    }

    private void DisplayQuestions()
    {
        DateTime endTime = DateTime.Now.AddSeconds(Duration);
        while (DateTime.Now < endTime)
        {
            Console.Write($"> {GetRandomQuestion()} ");
            ShowSpinner(4);
            Console.WriteLine();
        }
    }
}
