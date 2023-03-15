using BenningSharp.Entity;

namespace BenningSharp.Objects.Inspections.Reading
{
    public interface IReading
    {
        string Name { get; }
        string Description { get; }
        string MeasuringMethodText { get; }
        bool Passed { get; }
        Value Value { get; }
        Value Limit { get; }
        string ReadingText { get; }
        string LimitText { get; }
    }
}