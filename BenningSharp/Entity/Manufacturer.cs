using System.Data.SQLite;

namespace BenningSharp.Entity
{
    public struct Manufacturer
    {
        public readonly long ID = -1;
        public readonly string? Name = null;

        public Manufacturer(in long id, in string? name)
        {
            this.ID = id;
            this.Name = name;
        }
        internal Manufacturer(SQLiteDataReader dr)
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
                        case "name":
                            Name = (string)value;
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
            return $"ID: {ID} Name: {Name}";
        }
    }
}
