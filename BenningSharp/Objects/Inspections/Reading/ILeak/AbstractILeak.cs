using BenningSharp.Entity;

namespace BenningSharp.Objects.Inspections.Reading.RInsulation
{
    public abstract class AbstractILeak : AbstractReading
    {
        public Value I { get; private set; }
        public Value ILimit { get; private set; }
        public Value UVers { get; private set; }
        public sealed override string ReadingText => I.ToString();
        public sealed override string LimitText => $"< {ILimit}";

        public AbstractILeak(Value i, Value iLimit, Value uVers) : base(i<iLimit,i,iLimit)
        {
            I = i;
            ILimit = iLimit;
            UVers = uVers;
        }
    }
}