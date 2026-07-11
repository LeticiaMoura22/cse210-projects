using System;
using System.Collections.Generic;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbersList = new List<int>();

   
        Console.WriteLine(" Enter a list of numbers, type 0 when finished: ");


        while (true)
        {
            Console.WriteLine("Enter number:");
            int number= int.Parse(Console.ReadLine());

            if (number== 0)
            {
                break;
            }

            numbersList.Add(number);

        }

        int sum =0;
        int largest = numbersList[0];

        for (int i = 0; i < numbersList.Count; i++)
        {
            sum = sum + numbersList[i];
            if (numbersList[i] > largest)
            {
                largest = numbersList[i];
            }

            
        }
        
        double average = (double)sum / numbersList.Count;
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largest}");
 
    }
}