using System.Data.SQLite;

namespace BenningSharp.Entity
{
    public struct VisualInspectionQuestion
    {
        public readonly long ID = -1;
        public readonly string? Question = null;
        public readonly long? ViewLevel = null;
        public readonly bool? IsDeleted = null;

        public VisualInspectionQuestion(in long id, in string? question, in long? viewLevel, in bool? isDeleted)
        {
            this.ID = id;
            this.Question = question;
            this.ViewLevel = viewLevel;
            this.IsDeleted = isDeleted;
        }
        internal VisualInspectionQuestion(SQLiteDataReader dr)
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
                        case "Question":
                            Question = (string)value;
                            break;
                        case "ViewLevel":
                            ViewLevel = (long)value;
                            break;
                        case "IsDeleted":
                            IsDeleted = (bool)value;
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
            return $"ID: {ID} Question: {Question} ViewLevel: {ViewLevel} IsDeleted: {IsDeleted}";
        }
    }
}
