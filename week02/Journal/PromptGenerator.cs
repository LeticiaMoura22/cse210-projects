using System;
using System.Collections.Generic;

// Holds the list of prompts and picks one at random.
public class PromptGenerator
{
    private List<string> _prompts = new List<string>
    {
        "Who was the most interesting person you interacted with today?",
        "What was the best part of your day?",
        "What did you learn today that you didn't know before?",
        "What was the strongest emotion you felt today?",
        "If you could redo one thing from today, what would it be?"
    };

    private Random _random = new Random();

    public string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }
}