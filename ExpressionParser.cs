// ExpressionParser.cs
public class ExpressionParser
{
    // Method to parse a simple mathematical expression and return an IExpression
    public IExpression Parse(string expression)
    {
        var parts = expression.Split(' ');  // Split the expression by space

        if (parts.Length == 1)  // Handle simple numbers
        {
            return new Expression(double.Parse(parts[0]));
        }
        // Further parsing logic can be added for operators
        // For example, to support sum, subtraction, etc.
        throw new NotImplementedException("Only simple number expressions are currently supported.");
    }
}
