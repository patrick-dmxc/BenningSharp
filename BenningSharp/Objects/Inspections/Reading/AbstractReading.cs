using BenningSharp.Entity;

namespace BenningSharp.Objects.Inspections.Reading
{
    public abstract class AbstractReading : IReading
    {
        public abstract string Name { get; }
        public virtual string Description { get; } = string.Empty;
        public virtual string MeasuringMethodText { get; } = string.Empty;
        public bool Passed { get; private set; }
        public Value Value { get; private set; }
        public Value Limit { get; private set; }
        public abstract string ReadingText { get; }
        public abstract string LimitText { get; }

        protected AbstractReading(bool passed, Value value, Value limit)
        {
            Passed = passed;
            Value = value;
            Limit = limit;
        }

        public sealed override string ToString()
        {
            string passed = Passed ? "Passed" : "Failed";
            return $"{Name}: {ReadingText} {LimitText} M: {MeasuringMethodText} {passed}";
        }
    }
}