namespace BenningSharp.Entity
{
    public struct Value
    {
        public readonly double Double;
        public readonly string Unit;
        public readonly string Formated;

        public Value(double @double, string unit)
        {
            Double = @double;
            Unit = unit;
            Formated = Double.FormatToText(Unit);
        }
        public static implicit operator double(Value value)
        {
            return value.Double;
        }

        public override string ToString()
        {
            return Formated;
        }
    }
}