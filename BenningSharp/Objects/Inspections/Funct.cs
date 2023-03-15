using BenningSharp.Entity;
using BenningSharp.Objects.Inspections.Reading;

namespace BenningSharp.Objects.Inspections
{
    public class Funct : AbstractInspections
    {
        public override string Name => "Funct.";
        public override EInspectionMajor Type => EInspectionMajor.Funct;
        public Funct() : base(true) { }
        public Funct(InspectionResult inspectionResult) : base(inspectionResult)
        {
        }

        protected override void initialize(IReadOnlyDictionary<string, KeyValueData> data)
        {
            var list = data.Where(d => d.Value.InspectionMajorKey == this.Type).Select(d => d.Value).ToList();
            double u_L1 = 0, u_L2 = 0, u_L3 = 0,
                   u_L1_Peak = 0, u_L2_Peak = 0, u_L3_Peak = 0,
                   i_L1 = 0, i_L2 = 0, i_L3 = 0,
                   i_L1_Peak = 0, i_L2_Peak = 0, i_L3_Peak = 0,
                   i_PE = 0, i_PE_Peak = 0, i_PE_Limit = 0,
                   p = 0, p_Peak = 0,
                   s = 0, s_Peak = 0;
            foreach (var d in list)
            {
                switch (d.InspectionMiddleKey)
                {
                    case EInspectionMiddle.U:
                        if (d.Value != null)
                        {
                            if (d.InspectionMinorKey.HasFlag(EInspectionMinor.L1))
                                if (!d.InspectionMinorKey.HasFlag(EInspectionMinor.Peak))
                                    u_L1 = (double)d.Value;
                                else
                                    u_L1_Peak = (double)d.Value;
                            if (d.InspectionMinorKey.HasFlag(EInspectionMinor.L2))
                                if (!d.InspectionMinorKey.HasFlag(EInspectionMinor.Peak))
                                    u_L2 = (double)d.Value;
                                else
                                    u_L2_Peak = (double)d.Value;
                            if (d.InspectionMinorKey.HasFlag(EInspectionMinor.L3))
                                if (!d.InspectionMinorKey.HasFlag(EInspectionMinor.Peak))
                                    u_L3 = (double)d.Value;
                                else
                                    u_L3_Peak = (double)d.Value;
                        }
                        break;
                    case EInspectionMiddle.I:
                        if (d.Value != null)
                        {
                            if (d.InspectionMinorKey.HasFlag(EInspectionMinor.L1))
                                if (!d.InspectionMinorKey.HasFlag(EInspectionMinor.Peak))
                                    i_L1 = (double)d.Value;
                                else
                                    i_L1_Peak = (double)d.Value;
                            if (d.InspectionMinorKey.HasFlag(EInspectionMinor.L2))
                                if (!d.InspectionMinorKey.HasFlag(EInspectionMinor.Peak))
                                    i_L2 = (double)d.Value;
                                else
                                    i_L2_Peak = (double)d.Value;
                            if (d.InspectionMinorKey.HasFlag(EInspectionMinor.L3))
                                if (!d.InspectionMinorKey.HasFlag(EInspectionMinor.Peak))
                                    i_L3 = (double)d.Value;
                                else
                                    i_L3_Peak = (double)d.Value;
                        }
                        break;
                    case EInspectionMiddle.I_PE:
                        if (d.Value != null)
                        {
                            if (d.ValueType == EValueType.Measurement)
                                if (!d.InspectionMinorKey.HasFlag(EInspectionMinor.Peak))
                                    i_PE = (double)d.Value;
                                else
                                    i_PE_Peak = (double)d.Value;
                            else if (d.ValueType == EValueType.Limit)
                                i_PE_Limit = (double)d.Value;
                        }
                        break;
                    case EInspectionMiddle.P:
                        if (d.Value != null)
                        {
                            if (!d.InspectionMinorKey.HasFlag(EInspectionMinor.Peak))
                                p = (double)d.Value;
                            else
                                p_Peak = (double)d.Value;
                        }
                        break;
                    case EInspectionMiddle.S:
                        if (d.Value != null)
                        {
                            if (!d.InspectionMinorKey.HasFlag(EInspectionMinor.Peak))
                                s = (double)d.Value;
                            else
                                s_Peak = (double)d.Value;
                        }
                        break;
                }
            }
            this.AddReading(new IPE_(
                new Value(u_L1, "V"), new Value(u_L2, "V"), new Value(u_L3, "V"),
                new Value(u_L1_Peak, "V"), new Value(u_L2_Peak, "V"), new Value(u_L3_Peak, "V"),
                new Value(i_L1, "A"), new Value(i_L2, "A"), new Value(i_L3, "A"),
                new Value(i_L1_Peak, "A"), new Value(i_L2_Peak, "A"), new Value(i_L3_Peak, "A"),
                new Value(i_PE, "A"), new Value(i_PE_Peak, "A"), new Value(i_PE_Limit, "A"),
                new Value(p, "W"), new Value(p_Peak, "W"),
                new Value(s, "VA"), new Value(s_Peak, "VA")));
        }

        public sealed class IPE_ : AbstractReading
        {
            public override string Name => "IPE Funct.";
            public Value U_L1 { get; private set; }
            public Value U_L2 { get; private set; }
            public Value U_L3 { get; private set; }
            public Value U_L1_Peak { get; private set; }
            public Value U_L2_Peak { get; private set; }
            public Value U_L3_Peak { get; private set; }
            public Value I_L1 { get; private set; }
            public Value I_L2 { get; private set; }
            public Value I_L3 { get; private set; }
            public Value I_L1_Peak { get; private set; }
            public Value I_L2_Peak { get; private set; }
            public Value I_L3_Peak { get; private set; }
            public Value I_PE { get; private set; }
            public Value I_PE_Peak { get; private set; }
            public Value I_PE_Limit { get; private set; }
            public Value P { get; private set; }
            public Value P_Peak { get; private set; }
            public Value S { get; private set; }
            public Value S_Peak { get; private set; }

            public override string ReadingText => I_PE_Peak.ToString();
            public override string LimitText => $"< {I_PE_Limit}";

            public IPE_(Value u_L1, Value u_L2, Value u_L3, Value u_L1_Peak, Value u_L2_Peak, Value u_L3_Peak,
                        Value i_L1, Value i_L2, Value i_L3, Value i_L1_Peak, Value i_L2_Peak, Value i_L3_Peak,
                        Value i_PE, Value i_PE_Peak, Value i_PE_Limit, Value p, Value p_Peak, Value s,
                        Value s_Peak) : base(i_PE_Peak < i_PE_Limit, i_PE_Peak, i_PE_Limit)
            {
                U_L1 = u_L1;
                U_L2 = u_L2;
                U_L3 = u_L3;
                U_L1_Peak = u_L1_Peak;
                U_L2_Peak = u_L2_Peak;
                U_L3_Peak = u_L3_Peak;
                I_L1 = i_L1;
                I_L2 = i_L2;
                I_L3 = i_L3;
                I_L1_Peak = i_L1_Peak;
                I_L2_Peak = i_L2_Peak;
                I_L3_Peak = i_L3_Peak;
                I_PE = i_PE;
                I_PE_Peak = i_PE_Peak;
                I_PE_Limit = i_PE_Limit;
                P = p;
                P_Peak = p_Peak;
                S = s;
                S_Peak = s_Peak;
            }
        }
    }
}