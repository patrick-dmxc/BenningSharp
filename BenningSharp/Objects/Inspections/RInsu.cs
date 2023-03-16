using BenningSharp.Entity;
using BenningSharp.Objects.Inspections.Reading;
using BenningSharp.Objects.Inspections.Reading.RInsulation;

namespace BenningSharp.Objects.Inspections
{
    public class RInsu : AbstractInspections
    {
        public override string Name => "RInsu. LN-PE";
        public override EInspectionMajor Type => EInspectionMajor.RInsu;
        public RInsu() : base(true) { }
        public RInsu(InspectionResult inspectionResult) : base(inspectionResult)
        {
        }

        protected override void initialize(IReadOnlyDictionary<string, KeyValueData> data)
        {
            var list = data.Where(d => d.Value.InspectionMajorKey == this.Type).Select(d => d.Value).ToList();
            double
                u = 0, i = 0, r = 0,
                r_Peak_Prim_PE = 0, r_Peak_Sec_PE = 0, r_Peak_Prim_Sec = 0,
                u_Limit_Prim_PE = 0, r_Limit_Prim_PE = 0,
                u_Limit_Sec_PE = 0, r_Limit_Sec_PE = 0,
                u_Limit_Prim_Sec = 0, r_Limit_Prim_Sec = 0,
                r_Limit_Welding_Prim_Welding = 0,
                r_Limit_Welding_Prim_Housing = 0,
                r_Limit_Welding_Welding_Housing = 0;
                
            foreach (var d in list)
            {
                switch (d.InspectionMiddleKey)
                {
                    case EInspectionMiddle.U_Insulation:
                        if (d.Value != null)
                        {
                            if (d.ValueType == EValueType.Measurement)
                                u = (double)d.Value;
                            else if (d.ValueType == EValueType.Limit)
                            {
                                if (d.InspectionMinorKey == (EInspectionMinor.Primary | EInspectionMinor.PE))
                                    u_Limit_Prim_PE= (double)d.Value;
                                else if (d.InspectionMinorKey == (EInspectionMinor.Secondary | EInspectionMinor.PE))
                                    u_Limit_Sec_PE = (double)d.Value;
                                else if (d.InspectionMinorKey == (EInspectionMinor.Primary | EInspectionMinor.Secondary))
                                    u_Limit_Prim_Sec = (double)d.Value;
                            }    
                        }
                        break;
                    case EInspectionMiddle.I_Insulation:
                        if (d.Value != null)
                        {
                            if (d.ValueType == EValueType.Measurement)
                                i = (double)d.Value;
                        }
                        break;
                    case EInspectionMiddle.R_Insulation:
                        if (d.Value != null)
                        {
                            if (d.ValueType == EValueType.Measurement)
                            {
                                if (d.InspectionMinorKey == EInspectionMinor.NONE)
                                    r = (double)d.Value;
                                else if (d.InspectionMinorKey == (EInspectionMinor.Peak | EInspectionMinor.PE | EInspectionMinor.Primary))
                                    r_Peak_Prim_PE = (double)d.Value;
                                else if (d.InspectionMinorKey == (EInspectionMinor.Peak | EInspectionMinor.PE | EInspectionMinor.Secondary))
                                    r_Peak_Sec_PE = (double)d.Value;
                                else if (d.InspectionMinorKey == (EInspectionMinor.Peak | EInspectionMinor.Primary | EInspectionMinor.Secondary))
                                    r_Peak_Prim_Sec = (double)d.Value;
                            }
                            else if (d.ValueType == EValueType.Limit)
                            {
                                if (d.InspectionMinorKey == (EInspectionMinor.Primary | EInspectionMinor.PE))
                                    r_Limit_Prim_PE = (double)d.Value;
                                else if (d.InspectionMinorKey == (EInspectionMinor.Secondary | EInspectionMinor.PE))
                                    r_Limit_Sec_PE = (double)d.Value;
                                else if (d.InspectionMinorKey == (EInspectionMinor.Primary | EInspectionMinor.Secondary))
                                    r_Limit_Prim_Sec = (double)d.Value;
                            }
                        }
                        break;
                    case EInspectionMiddle.Welding:
                        if (d.Value != null)
                        {
                            if (d.ValueType == EValueType.Limit)
                            {
                                if (d.InspectionMinorKey == (EInspectionMinor.Primary | EInspectionMinor.Welding))
                                    r_Limit_Welding_Prim_Welding = (double)d.Value;
                                else if (d.InspectionMinorKey == (EInspectionMinor.Primary | EInspectionMinor.Housing))
                                    r_Limit_Welding_Prim_Housing = (double)d.Value;
                                else if (d.InspectionMinorKey == (EInspectionMinor.Welding | EInspectionMinor.Housing))
                                    r_Limit_Welding_Welding_Housing = (double)d.Value;
                            }
                        }
                        break;
                }
            }
            if (u_Limit_Prim_PE > 0)
                this.AddReading(new RInsu_1(new Value(u, "V"), new Value(u_Limit_Prim_PE, "V"), new Value(i, "A"), new Value(r * 1000000, "Ω"), new Value(r_Peak_Prim_PE*1000000, "Ω"), new Value(r_Limit_Prim_PE * 1000000, "Ω")));
            if (u_Limit_Sec_PE > 0)
                this.AddReading(new RInsu_2(new Value(u, "V"), new Value(u_Limit_Sec_PE, "V"), new Value(i, "A"), new Value(r * 1000000, "Ω"), new Value(r_Peak_Sec_PE * 1000000, "Ω"), new Value(r_Limit_Sec_PE * 1000000, "Ω")));
            if (u_Limit_Prim_Sec > 0)
                this.AddReading(new RInsu_3(new Value(u, "V"), new Value(u_Limit_Prim_Sec, "V"), new Value(i, "A"), new Value(r * 1000000, "Ω"), new Value(r_Peak_Prim_Sec * 1000000, "Ω"), new Value(r_Limit_Prim_Sec * 1000000, "Ω")));
            if (r_Limit_Welding_Prim_Welding != 0
                || r_Limit_Welding_Prim_Housing != 0
                || r_Limit_Welding_Welding_Housing != 0)
                this.AddReading(new RInsu_4(new Value(u, "V"), new Value(u_Limit_Prim_PE, "V"), new Value(i, "A"), new Value(r * 1000000, "Ω"), new Value(r_Peak_Prim_Sec * 1000000, "Ω"), new Value(r_Limit_Prim_Sec * 1000000, "Ω")));
        }
    }
}