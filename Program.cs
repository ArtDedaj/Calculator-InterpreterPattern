using System;

public class Program
{
    public static void Main(string[] args)
    {
        // Define a single test expression
        string input = "5+l2.k";

        // Create an instance of ExpressionParser to parse and evaluate the expression
        var parser = new ExpressionParser();

        // Parse the expression and get the result
        IExpression expression = parser.Parse(input);

        // Output the result
        Console.WriteLine($"Result of {input} = {expression.Interpret()}");
    }
}
