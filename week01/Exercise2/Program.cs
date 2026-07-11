using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What's your grade percentage?");
        int grade = int.Parse(Console.ReadLine());

        string letterGrade;
        
        if (grade >=90)
        {
            letterGrade= "A";
        }
        else if (grade >=80)
        {
            letterGrade= "B";
        }
        else if (grade >=70)
        {
            letterGrade= "C";
        }
        else if (grade >=60)
        {
            letterGrade= "D";
        }
        else
        {
            letterGrade= "F";
        }

        Console.WriteLine($"Your grade is : {letterGrade} ");

        if (grade >=70)
        {
            Console.WriteLine ("Congrats! You passed the class!");
        }
        else
        {
            Console.WriteLine("Sorry, you did not pass the class. Better luck next time!");
        }



    }
}