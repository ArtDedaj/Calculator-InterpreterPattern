//Expression.cs 
// Represents a simple number expression in the Interpreter pattern.
// This class implements the IExpression interface and encapsulates a numeric value.
// It is used to evaluate and return the numeric value when the Interpret method is called.
public class Expression : IExpression
{
    private double _value;

    public Expression(double value)
    {
        _value = value;
    }

    public double Interpret()
    {
        return _value;
    }
}
