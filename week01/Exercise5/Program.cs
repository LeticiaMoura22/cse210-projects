using System;

class Program
{
           /*
            DisplayWelcome - Displays the message, "Welcome to the Program!"
            PromptUserName - Asks for and returns the user's name (as a string)
            PromptUserNumber - Asks for and returns the user's favorite number (as an integer)
            SquareNumber - Accepts an integer as a parameter and returns that number squared (as an integer)
            DisplayResult - Accepts the user's name and the squared number and displays them.        
        */

        void DisplayWelcome ()
        {
            Console.WriteLine("Welcome to the Program!");
        }
        
        
        int PromptUserNumber()
        {
            Console.WriteLine("What's your favorite number?");
            return int.Parse(Console.ReadLine());
        }

        string PromptUserName()
        {
            Console.WriteLine("What's your name?");
            return Console.ReadLine();
        }

        int SquareNumber (int number)
        {
            return number * number;
        }

        void DisplayResult (int number, string name)
        {
            Console.WriteLine($"{name},the square of your number is {number}!");
        }

    static void Main(string[] args)
    {
        Program program = new Program();
        program.DisplayWelcome();
        string name = program.PromptUserName();
        int number = program.PromptUserNumber();
        int squaredNumber = program.SquareNumber(number);
        program.DisplayResult(squaredNumber, name);
 
    }
}