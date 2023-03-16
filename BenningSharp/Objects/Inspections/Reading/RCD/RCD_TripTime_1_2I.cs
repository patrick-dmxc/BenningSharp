using BenningSharp.Entity;

namespace BenningSharp.Objects.Inspections.Reading.RCD
{
    public sealed class RCD_TripTime_1_2I : AbstractRCD_TripTime
    {
        public sealed override string Name => "Trip Time Ix½";
        public sealed override string LimitText => $">= {TLimit}";

        public RCD_TripTime_1_2I(Value tPos, Value tNeg, Value tLimit) : this(tPos, tNeg, Value.Max(tPos, tNeg), tLimit)
        {
        }
        public RCD_TripTime_1_2I(Value tPos, Value tNeg, Value tMax, Value tLimit) : base(tMax >= tLimit, tPos, tNeg, tMax, tLimit)
        {
        }
    }
}
