using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter your grade as a whole number: (i.e. 85) ");
        string gradeInput = Console.ReadLine();
        int percentage = int.Parse(gradeInput);

        string letter = "";
        if (percentage >= 90)
        {
            letter = "A";
        }
        else if (percentage >= 80)
        {
            letter = "B";
        }
        else if (percentage >= 70)
        {
            letter = "C";
        }
        else if (percentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        Console.WriteLine($"Your letter grade is {letter}");

        if (percentage >= 70)
        {
            Console.WriteLine("Congrats! You passed this class!");
        }
        else
        {
            Console.WriteLine("You didn't pass this class. Good luck next time!");
        }
    }
}