using BenningSharp.Entity;
using BenningSharp.Objects.Inspections.Reading;
using BenningSharp.Objects.Inspections.Reading.RCD;
using static BenningSharp.Objects.Inspections.RPE;

namespace BenningSharp.Objects.Inspections
{
    public class RCD : AbstractInspections
    {
        public override string Name => "RCD";
        public override EInspectionMajor Type => EInspectionMajor.RCD;
        public RCD() : base(true) { }
        public RCD(InspectionResult inspectionResult) : base(inspectionResult)
        {
        }

        protected override void initialize(IReadOnlyDictionary<string, KeyValueData> data)
        {
            var list = data.Where(d => d.Value.InspectionMajorKey == this.Type).Select(d => d.Value).ToList();
            double
                uL_N = 0, uL_PE = 0, uN_PE = 0, uContact = 0, uContact_Limit = 0,
                iRMS = 0, iTrip_Pos = 0, iTrip_Neg = 0, iTrip_Limit = 0,
                tTrip_1I_Pos = 0, tTrip_1I_Neg = 0, tTrip_1I_Limit = 0,
                tTrip_1_2I_Pos = 0, tTrip_1_2I_Neg = 0, tTrip_1_2I_Limit = 0,
                tTrip_5I_Pos = 0, tTrip_5I_Neg = 0, tTrip_5I_Limit = 0,
                count = 0;
            long status = 0, status2 = 0;

            foreach (var d in list)
            {
                switch (d.InspectionMiddleKey)
                {
                    case EInspectionMiddle.U_L_N:
                        if (d.Value != null && d.ValueType == EValueType.Measurement)
                            uL_N = (double)d.Value;
                        break;
                    case EInspectionMiddle.U_L_PE:
                        if (d.Value != null && d.ValueType == EValueType.Measurement)
                            uL_PE = (double)d.Value;
                        break;
                    case EInspectionMiddle.U_N_PE:
                        if (d.Value != null && d.ValueType == EValueType.Measurement)
                            uN_PE = (double)d.Value;
                        break;
                    case EInspectionMiddle.U_Contact:
                        if (d.Value != null && d.ValueType == EValueType.Measurement)
                            uContact = (double)d.Value;
                        if (d.Value != null && d.ValueType == EValueType.Limit)
                            uContact_Limit = (double)d.Value;
                        break;
                    case EInspectionMiddle.I_RMS:
                        if (d.Value != null)
                        {
                            if (d.ValueType == EValueType.Measurement)
                                iRMS = (double)d.Value;
                        }
                        break;
                    case EInspectionMiddle.I_Tripping:
                        if (d.Value != null)
                        {
                            if (d.ValueType == EValueType.Measurement)
                            {
                                if (d.InspectionMinorKey == (EInspectionMinor._1I | EInspectionMinor.Positive))
                                    iTrip_Pos = (double)d.Value;
                                if (d.InspectionMinorKey == (EInspectionMinor._1I | EInspectionMinor.Negative))
                                    iTrip_Neg = (double)d.Value;
                            }
                            else if (d.ValueType == EValueType.Limit)
                            {
                                if (d.InspectionMinorKey == EInspectionMinor._1I)
                                    iTrip_Limit = (double)d.Value;
                            }
                        }
                        break;
                    case EInspectionMiddle.T_Tripping:
                        if (d.Value != null)
                        {
                            if (d.ValueType == EValueType.Measurement)
                            {
                                if (d.InspectionMinorKey == (EInspectionMinor.Positive | EInspectionMinor._1I))
                                    tTrip_1I_Pos = (double)d.Value;
                                if (d.InspectionMinorKey == (EInspectionMinor.Negative | EInspectionMinor._1I))
                                    tTrip_1I_Neg = (double)d.Value;
                                if (d.InspectionMinorKey == (EInspectionMinor.Positive | EInspectionMinor._1_2I))
                                    tTrip_1_2I_Pos = (double)d.Value;
                                if (d.InspectionMinorKey == (EInspectionMinor.Negative | EInspectionMinor._1_2I))
                                    tTrip_1_2I_Neg = (double)d.Value;
                                if (d.InspectionMinorKey == (EInspectionMinor.Positive | EInspectionMinor._5I))
                                    tTrip_5I_Pos = (double)d.Value;
                                if (d.InspectionMinorKey == (EInspectionMinor.Negative | EInspectionMinor._5I))
                                    tTrip_5I_Neg = (double)d.Value;
                            }
                            else if (d.ValueType == EValueType.Limit)
                            {
                                if (d.InspectionMinorKey == EInspectionMinor._1I)
                                    tTrip_1I_Limit = (double)d.Value;
                                if (d.InspectionMinorKey == EInspectionMinor._1_2I)
                                    tTrip_1_2I_Limit = (double)d.Value;
                                if (d.InspectionMinorKey == EInspectionMinor._5I)
                                    tTrip_5I_Limit = (double)d.Value;
                            }
                        }
                        break;
                    case EInspectionMiddle.Status:
                        if (d.Value != null)
                        {
                            if (d.ValueType == EValueType.NONE)
                            {
                                if (d.Key.EndsWith("2"))
                                    status2 = (long)d.Value;
                                else
                                    status = (long)d.Value;
                            }
                        }
                        break;
                    default:
                        if (d.Value != null && d.Key.EndsWith("count"))
                            count = (double)d.Value;
                        break;
                }
            }

            this.AddReading(new RCD_TripCurrent_Pos(new Value(iTrip_Pos / 1000, "A"), new Value(iTrip_Limit / 1000, "A")));
            this.AddReading(new RCD_TripCurrent_Neg(new Value(iTrip_Neg / 1000, "A"), new Value(iTrip_Limit / 1000, "A")));
            this.AddReading(new RCD_TripTime_1_2I(new Value(tTrip_1_2I_Pos / 1000, "s"), new Value(tTrip_1_2I_Neg / 1000, "s"), new Value(tTrip_1_2I_Limit / 1000, "s")));
            this.AddReading(new RCD_TripTime_1I(new Value(tTrip_1I_Pos / 1000, "s"), new Value(tTrip_1I_Neg / 1000, "s"), new Value(tTrip_1I_Limit / 1000, "s")));
            this.AddReading(new RCD_TripTime_5I(new Value(tTrip_5I_Pos / 1000, "s"), new Value(tTrip_5I_Neg / 1000, "s"), new Value(tTrip_5I_Limit / 1000, "s")));
            this.AddReading(new RCD_ContactVoltage(new Value(uContact, "V"), new Value(uContact_Limit, "V")));
            this.AddReading(new RCD_TripButton(new Value(count, "")));
        }
    }
}