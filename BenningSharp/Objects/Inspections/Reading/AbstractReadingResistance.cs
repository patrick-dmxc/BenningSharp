using BenningSharp.Entity;

namespace BenningSharp.Objects.Inspections.Reading
{
    public abstract class AbstractReadingResistance : AbstractReading
    {
        public Value U { get; private set; }
        public Value I { get; private set; }
        public Value R { get; private set; }
        public Value RPeak { get; private set; }
        public Value RLimit { get; private set; }

        public Value LineLength { get; private set; }
        public int MeasuringPoints { get; private set; }

        public sealed override string ReadingText => RPeak.ToString();
        public AbstractReadingResistance(Value u, Value i, Value r, Value rPeak, Value rLimit) : base(rPeak >= rLimit, rPeak, rLimit)
        {
            U = u;
            I = i;
            R = r;
            RPeak = rPeak;
            RLimit = rLimit;
        }
    }
}