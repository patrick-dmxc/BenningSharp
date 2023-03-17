using BenningSharp.Entity;

namespace BenningSharp.Objects.Inspections.Reading.RCD
{
    public sealed class RCD_TripCurrent_Neg : AbstractRCD_TripCurrent
    {
        public sealed override string Name => "Trip Current 180°";
        public RCD_TripCurrent_Neg(Value i, Value iLimit) : base(i, iLimit)
        {
        }
    }
}