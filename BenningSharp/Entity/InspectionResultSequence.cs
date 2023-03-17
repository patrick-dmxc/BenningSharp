using System.Data.SQLite;

namespace BenningSharp.Entity
{
    public readonly struct InspectionResultSequence
    {
        public readonly long ID = -1;
        public readonly int? DeviceID = null;
        public readonly int? TypeID = null;
        public readonly int? TestResultID = null;
        public readonly DateTime? StartDate = null;
        public readonly string? Remark = null;
        public readonly bool? Passed = null;
        public readonly bool? PassedVisualInspection = null;

        public InspectionResultSequence(SQLiteDataReader dr)
        {
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
                        case "id":
                            ID = (long)value;
                            break;
                        case "deviceId":
                            DeviceID = (int)value;
                            break;
                        case "typeId":
                            TypeID = (int)value;
                            break;
                        case "testResultId":
                            TypeID = (int)value;
                            break;
                        case "startDate":
                            StartDate = (DateTime)value;
                            break;
                        case "remark":
                            Remark = (string)value;
                            break;
                        case "success":
                            Passed = (bool)value;
                            break;
                        case "viewTestOk":
                            PassedVisualInspection = (bool)value;
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }

        public override string ToString()
        {
            return $"ID: {ID} DeviceID: {DeviceID} TypeID: {TypeID} StartDate: {StartDate} Remark: {Remark} PassedVisualInspection: {PassedVisualInspection}";
        }
    }
}