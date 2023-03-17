using BenningSharp.Entity;

namespace BenningSharp.Objects.Inspections.Reading.RCD
{
    public sealed class RCD_TripCurrent_Pos : AbstractRCD_TripCurrent
    {
        public sealed override string Name => "Trip Current 0°";
        public RCD_TripCurrent_Pos(Value i, Value iLimit) : base(i, iLimit)
        {
        }
    }
}