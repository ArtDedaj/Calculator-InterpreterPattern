using System;

public class Program
{
    public static void Main(string[] args)
    {
        // Test cases with valid and invalid inputs
        string[] testCases = new string[]
        {
            "5+2",          // Valid
            "10*3",         // Valid
            "3-4",          // Valid
            "5p+23.;s",     // Invalid
            "10/2",         // Valid
            "5++2",         // Invalid
            "10**2",        // Invalid
            "5+ 2",         // Valid (with space)
            "5/0",          // Valid, but will cause division by zero error
        };

        var parser = new ExpressionParser();

        foreach (var input in testCases)
        {
            try
            {
                Console.WriteLine($"Processing: {input}");
                IExpression expression = parser.Parse(input);
                Console.WriteLine($"Result of {input} = {expression.Interpret()}\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}\n");
            }
        }
    }
}
