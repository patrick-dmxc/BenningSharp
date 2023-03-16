using BenningSharp.Entity;

namespace BenningSharp.Objects.Inspections.Reading.RPE
{
    public sealed class RPE : AbstractReadingResistance
    {
        public override string Name => "RPE";
        public override string LimitText => $"< {RLimit}";
        public Value LineLength { get; private set; }
        public int MeasuringPoints { get; private set; }
        public override string MeasuringMethodText
        {
            get
            {

                if (I < 3)
                    return "RPE 600mA";
                if (I >= 10)
                    return "RPE 10A";
                else
                    return base.MeasuringMethodText;
            }
        }

        public RPE(Value u, Value i, Value r, Value rPeak, Value rLimit, Value lineLength, int measuringPoints) : base(u, i, r, rPeak, rLimit, rPeak < rLimit)
        {
            LineLength = lineLength;
            MeasuringPoints = measuringPoints;
        }
    }
}