using BenningSharp.Entity;

namespace BenningSharp.Objects.Inspections.Reading.RInsulation
{
    public sealed class RInsu_3 : AbstractRInsu
    {
        public override string Name => "RInsu LN-Sec";
        public override string MeasuringMethodText => "RInsu. 3";

        public RInsu_3(Value u, Value uLimit, Value i, Value r, Value rPeak, Value rLimit) : base(u, uLimit, i, r, rPeak, rLimit)
        {
        }
    }
}