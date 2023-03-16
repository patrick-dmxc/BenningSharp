using BenningSharp.Entity;

namespace BenningSharp.Objects.Inspections.Reading.RConductor
{
    public abstract class AbstractRConductor : AbstractReadingResistance
    {
        public Value LineLength { get; private set; }
        public sealed override string LimitText => $"< {RLimit}";
        protected AbstractRConductor(Value u, Value i, Value r, Value rPeak, Value rLimit, Value lineLength) : base(u, i, r, rPeak, rLimit,rPeak<rLimit)
        {
            LineLength = lineLength;
        }
    }
}