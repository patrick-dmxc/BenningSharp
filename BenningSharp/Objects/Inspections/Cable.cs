using BenningSharp.Entity;
using BenningSharp.Objects.Inspections.Reading.RConductor;
using BenningSharp.Objects.Inspections.Reading.RInsulation;
using System.Net.NetworkInformation;

namespace BenningSharp.Objects.Inspections
{
    public class Cable : AbstractInspections
    {
        public override string Name => "Cable";
        public override EInspectionMajor Type => EInspectionMajor.Cable;

        public Cable() : base(true) { }
        public Cable(InspectionResult inspectionResult) : base(inspectionResult)
        {
        }

        protected override void initialize(IReadOnlyDictionary<string, KeyValueData> data)
        {
            var list = data.Where(d => d.Value.InspectionMajorKey == this.Type).Select(d => d.Value).ToList();
            double u = 0, i = 0, r = 0, rPeak = 0, rL = 0, rN = 0, rPE = 0, rLimit = 0, lineLength = 0;
            long status = 0;
            foreach (var d in list)
            {
                switch (d.InspectionMiddleKey)
                {
                    case EInspectionMiddle.I_Conductor:
                        if (d.Value != null && d.ValueType == EValueType.Measurement)
                            i = (double)d.Value;
                        break;
                    case EInspectionMiddle.U_Conductor:
                        if (d.Value != null && d.ValueType == EValueType.Measurement)
                            u = (double)d.Value;
                        break;
                    case EInspectionMiddle.R_Conductor:
                        if (d.Value != null)
                            if (d.ValueType == EValueType.Measurement)
                            {
                                if (d.InspectionMinorKey == EInspectionMinor.NONE)
                                    r = (double)d.Value;
                                if (d.InspectionMinorKey == EInspectionMinor.Peak)
                                    rPeak = (double)d.Value;
                            }
                            else if (d.ValueType == EValueType.Limit)
                                if (d.InspectionMinorKey == EInspectionMinor.NONE)
                                    rLimit = (double)d.Value;
                        break;
                    case EInspectionMiddle.R:
                        if (d.Value != null)
                            if (d.ValueType == EValueType.Measurement)
                            {
                                if (d.InspectionMinorKey == EInspectionMinor.L)
                                    rL = (double)d.Value;
                                if (d.InspectionMinorKey == EInspectionMinor.N)
                                    rN = (double)d.Value;
                                if (d.InspectionMinorKey == EInspectionMinor.PE)
                                    rPE = (double)d.Value;
                            }
                            else if (d.ValueType == EValueType.Limit)
                                if (d.InspectionMinorKey == EInspectionMinor.NONE)
                                    rLimit = (double)d.Value;
                        break;
                    case EInspectionMiddle.Conductor:
                        if (d.Value != null)
                            lineLength = (double)d.Value;
                        break;
                    case EInspectionMiddle.Status:
                        if (d.Value != null)
                            status = (long)d.Value;
                        break;
                }
            }

            this.AddReading(new RConductor(new Value(u, "V"), new Value(i, "A"), new Value(r, "Ω"), new Value(rPeak, "Ω"), new Value(rLimit, "Ω"), new Value(lineLength, "m")));
            this.AddReading(new RConductorL(new Value(u, "V"), new Value(i, "A"), new Value(r, "Ω"), new Value(rL, "Ω"), new Value(rLimit / 3, "Ω"), new Value(lineLength, "m")));
            this.AddReading(new RConductorN(new Value(u, "V"), new Value(i, "A"), new Value(r, "Ω"), new Value(rN, "Ω"), new Value(rLimit / 3, "Ω"), new Value(lineLength, "m")));
            this.AddReading(new RConductorPE(new Value(u, "V"), new Value(i, "A"), new Value(r, "Ω"), new Value(rPE, "Ω"), new Value(rLimit / 3, "Ω"), new Value(lineLength, "m")));
        }
    }
}