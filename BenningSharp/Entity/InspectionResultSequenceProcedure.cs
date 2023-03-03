using System.Data.SQLite;

namespace BenningSharp.Entity
{
    public struct InspectionResultSequenceProcedure
    {
        public readonly long ID = -1;
        public readonly long InspectionResultSequenceID = -1;
        public readonly string? Name = null;
        public readonly long? BitMask = null;
        public readonly long? BitMask2 = null;
        public readonly bool? Success = null;

        internal InspectionResultSequenceProcedure(SQLiteDataReader dr)
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
                        case "sequenceId":
                            InspectionResultSequenceID = (long)value;
                            break;
                        case "procName":
                            Name = (string)value;
                            break;
                        case "bitMask":
                            BitMask = (long)value;
                            break;
                        case "bitMask2":
                            BitMask2 = (long)value;
                            break;
                        case "success":
                            Success = (bool)value;
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
            return $"ID: {ID} InspectionResultSequenceID: {InspectionResultSequenceID} Name: {Name} BitMask: {BitMask} BitMask2: {BitMask2} Success: {Success}";
        }
    }
}
