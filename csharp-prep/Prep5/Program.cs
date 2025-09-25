using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string name = PromptUserName();
        int number = PromptUserNumber();
        int squaredNumber = SquaredNumber(number);
        int BirthYear;
        PromptUserBirthYear(out BirthYear);
        DisplayResult(name, squaredNumber, BirthYear);
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to this awesome program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());
        return number;
    }

    static void PromptUserBirthYear(out int BirthYear)
    {
        Console.Write("Please enter your birth year: ");
        BirthYear = int.Parse(Console.ReadLine());
    }

    static int SquaredNumber(int number)
    {
        int squaredNumber = number * number;
        return squaredNumber;
    }

    static void DisplayResult(string name, int squaredNumber, int BirthYear)
    {
        Console.WriteLine($"{name}, the square of your number is {squaredNumber}.");
        Console.WriteLine($"{name}, you will turn {2025 - BirthYear} years old this year.");
    }
}