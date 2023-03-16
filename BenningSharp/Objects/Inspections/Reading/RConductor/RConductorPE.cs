using BenningSharp.Entity;

namespace BenningSharp.Objects.Inspections.Reading.RConductor
{
    public class RConductorPE : AbstractRConductor
    {
        public override string Name => "R Conductor (PE)";
        public RConductorPE(Value u, Value i, Value r, Value rPeak, Value rLimit, Value lineLength) : base(u, i, r, rPeak, rLimit, lineLength)
        {
        }
    }
}