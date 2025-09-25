using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);
        int userGuess = -1;
        while (userGuess != magicNumber)
        {
            Console.Write("Guess the magic number: ");
            userGuess = int.Parse(Console.ReadLine());
            if (magicNumber < userGuess)
            {
                Console.WriteLine("Too high!");
            }
            else if (magicNumber > userGuess)
            {
                Console.WriteLine("Too low!");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        }
    }
}