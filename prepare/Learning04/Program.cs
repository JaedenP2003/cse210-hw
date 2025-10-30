using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment a1 = new Assignment("Issac Cottrell", "Subtraction");
        Console.WriteLine(a1.GetSummary());

        MathAssignment a2 = new MathAssignment("Samuel Powell", "Fractions", "8.9", "21-28");
        Console.WriteLine(a2.GetSummary());
        Console.WriteLine(a2.GetHomeworkList());

        WritingAssignment a3 = new WritingAssignment("Liz Platt", "American History", "The Causes of the Revolutionary War");
        Console.WriteLine(a3.GetSummary());
        Console.WriteLine(a3.GetWritingInformation());
    }
}