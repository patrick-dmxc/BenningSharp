using BenningSharp.Entity;

namespace BenningSharp.Objects.Inspections.Reading.RCD
{
    public sealed class RCD_TripButton : AbstractReading
    {
        public sealed override string Name => "Trip Button";
        public Value Count { get; private set; }

        public sealed override string ReadingText => string.Empty;
        public sealed override string LimitText => string.Empty;
        public RCD_TripButton(Value count) : base(count >= 1, count, new Value(1, ""))
        {
            Count = count;
        }
    }
}
