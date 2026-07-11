using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter your first name: ");
        string name = Console.ReadLine();

        Console.WriteLine("Enter your last name: ");
        string last_name = Console.ReadLine();

        Console.WriteLine($"Your name is {last_name}, {name} {last_name} ");
    }
}