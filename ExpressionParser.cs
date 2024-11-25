// ExpressionParser.cs
using System;
using System.Collections.Generic;

// This class removes spaces for simplicity
public class ExpressionParser
{
    public IExpression Parse(string expression)
    {
        // Remove spaces from the input expression
        expression = expression.Replace(" ", string.Empty);

        return ParseExpression(expression);
    }

    private IExpression ParseExpression(string expression)
    {
        // List to store parsed numbers
        var numbers = new List<IExpression>();
        // List to store parsed operators
        var operators = new List<char>();

        int i = 0;
        while (i < expression.Length)
        {
            if (char.IsDigit(expression[i]) || expression[i] == '.')
            {
                // Parse and store the number
                string number = ParseNumber(expression, ref i);
                numbers.Add(new Expression(double.Parse(number)));
            }
            else if ("+-*/".Contains(expression[i]))
            {
                // Store the operator
                operators.Add(expression[i]);
                i++;
            }
            else
            {
                // Skip invalid characters (malformed inputs will eventually throw exceptions elsewhere)
                i++;
            }
        }

        // Calculate the result based on operator precedence
        return Calculate(numbers, operators);
    }

    private string ParseNumber(string expression, ref int i)
    {
        // Find the start of the number
        int start = i;
        // Move through the digits and optional decimal point
        while (i < expression.Length && (char.IsDigit(expression[i]) || expression[i] == '.'))
        {
            i++;
        }
        // Extract the number as a substring
        return expression.Substring(start, i - start);
    }

    private IExpression Calculate(List<IExpression> numbers, List<char> operators)
    {
        // Perform multiplication and division first
        for (int i = 0; i < operators.Count; i++)
        {
            if (operators[i] == '*' || operators[i] == '/')
            {
                // Interpret the left and right operands
                double left = numbers[i].Interpret();
                double right = numbers[i + 1].Interpret();
                // Compute the result
                double result = operators[i] == '*' ? left * right : left / right;
                // Update the list with the new result
                numbers[i] = new Expression(result);
                numbers.RemoveAt(i + 1);
                operators.RemoveAt(i);
                i--; // Adjust index after modification
            }
        }

        // Then perform addition and subtraction
        for (int i = 0; i < operators.Count; i++)
        {
            // Interpret the left and right operands
            double left = numbers[i].Interpret();
            double right = numbers[i + 1].Interpret();
            // Compute the result
            double result = operators[i] == '+' ? left + right : left - right;
            // Update the list with the new result
            numbers[i] = new Expression(result);
            numbers.RemoveAt(i + 1);
            operators.RemoveAt(i);
            i--; // Adjust index after modification
        }

        // Return the final result as the single remaining number
        return numbers[0];
    }
}
