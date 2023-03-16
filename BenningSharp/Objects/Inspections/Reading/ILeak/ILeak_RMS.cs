using BenningSharp.Entity;

namespace BenningSharp.Objects.Inspections.Reading.RInsulation
{
    public sealed class ILeak_RMS : AbstractILeak
    {
        public override string Name => "ILeak RMS";
        public ILeak_RMS(Value i, Value iLimit, Value uVers) : base(i, iLimit, uVers)
        {
        }
    }
}