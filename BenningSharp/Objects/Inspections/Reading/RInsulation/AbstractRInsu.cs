using BenningSharp.Entity;

namespace BenningSharp.Objects.Inspections.Reading.RInsulation
{
    public abstract class AbstractRInsu : AbstractReadingResistance
    {
        public Value ULimit { get; private set; }
        public sealed override string LimitText => $">= {RLimit}";

        public AbstractRInsu(Value u, Value uLimit, Value i, Value r, Value rPeak, Value rLimit) : base(u, i, r, rPeak, rLimit, rPeak >= rLimit)
        {
            ULimit = uLimit;
        }
    }
}