using BenningSharp.Entity;

namespace BenningSharp.Objects.Inspections.Reading.RInsulation
{
    public sealed class RInsu_1 : AbstractRInsu
    {
        public override string Name => "RInsu LN-PE";
        public override string MeasuringMethodText => "RInsu. 1";

        public RInsu_1(Value u, Value uLimit, Value i, Value r, Value rPeak, Value rLimit) : base(u, uLimit, i, r, rPeak, rLimit)
        {
        }
    }
}
