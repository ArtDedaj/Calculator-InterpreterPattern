using System;
using System.Collections.Generic;

public class ExpressionParser
{
    public IExpression Parse(string expression)
    {
        // Remove spaces for simplicity
        expression = expression.Replace(" ", string.Empty);

        return ParseExpression(expression);
    }

    private IExpression ParseExpression(string expression)
    {
        var numbers = new List<IExpression>();
        var operators = new List<char>();

        int i = 0;
        while (i < expression.Length)
        {
            if (char.IsDigit(expression[i]) || expression[i] == '.')
            {
                // Parse the number
                string number = ParseNumber(expression, ref i);
                numbers.Add(new Expression(double.Parse(number)));
            }
            else if ("+-*/".Contains(expression[i]))
            {
                // Handle operators
                operators.Add(expression[i]);
                i++;
            }
            else
            {
                // No error handling, so just ignore this part (this will be the case for malformed inputs)
                // But this will still throw an exception internally when it can't parse.
                i++;
            }
        }

        // Calculate the result based on operator precedence (multiplication/division first, then addition/subtraction)
        return Calculate(numbers, operators);
    }

    private string ParseNumber(string expression, ref int i)
    {
        int start = i;
        while (i < expression.Length && (char.IsDigit(expression[i]) || expression[i] == '.'))
        {
            i++;
        }
        return expression.Substring(start, i - start);
    }

    private IExpression Calculate(List<IExpression> numbers, List<char> operators)
    {
        // Perform multiplication and division first
        for (int i = 0; i < operators.Count; i++)
        {
            if (operators[i] == '*' || operators[i] == '/')
            {
                double left = numbers[i].Interpret();
                double right = numbers[i + 1].Interpret();
                double result = operators[i] == '*' ? left * right : left / right;
                numbers[i] = new Expression(result);
                numbers.RemoveAt(i + 1);
                operators.RemoveAt(i);
                i--; // Adjust index after modification
            }
        }

        // Then perform addition and subtraction
        for (int i = 0; i < operators.Count; i++)
        {
            double left = numbers[i].Interpret();
            double right = numbers[i + 1].Interpret();
            double result = operators[i] == '+' ? left + right : left - right;
            numbers[i] = new Expression(result);
            numbers.RemoveAt(i + 1);
            operators.RemoveAt(i);
            i--; // Adjust index after modification
        }

        return numbers[0]; // Return the final result
    }
}
