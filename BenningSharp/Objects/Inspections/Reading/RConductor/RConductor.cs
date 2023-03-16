using BenningSharp.Entity;

namespace BenningSharp.Objects.Inspections.Reading.RConductor
{
    public class RConductor : AbstractRConductor
    {
        public override string Name => "R Conductor (L->N->PE)";
        public RConductor(Value u, Value i, Value r, Value rPeak, Value rLimit, Value lineLength) : base(u, i, r, rPeak, rLimit, lineLength)
        {
        }
    }
}