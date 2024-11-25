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
