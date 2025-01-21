using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

class Calculator
{

    // file path where the json file will be saved
    static readonly string jsonPath = @"C:\Users\a\source\repos\homework\homework\bin\Debug\section_C_task_1.json";

    // checking if there is json file already
    static void CheckingHistoryExists()
    {
        if (!File.Exists(jsonPath))
        {
            // if there is not, creating an empty file
            File.WriteAllText(jsonPath, JsonConvert.SerializeObject(new List<string>()));
        }
    }
    static void Main(string[] args)
    {
        // starting menu
        Console.WriteLine("Calculator Menu:");
        Console.WriteLine("1. Perform Basic Calculation");
        Console.WriteLine("2. Calculate Square Root");
        Console.WriteLine("3. View History");
        Console.WriteLine("4. Exit");
        Console.Write("Enter your choice: ");

        // checking user input if not valid
        if (int.TryParse(Console.ReadLine(), out int option))
        {
            Console.WriteLine($"You selected option number {option}.");
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }

        switch (option)
        {
            case 1:
                FirstOption();
                break;
            case 2:
                SecondOption();
                break;
            case 3:
                ThirdOption();
                break;
            case 4:
                Console.WriteLine("Exiting the calculator.");
                return;
            default:
                Console.WriteLine("You did not enter valid option. Try again.");
                break;

        }
    }
    static void FirstOption()
    {
        Console.Write("Enter your calculation: ");
        string userInput = Console.ReadLine();

        try
        {
            // splitting user input into 3 tokens
            string[] tokensOfInput = userInput.Split(' ');

            if (tokensOfInput.Length != 3)
            {
                throw new FormatException("You did not enter the valid format.");
            }

            // assigning every token to different variable and creating variable result that will later be updated
            double firstNumber = double.Parse(tokensOfInput[0]);
            string wantedOperation = tokensOfInput[1];
            double secondNumber = double.Parse(tokensOfInput[2]);
            double result = 0;

            // checking users wanted operation and updating history
            switch (wantedOperation)
            {
                case "+":
                    result = firstNumber + secondNumber;
                    Console.WriteLine($"Result: {result}");
                    SavingHistory(userInput, result);
                    break;
                case "-":
                    result = firstNumber - secondNumber;
                    Console.WriteLine($"Result: {result}");
                    SavingHistory(userInput, result);
                    break;
                case "*":
                    result = firstNumber * secondNumber;
                    Console.WriteLine($"Result: {result}");
                    SavingHistory(userInput, result);
                    break;
                case "/":
                    if (secondNumber != 0)
                    {
                        result = firstNumber / secondNumber;
                        Console.WriteLine($"Result: {result}");
                        SavingHistory(userInput, result);
                    }
                    else
                    {
                        Console.WriteLine("Error: You can not divide by zero.");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid operator. Use +, -, *, or /.");
                    break;
            }
        }

        catch (FormatException)
        {
            Console.WriteLine("Invalid input format. Please use the format: operand (space) operator (space) operand.");
        }
    }
    static void SecondOption()
    {
        Console.Write("Please enter a number to calculate its square root: ");
        string userInput = Console.ReadLine();

        try
        {
            double userNumber = double.Parse(userInput);

            // if number is less than zero, no square root
            if (userNumber < 0)
            {
                throw new ArgumentOutOfRangeException("No calculations of the square root of a negative number.");
            }

            //calculating and saving to history
            double result = Math.Sqrt(userNumber);
            Console.WriteLine($"Square Root: √{userNumber} = {result}");
            SavingHistory($"√{userNumber}", result);
        }
        catch (FormatException)
        {
            Console.WriteLine("You can not enter letters. Please enter a number.");
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
    static void ThirdOption()
    {
        CheckingHistoryExists();
        var history = JsonConvert.DeserializeObject<List<HistoryOfCalculation>>(File.ReadAllText(jsonPath));

        if (history == null || history.Count == 0)
        {
            Console.WriteLine("No history available.");
        }
        else
        {
            Console.WriteLine("Calculation History:");
            int count = 1;
            foreach (var record in history)
            {
                Console.WriteLine($"{count}: {record.Expression} = {record.Result}");
                count++;
            }
        }
    }
    static void SavingHistory(string expression, double result)
    {
        CheckingHistoryExists();
        var history = JsonConvert.DeserializeObject<List<HistoryOfCalculation>>(File.ReadAllText(jsonPath))
                      ?? new List<HistoryOfCalculation>();
        history.Add(new HistoryOfCalculation
        {
            Expression = expression,
            Result = result
        });
        File.WriteAllText(jsonPath, JsonConvert.SerializeObject(history, Formatting.Indented));
    }
    public class HistoryOfCalculation
    {
        public string Expression { get; set; }
        public double Result { get; set; }
    }
}
