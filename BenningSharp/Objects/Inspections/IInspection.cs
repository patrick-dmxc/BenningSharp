using BenningSharp.Objects.Inspections.Reading;

namespace BenningSharp.Objects.Inspections
{
    public interface IInspection
    {
        string Name { get; }
        EInspectionMajor Type { get; }
        bool Passed { get; }

        bool IsTemplate { get; }

        InspectionResult? InspectionResult { get; }

        IReadOnlyCollection<IReading> Readings { get; }
    }
}