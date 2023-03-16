using BenningSharp.Entity;

namespace BenningSharp.Objects.Inspections.Reading.RInsulation
{
    public sealed class ILeak_DC : AbstractILeak
    {
        public override string Name => "ILeak DC";
        public ILeak_DC(Value i, Value iLimit, Value uVers) : base(i, iLimit, uVers)
        {
        }
    }
}