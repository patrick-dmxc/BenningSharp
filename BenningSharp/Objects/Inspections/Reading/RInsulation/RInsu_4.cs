using BenningSharp.Entity;

namespace BenningSharp.Objects.Inspections.Reading.RInsulation
{
    public sealed class RInsu_4 : AbstractRInsu
    {
        public override string Name => "RInsu Welding";
        public override string MeasuringMethodText => "RInsu. 4";

        public RInsu_4(Value u, Value uLimit, Value i, Value r, Value rPeak, Value rLimit) : base(u, uLimit, i, r, rPeak, rLimit)
        {
        }
    }
}