using System;
//TestCases.cs
public class TestCases
{
    public static void RunTests()
    {
        var parser = new ExpressionParser();

        // Test case 1: Simple addition expression
        string input1 = "5+2";
        IExpression expression1 = parser.Parse(input1);
        Console.WriteLine($"Input: {input1}");
        Console.WriteLine($"Output: {expression1.Interpret()}");

        // Test case 2: Simple subtraction expression
        string input2 = "10-3";
        IExpression expression2 = parser.Parse(input2);
        Console.WriteLine($"Input: {input2}");
        Console.WriteLine($"Output: {expression2.Interpret()}");

        // Test case 3: Simple multiplication expression
        string input3 = "4*2";
        IExpression expression3 = parser.Parse(input3);
        Console.WriteLine($"Input: {input3}");
        Console.WriteLine($"Output: {expression3.Interpret()}");

        // Test case 4: Simple division expression
        string input4 = "9/3";
        IExpression expression4 = parser.Parse(input4);
        Console.WriteLine($"Input: {input4}");
        Console.WriteLine($"Output: {expression4.Interpret()}");

        // Test case 5: Invalid input (non-numeric, like "asd")
        string input5 = "asd";
        try
        {
            IExpression expression5 = parser.Parse(input5);
            Console.WriteLine($"Input: {input5}");
            Console.WriteLine($"Output: {expression5.Interpret()}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Input: {input5}");
            Console.WriteLine($"Error: {ex.Message}");
        }

        // Test case 6: Invalid input (extra operators, like "5++2")
        string input6 = "5++2";
        try
        {
            IExpression expression6 = parser.Parse(input6);
            Console.WriteLine($"Input: {input6}");
            Console.WriteLine($"Output: {expression6.Interpret()}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Input: {input6}");
            Console.WriteLine($"Error: {ex.Message}");
        }
        // Test case 7
        string input7 = "1+2*2+1";
        try
        {
            IExpression expression7 = parser.Parse(input7);
            Console.WriteLine($"Input: {input7}");
            Console.WriteLine($"Output: {expression7.Interpret()}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Input: {input7}");
            Console.WriteLine($"Error: {ex.Message}");
        }
        // Test case 8: no input
        string input8 = "";
        try
        {
            IExpression expression8 = parser.Parse(input8);
            Console.WriteLine($"Input: no input {input8}");
            Console.WriteLine($"Output: {expression8.Interpret()}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Input: {input8}");
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
