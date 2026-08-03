using System;

/// <summary>
/// Guides the user through slow, paced breathing by alternating
/// "Breathe in..." and "Breathe out..." messages, each followed by a
/// countdown animation, until the requested duration has elapsed.
/// </summary>
public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base(
            "Breathing",
            "This activity will help you relax by walking your through breathing in and out slowly. " +
            "Clear your mind and focus on your breathing.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        DateTime endTime = DateTime.Now.AddSeconds(Duration);
        while (DateTime.Now < endTime)
        {
            Console.Write("Breathe in...");
            ShowCountDown(4);
            Console.Write("\r             \r"); // clear the line

            Console.Write("Breathe out...");
            ShowCountDown(4);
            Console.Write("\r             \r"); // clear the line
        }

        DisplayEndingMessage();
    }
}
