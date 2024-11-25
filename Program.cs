// Program.cs
using System;

class Program
{
    static void Main(string[] args)
    {
        string input = "5+ 2";  // Example input, simple number expression
        var parser = new ExpressionParser();

        try
        {
            IExpression expression = parser.Parse(input);
            double result = expression.Interpret();
            Console.WriteLine($"Result: {result}");  // Output the result
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
