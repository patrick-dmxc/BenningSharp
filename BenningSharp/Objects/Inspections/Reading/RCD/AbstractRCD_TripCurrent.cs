using BenningSharp.Entity;

namespace BenningSharp.Objects.Inspections.Reading.RCD
{
    public abstract class AbstractRCD_TripCurrent : AbstractReading
    {
        public Value I { get; private set; }
        public Value ILimit { get; private set; }

        public sealed override string ReadingText => I.ToString();
        public sealed override string LimitText => $"< {ILimit}";
        public AbstractRCD_TripCurrent(Value i, Value iLimit) : base(i < iLimit, i, iLimit)
        {
            I = i;
            ILimit = iLimit;
        }
    }
}