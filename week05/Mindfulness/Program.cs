using System;

/*
 * W05 Project: Mindfulness Program
 *
 * How I exceeded the core requirements:
 *
 * 1. No-repeat random prompts/questions - Rather than picking a fully random
 *    prompt/question each time (which could repeat the same one back-to-back
 *    or many times in a row), GetRandomItemNoRepeat() in the base Activity
 *    class tracks which items have already been shown and guarantees every
 *    item is used at least once before any item repeats in a session.
 *
 * 2. Input validation on the duration prompt - GetDurationFromUser() in the
 *    base class re-prompts the user until they enter a valid positive
 *    number of seconds, instead of crashing on bad input.
 *
 * These features are layered on top of the required Activity base class /
 * BreathingActivity / ListingActivity / ReflectingActivity inheritance
 * hierarchy described in the design diagram - no additional classes were
 * introduced beyond the four shown in the diagram.
 */
class Program
{
    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("====================");
            Console.WriteLine("1) Breathing Activity");
            Console.WriteLine("2) Reflecting Activity");
            Console.WriteLine("3) Listing Activity");
            Console.WriteLine("4) Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    {
                        BreathingActivity activity = new BreathingActivity();
                        activity.Run();
                        Pause();
                        break;
                    }
                case "2":
                    {
                        ReflectingActivity activity = new ReflectingActivity();
                        activity.Run();
                        Pause();
                        break;
                    }
                case "3":
                    {
                        ListingActivity activity = new ListingActivity();
                        activity.Run();
                        Pause();
                        break;
                    }
                case "4":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Press Enter to try again.");
                    Console.ReadLine();
                    break;
            }
        }
    }

    private static void Pause()
    {
        Console.WriteLine();
        Console.WriteLine("Press Enter to return to the menu.");
        Console.ReadLine();
    }
}
