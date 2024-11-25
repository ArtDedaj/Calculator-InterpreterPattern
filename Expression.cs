// Expression.cs
public class Expression : IExpression
{
    private double _value;

    // Constructor to initialize the value
    public Expression(double value)
    {
        _value = value;
    }

    // Implement the Interpret method to return the value of the expression
    public double Interpret()
    {
        return _value;
    }
}
