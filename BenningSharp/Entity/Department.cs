using System.Data.SQLite;

namespace BenningSharp.Entity
{
    public readonly struct Department
    {
        public readonly long ID = -1;
        public readonly long? ParentID = null;
        public readonly long? CustomerID = null;
        public readonly string? Name = null;

        public Department(in long id, in long? parentID, in long? customerID, in string? name)
        {
            this.ID = id;
            this.ParentID = parentID;
            this.CustomerID = customerID;
            this.Name = name;
        }
        public Department(SQLiteDataReader dr)
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
                        case "parentId":
                            ParentID = (long)value;
                            break;
                        case "customerId":
                            CustomerID = (long)value;
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
