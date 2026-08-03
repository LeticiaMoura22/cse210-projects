using System;
using System.Collections.Generic;
using System.IO;

// Owns the overall list of goals and the user's score. Drives the
// menu loop and coordinates creating, recording, listing, saving,
// and loading goals. Never needs to know which concrete Goal type
// it is working with -- it only calls the abstract Goal methods,
// which is polymorphism in action.
public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine();
            DisplayPlayerInfo();
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    running = false;
                    Console.WriteLine("Keep working on your Eternal Quest. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    // CREATIVE ADDITION: a lightweight leveling system built on top
    // of the raw score, so progress feels like a game.
    public void DisplayPlayerInfo()
    {
        int level = (_score / 1000) + 1;
        Console.WriteLine($"You have {_score} points.");
        Console.WriteLine($"Level {level} Eternal Quester{GetLevelTitle(level)}");
    }

    private string GetLevelTitle(int level)
    {
        if (level >= 20)
        {
            return " -- Celestial Champion";
        }
        if (level >= 10)
        {
            return " -- Terrestrial Trailblazer";
        }
        if (level >= 5)
        {
            return " -- Faithful Disciple";
        }
        return " -- Humble Beginner";
    }

    public void ListGoalNames()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].ShortName}");
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("The goals are:");

        if (_goals.Count == 0)
        {
            Console.WriteLine("  (no goals yet -- create one from the menu!)");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal (one-time)");
        Console.WriteLine("  2. Eternal Goal (repeats forever)");
        Console.WriteLine("  3. Checklist Goal (repeats a set number of times, with a bonus)");
        Console.WriteLine("  4. Progress Goal (build toward one big goal, e.g. miles run)");
        Console.WriteLine("  5. Negative Goal (a habit to avoid -- costs points)");
        Console.Write("Which type of goal would you like to create? ");
        string type = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = ReadInt();

        switch (type)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                Console.WriteLine("Simple goal created!");
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                Console.WriteLine("Eternal goal created!");
                break;
            case "3":
                Console.Write("How many times does this goal need to be accomplished for completion? ");
                int target = ReadInt();
                Console.Write("What is the bonus for completing this goal? ");
                int bonus = ReadInt();
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                Console.WriteLine("Checklist goal created!");
                break;
            case "4":
                Console.Write("What is the target amount to reach (e.g. 26 for a marathon)? ");
                int targetProgress = ReadInt();
                Console.Write("What unit are you tracking (e.g. miles, pages, chapters)? ");
                string unit = Console.ReadLine();
                _goals.Add(new ProgressGoal(name, description, points, targetProgress, unit));
                Console.WriteLine("Progress goal created!");
                break;
            case "5":
                _goals.Add(new NegativeGoal(name, description, points));
                Console.WriteLine("Negative goal created -- good luck breaking that habit!");
                break;
            default:
                Console.WriteLine("Invalid goal type. No goal created.");
                break;
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You don't have any goals yet. Create one first!");
            return;
        }

        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");
        string input = Console.ReadLine();

        int index;
        if (int.TryParse(input, out index) && index >= 1 && index <= _goals.Count)
        {
            Goal goal = _goals[index - 1];
            int pointsEarned = goal.RecordEvent();
            _score += pointsEarned;

            if (pointsEarned > 0)
            {
                Console.WriteLine($"Congratulations! You earned {pointsEarned} points!");
            }
            else if (pointsEarned < 0)
            {
                Console.WriteLine($"Oh no, you lost {-pointsEarned} points. Keep trying to break the habit!");
            }
            else
            {
                Console.WriteLine("That goal is already complete -- nothing more to earn there.");
            }

            if (goal.IsComplete() && pointsEarned != 0)
            {
                Console.WriteLine($"*** Goal '{goal.ShortName}' is now complete! Well done! ***");
            }
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for saving your goals? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Your goals have been saved.");
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for loading your goals? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("That file does not exist.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);

        if (lines.Length == 0)
        {
            Console.WriteLine("That file is empty.");
            return;
        }

        _goals.Clear();
        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            if (string.IsNullOrWhiteSpace(lines[i]))
            {
                continue;
            }

            string[] parts = lines[i].Split(':', 2);
            string type = parts[0];
            string[] details = parts[1].Split(',');

            switch (type)
            {
                case "SimpleGoal":
                    _goals.Add(new SimpleGoal(
                        details[0], details[1], int.Parse(details[2]), bool.Parse(details[3])));
                    break;
                case "EternalGoal":
                    _goals.Add(new EternalGoal(
                        details[0], details[1], int.Parse(details[2])));
                    break;
                case "ChecklistGoal":
                    _goals.Add(new ChecklistGoal(
                        details[0], details[1], int.Parse(details[2]),
                        int.Parse(details[3]), int.Parse(details[4]), int.Parse(details[5])));
                    break;
                case "ProgressGoal":
                    _goals.Add(new ProgressGoal(
                        details[0], details[1], int.Parse(details[2]),
                        int.Parse(details[3]), details[4], int.Parse(details[5])));
                    break;
                case "NegativeGoal":
                    _goals.Add(new NegativeGoal(
                        details[0], details[1], int.Parse(details[2])));
                    break;
                default:
                    Console.WriteLine($"Skipping unknown goal type on line {i + 1}: {type}");
                    break;
            }
        }

        Console.WriteLine("Your goals have been loaded.");
    }

    private int ReadInt()
    {
        int value;
        while (!int.TryParse(Console.ReadLine(), out value))
        {
            Console.Write("Please enter a valid whole number: ");
        }
        return value;
    }
}
