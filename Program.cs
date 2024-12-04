using System;

public class Program
{
    public static void Main(string[] args)
    {
        // Simple equation to evaluate (change this to whatever equation you want)
        string input = "5+3*2"; // Example: Simple equation

        // Create an instance of ExpressionParser
        var parser = new ExpressionParser();

        try
        {
            // Parse the input expression
            IExpression expression = parser.Parse(input);

            // Output the result
            Console.WriteLine($"Input: {input}");
            Console.WriteLine($"Output: {expression.Interpret()}");
        }
        catch (Exception ex)
        {
            // Handle any errors in parsing
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
