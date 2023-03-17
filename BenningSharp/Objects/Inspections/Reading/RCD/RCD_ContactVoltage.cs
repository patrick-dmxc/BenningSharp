using BenningSharp.Entity;

namespace BenningSharp.Objects.Inspections.Reading.RCD
{
    public sealed class RCD_ContactVoltage : AbstractReading
    {
        public sealed override string Name => "Contact Voltage";
        public Value U { get; private set; }
        public Value ULimit { get; private set; }

        public sealed override string ReadingText => U.ToString();
        public sealed override string LimitText => $"< {ULimit}";
        public RCD_ContactVoltage(Value u, Value uLimit) : base(u < uLimit, u, uLimit)
        {
            U = u;
            ULimit = uLimit;
        }
    }
}