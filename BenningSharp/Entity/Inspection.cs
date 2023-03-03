using System.Data.SQLite;

namespace BenningSharp.Entity
{
    public struct Inspection
    {
        public readonly long ID = -1;
        public readonly string? Name = null;
        public readonly long? Procedure = null;
        public readonly long? ProtectionClass = null;
        public readonly int? Number = null;
        public readonly bool? @Fixed = null;
        public readonly long? LimitsID = null;
        public readonly bool? Individual = null;

        internal Inspection(SQLiteDataReader dr)
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
                        case "Pruefung_ID":
                            ID = (long)value;
                            break;
                        case "Pruefung_Name":
                            Name = (string)value;
                            break;
                        case "Pruefung_Ablauf":
                            Procedure = (long)value;
                            break;
                        case "Pruefung_SK":
                            ProtectionClass = (long)value;
                            break;
                        case "Pruefung_Nr":
                            Number = (int)value;
                            break;
                        case "Fest":
                            @Fixed = (bool)value;
                            break;
                        case "Grenzwerte_Index":
                            LimitsID = (long)value;
                            break;
                        case "Individuell":
                            Individual = (bool)value;
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
            return $"ID: {ID} Name: {Name} Procedure: {Procedure} ProtectionClass: {ProtectionClass} Number: {Number} Fixed: {@Fixed} LimitsID: {LimitsID} Individual: {Individual}";
        }
    }
}
