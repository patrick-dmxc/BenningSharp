using System.Data.SQLite;

namespace BenningSharp.Entity
{
    public struct KeyValueData
    {
        public readonly string Key = null;
        public readonly object? Value = null;

        public readonly EInspectionMajor InspectionMajorKey = EInspectionMajor.UNKNOWN;
        public readonly EInspectionMiddle InspectionMiddleKey = EInspectionMiddle.UNKNOWN;
        public readonly EInspectionMinor InspectionMinorKey = EInspectionMinor.UNKNOWN;
        public readonly EValueType ValueType = EValueType.UNKNOWN;

        public KeyValueData(in string key, in object? value)
        {
            this.Key = key;
            this.Value = value;

            this.InspectionMajorKey = Tools.KeyToEInspectionMajor(key);
            this.InspectionMiddleKey = Tools.KeyToEInspectionMiddle(key);
            this.InspectionMinorKey = Tools.KeyToEInspectionMinor(key);
            this.ValueType = Tools.KeyToEValueType(key);
        }

        public override string ToString()
        {
            return $"Key: {Key} Value: {Value} InspectionKey: {InspectionMajorKey}_{InspectionMiddleKey}_{InspectionMinorKey}_{ValueType}";
        }
    }
}
