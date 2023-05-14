using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter password length: ");
        int length = int.Parse(Console.ReadLine());

        bool useUppercase = AskYesNoQuestion("Use uppercase letters?");
        bool useLowercase = AskYesNoQuestion("Use lowercase letters?");
        bool useDigits = AskYesNoQuestion("Use digits?");
        bool useSymbols = AskYesNoQuestion("Use symbols?");

        string password = GeneratePassword(length, useUppercase, useLowercase, useDigits, useSymbols);
        Console.WriteLine($"Generated password: {password}");
    }

    static string GeneratePassword(int length, bool useUppercase, bool useLowercase, bool useDigits, bool useSymbols)
    {
        const string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string lowercase = "abcdefghijklmnopqrstuvwxyz";
        const string digits = "0123456789";
        const string symbols = "!@#$%^&*()_-+=";

        var random = new Random();
        var password = new char[length];
        var charSets = new[] {
            useUppercase ? uppercase : "",
            useLowercase ? lowercase : "",
            useDigits ? digits : "",
            useSymbols ? symbols : ""
        }.Where(s => !string.IsNullOrEmpty(s)).ToArray();

        for (int i = 0; i < length; i++)
        {
            string charSet = charSets[random.Next(charSets.Length)];
            password[i] = charSet[random.Next(charSet.Length)];
        }

        return new string(password.OrderBy(x => random.Next()).ToArray());
    }

    static bool AskYesNoQuestion(string question)
    {
        while (true)
        {
            Console.Write($"{question} (y/n): ");
            string answer = Console.ReadLine().Trim().ToLower();

            if (answer == "y" || answer == "yes")
            {
                return true;
            }
            else if (answer == "n" || answer == "no")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Invalid input. Please answer 'y' or 'n'.");
            }
        }
    }
}

