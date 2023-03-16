using BenningSharp.Entity;
using BenningSharp.Objects.Inspections.Reading.RInsulation;

namespace BenningSharp.Objects.Inspections
{
    public class ILeak : AbstractInspections
    {
        public override string Name => "ILeak";
        public override EInspectionMajor Type => EInspectionMajor.ILeak;

        public ILeak() : base(true) { }
        public ILeak(InspectionResult inspectionResult) : base(inspectionResult)
        {
        }

        protected override void initialize(IReadOnlyDictionary<string, KeyValueData> data)
        {
            var list = data.Where(d => d.Value.InspectionMajorKey == this.Type).Select(d => d.Value).ToList();
            double
                i_Leak_RMS = 0, i_Leak_RMS_Peak = 0, i_Leak_RMS_Limit = 0,
                i_Leak_AC = 0, i_Leak_AC_Peak = 0, i_Leak_AC_Limit = 0,
                i_Leak_DC = 0, i_Leak_DC_Peak = 0, i_Leak_DC_Limit = 0,
                uVers = 0;
            foreach (var d in list)
            {
                switch (d.InspectionMiddleKey)
                {
                    case EInspectionMiddle.I_Leak:
                        if (d.Value != null)
                            if (d.ValueType == EValueType.Measurement)
                            {
                                if (d.InspectionMinorKey == EInspectionMinor.RMS)
                                    i_Leak_RMS = (double)d.Value;
                                if (d.InspectionMinorKey == (EInspectionMinor.RMS | EInspectionMinor.Peak))
                                    i_Leak_RMS_Peak = (double)d.Value;
                                if (d.InspectionMinorKey == EInspectionMinor.AC)
                                    i_Leak_AC = (double)d.Value;
                                if (d.InspectionMinorKey == (EInspectionMinor.AC | EInspectionMinor.Peak))
                                    i_Leak_AC_Peak = (double)d.Value;
                                if (d.InspectionMinorKey == EInspectionMinor.DC)
                                    i_Leak_DC = (double)d.Value;
                                if (d.InspectionMinorKey == (EInspectionMinor.DC | EInspectionMinor.Peak))
                                    i_Leak_DC_Peak = (double)d.Value;
                            }
                            else if (d.ValueType == EValueType.Limit)
                            {
                                if (d.InspectionMinorKey == EInspectionMinor.RMS)
                                    i_Leak_RMS_Limit = (double)d.Value;
                                if (d.InspectionMinorKey == EInspectionMinor.AC)
                                    i_Leak_AC_Limit = (double)d.Value;
                                if (d.InspectionMinorKey == EInspectionMinor.DC)
                                    i_Leak_DC_Limit = (double)d.Value;
                            }
                        break;
                    case EInspectionMiddle.U_Supplied:
                        if (d.Value != null && d.ValueType == EValueType.Measurement)
                            uVers = (double)d.Value;
                        break;
                }
            }
            if (i_Leak_RMS != 0)
                this.AddReading(new ILeak_RMS(new Value(i_Leak_RMS, "A"), new Value(i_Leak_RMS_Limit, "A"), new Value(uVers, "V")));
            if (i_Leak_AC != 0)
                this.AddReading(new ILeak_AC(new Value(i_Leak_AC, "A"), new Value(i_Leak_AC_Limit, "A"), new Value(uVers, "V")));
            if (i_Leak_DC != 0)
                this.AddReading(new ILeak_DC(new Value(i_Leak_DC, "A"), new Value(i_Leak_DC_Limit, "A"), new Value(uVers, "V")));
        }
    }
}