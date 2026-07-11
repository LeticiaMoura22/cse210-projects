using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is the magic number?");
        int guess= int.Parse(Console.ReadLine());

        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 11);

        while (guess != magicNumber)
        {   
            Console.WriteLine("Sorry, that is not the magic number. Please try again.");
            guess= int.Parse(Console.ReadLine());
        }
        
        Console.WriteLine($"Congratulations! You guessed the magic number! It was {magicNumber}.");

    }
}