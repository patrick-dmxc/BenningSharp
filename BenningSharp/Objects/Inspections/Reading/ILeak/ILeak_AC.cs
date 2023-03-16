using BenningSharp.Entity;

namespace BenningSharp.Objects.Inspections.Reading.RInsulation
{
    public sealed class ILeak_AC : AbstractILeak
    {
        public override string Name => "ILeak AC";
        public ILeak_AC(Value i, Value iLimit, Value uVers) : base(i, iLimit, uVers)
        {
        }
    }
}