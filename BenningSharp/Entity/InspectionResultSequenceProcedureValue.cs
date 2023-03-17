using System.Data.SQLite;

namespace BenningSharp.Entity
{
    public readonly struct InspectionResultSequenceProcedureValue
    {
        public readonly long ID = -1;
        public readonly long InspectionResultSequenceProcedureID = -1;
        public readonly string? Name = null;
        public readonly string? ValueString = null;
        public readonly bool? IsValid = null;
        public readonly double? Value = null;

        public InspectionResultSequenceProcedureValue(SQLiteDataReader dr)
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
                        case "sqProcId":
                            InspectionResultSequenceProcedureID = (long)value;
                            break;
                        case "ident":
                            Name = (string)value;
                            break;
                        case "valueStr":
                            ValueString = (string)value;
                            break;
                        case "isValid":
                            IsValid = (bool)value;
                            break;
                        case "value":
                            Value = (double)value;
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
            return $"ID: {ID} InspectionResultSequenceProcedureID: {InspectionResultSequenceProcedureID} Name: {Name} ValueString: {ValueString} IsValid: {IsValid} Value: {Value}";
        }
    }
}