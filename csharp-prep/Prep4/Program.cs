using System;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int UserNumber = -1;
        do
        {
            Console.Write("Enter a number (0 to quit): ");
            string UserResponse = Console.ReadLine();
            UserNumber = int.Parse(UserResponse);
            if (UserNumber != 0)
            {
                numbers.Add(UserNumber);
            }
        } while (UserNumber != 0);

        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }
        Console.WriteLine($"The sum of your numbers is {sum}");
        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The average of your numbers is {average}");
        int max = numbers[0];
        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }
        Console.WriteLine($"The max of your numbers is {max}");
    }
}