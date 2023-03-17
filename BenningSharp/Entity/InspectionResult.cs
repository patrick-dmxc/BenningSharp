using System.Data.SQLite;

namespace BenningSharp.Entity
{
    public readonly struct InspectionResult
    {
        public readonly long ID = -1;
        public readonly long DeviceIndex = -1;
        public readonly int LimitsID = -1;
        public readonly DateTime Date = default;
        public readonly long Inspection = -1;
        public readonly string? InspectionName = null;
        public readonly long? InspectionOK = null;
        public readonly long? InspectionIndex = null;
        public readonly long? InspectionTested = null;

        public readonly string? OrderNumber = null;
        public readonly string? MeasuringDevice = null;
        public readonly string? ExaminerName = null;
        public readonly string? ExaminingCompany = null;
        public readonly int? AdditionalInspections = null;
        public readonly string? Location = null;
        public readonly string? Remark = null;
        public readonly string? SW_MeasuringInstrument = null;
        public readonly string? SW_GUI = null;
        public readonly string? SN_MeasuringInstrument = null;

        public readonly int? CountryCode = null;
        public readonly object? Image = null;

        public readonly ReadOnlyDictionary<string, KeyValueData> Data = null;

        public InspectionResult(SQLiteDataReader dr)
        {
            Dictionary<string, KeyValueData> data = new Dictionary<string, KeyValueData>();
            for (int i = 0; i < dr.FieldCount; i++)
            {
                try
                {
                    var columnName = dr.GetName(i);
                    var value = dr.GetValue(i);
                    if (value is DBNull)
                        continue;
                    switch (columnName)
                    {
                        case "Ergebnisse_Index":
                            ID = (long)value;
                            break;
                        case "Ergebnisse_Geraete_Index":
                            DeviceIndex = (long)value;
                            break;
                        case "Ergebnisse_Grenzwerte_Index":
                            LimitsID = (int)value;
                            break;
                        case "Ergebnisse_Datum":
                            Date = (DateTime)value;
                            break;
                        case "Ergebnisse_Pruefablauf":
                            Inspection = (long)value;
                            break;
                        case "Ergebnisse_Auftragsnummer":
                            OrderNumber = (string)value;
                            break;
                        case "Ergebnisse_Messgeraet":
                            MeasuringDevice = (string)value;
                            break;
                        case "Ergebnisse_Pruefername":
                            ExaminerName = (string)value;
                            break;
                        case "Ergebnisse_Prueffirma":
                            ExaminingCompany = (string)value;
                            break;
                        case "Ergebnisse_Zusatzpruefungen":
                            AdditionalInspections = (int)value;
                            break;
                        case "Ergebnisse_Ort":
                            Location = (string)value;
                            break;
                        case "Ergebnisse_Bemerkung":
                            Remark = (string)value;
                            break;

                        case "Ergebnisse_Pruefablauf_Name":
                            InspectionName = (string)value;
                            break;

                        case "Ergebnisse_Pruefablauf_Ok":
                            InspectionOK = (long)value;
                            break;

                        case "Ergebnisse_Softversion_Messgeraet":
                            SW_MeasuringInstrument = (string)value;
                            break;

                        case "Ergebnisse_Softversion_GUI":
                            SW_GUI = (string)value;
                            break;

                        case "Ergebnisse_Pruefablauf_Index":
                            InspectionIndex = (long)value;
                            break;

                        case "Ergebnisse_SN_Messgerae":
                            SN_MeasuringInstrument = (string)value;
                            break;

                        case "Ergebnisse_Pruefung":
                            break;

                        case "Ergebnisse_Pruefablauf_getestet":
                            InspectionTested = (long)value;
                            break;

                        case "Ergebnisse_Landeskenner":
                        case "Landeskenner":
                            CountryCode = (int)value;
                            break;

                        case "Ergebnisse_Bild":
                        case "Bild":
                            Image = value;
                            break;

                        case "Ergebnisse_Pruefablauf_2":
                        case "Ergebnisse_Pruefablauf_OK_2":
                        case "Ergebnisse_Pruefablauf_getestet_2":
                            break;

                        default:
                            KeyValueData kvd = new KeyValueData(columnName, value);
                            if (kvd.InspectionMinorKey == EInspectionMinor.RESERVE)
                                break;
                            data.Add(columnName, kvd);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                Data = new ReadOnlyDictionary<string, KeyValueData>(data);
            }
        }

        public override string ToString()
        {

            return $"ID: {ID} Date: {Date} DeviceID: {DeviceIndex} LimitsID: {LimitsID} InspectionID: {Inspection} OrderNumber: {OrderNumber} MeasuringDevice: {MeasuringDevice} ExaminerName: {ExaminerName} ExaminingCompany: {ExaminingCompany} AdditionalInspections: {AdditionalInspections} Location: {Location} Remark: {Remark}";
        }
    }
}