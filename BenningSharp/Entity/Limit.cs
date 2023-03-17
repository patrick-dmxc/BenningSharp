using System.Data.SQLite;

namespace BenningSharp.Entity
{
    public readonly struct Limit
    {
        public readonly long ID = -1;
        public readonly string? Hash = null;

        public readonly ReadOnlyDictionary<string, KeyValueData> Data = null;

        public Limit(SQLiteDataReader dr)
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
                        case "Grenzwerte_Index":
                            ID = (long)value;
                            break;
                        case "Hash":
                            Hash = (string)value;
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
            return $"ID: {ID} Hash: {Hash}";
        }
    }
}
