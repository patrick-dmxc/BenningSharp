using BenningSharp.Entity;
using BenningSharp.Objects.Inspections.Reading;
using BenningSharp.Objects.Inspections.Reading.RPE;

namespace BenningSharp.Objects.Inspections
{
    public class RPE : AbstractInspections
    {
        public override string Name => "RPE";
        public override EInspectionMajor Type => EInspectionMajor.RPE;

        public RPE() : base(true) { }
        public RPE(InspectionResult inspectionResult) : base(inspectionResult)
        {
        }

        protected override void initialize(IReadOnlyDictionary<string, KeyValueData> data)
        {
            var list = data.Where(d => d.Value.InspectionMajorKey == this.Type).Select(d => d.Value).ToList();
            double u = 0, i = 0, r = 0, rPeak = 0, rLimit = 0, lineLength = 0;
            int measuringPoints = 0;
            foreach (var d in list)
            {
                switch (d.InspectionMiddleKey)
                {
                    case EInspectionMiddle.U_PE:
                        if (d.Value != null && d.ValueType == EValueType.Measurement)
                            u = (double)d.Value;
                        break;
                    case EInspectionMiddle.I_PE:
                        if (d.Value != null && d.ValueType == EValueType.Measurement)
                            i = (double)d.Value;
                        break;
                    case EInspectionMiddle.R_PE:
                        if (d.Value != null)
                        {
                            if (d.ValueType == EValueType.Measurement)
                            {
                                if (d.InspectionMinorKey == EInspectionMinor.Peak)
                                    rPeak = (double)d.Value;
                                else
                                    r = (double)d.Value;
                            }
                            else if (d.ValueType == EValueType.Limit)
                                rLimit = (double)d.Value;
                        }
                        break;
                    case EInspectionMiddle.R_Conductor:
                        if (d.Value != null)
                            lineLength = (double)d.Value;
                        break;
                    case EInspectionMiddle.NONE:
                        if (d.Key.Contains("anz") && d.Value != null)
                            measuringPoints = (int)(double)d.Value;
                        break;
                }
            }
            this.AddReading(new Reading.RPE.RPE(new Value(u, "V"), new Value(i, "A"), new Value(r, "Ω"), new Value(rPeak, "Ω"), new Value(rLimit, "Ω"), new Value(lineLength, "m"), measuringPoints));
        }
    }
}