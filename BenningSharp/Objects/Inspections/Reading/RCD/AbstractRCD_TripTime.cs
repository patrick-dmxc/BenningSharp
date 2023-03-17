using BenningSharp.Entity;

namespace BenningSharp.Objects.Inspections.Reading.RCD
{
    public abstract class AbstractRCD_TripTime : AbstractReading
    {
        public Value TPos { get; private set; }
        public Value TNeg { get; private set; }
        public Value TMax { get; private set; }
        public Value TLimit { get; private set; }

        public sealed override string ReadingText => TMax.ToString();
        public AbstractRCD_TripTime(bool passed, Value tPos, Value tNeg, Value tMax, Value tLimit) : base(passed, tMax, tLimit)
        {
            TPos = tPos;
            TNeg = tNeg;
            TMax = tMax;
            TLimit = tLimit;
        }
    }
}