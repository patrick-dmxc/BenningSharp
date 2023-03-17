using System.Data.SQLite;

namespace BenningSharp.Entity
{
    public readonly struct VisualInspectionAnswer
    {
        public readonly long? InspectionResultID = null;
        public readonly long? QuestionID = null;
        public readonly long? AnswerID = null;

        public VisualInspectionAnswer(in long? inspectionResultID, in long? questionID, in long? answerId)
        {
            this.InspectionResultID = inspectionResultID;
            this.QuestionID = questionID;
            this.AnswerID = answerId;
        }
        public VisualInspectionAnswer(SQLiteDataReader dr)
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
                        case "testResultId":
                            InspectionResultID = (long)value;
                            break;
                        case "questionId":
                            QuestionID = (long)value;
                            break;
                        case "answerId":
                            AnswerID = (long)value;
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
            return $"InspectionResultID: {InspectionResultID} QuestionID: {QuestionID} IsDeleted: {AnswerID}";
        }
    }
}