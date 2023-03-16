using BenningSharp.Entity;

namespace BenningSharp.Objects.Inspections.Reading.RInsulation
{
    public sealed class RInsu_2 : AbstractRInsu
    {
        public override string Name => "RInsu Sec-PE";
        public override string MeasuringMethodText => "RInsu. 2";

        public RInsu_2(Value u, Value uLimit, Value i, Value r, Value rPeak, Value rLimit) : base(u, uLimit, i, r, rPeak, rLimit)
        {
        }
    }
}
