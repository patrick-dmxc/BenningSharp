using System.Collections.ObjectModel;

namespace BenningSharp.Objects
{
    public class Device
    {
        private readonly Database Database;
        private readonly Entity.Device Entity;

        public readonly string ID;
        public readonly long Index;
        public string Name { get { return Entity.Designation; } }
        public string SerialNumber { get { return Entity.SerialNumber ?? string.Empty; } }

        private List<InspectionResult> inspectionResults;
        public IReadOnlyCollection<InspectionResult> InspectionResults
        {
            get
            {
                return inspectionResults.AsReadOnly();
            }
        }

        public Device(Database database, Entity.Device entity) 
        {
            this.Database = database;
            this.Entity = entity;
            this.ID = entity.ID;
            this.Index = entity.Index;
        }
        internal void initialize()
        {
            this.inspectionResults = this.Database.InspectionResults.Where(ir => ir.DeviceIndex == this.Index).ToList();
            this.inspectionResults.ForEach(ir =>
            {
                string str = ir.ToString();
            });
        }

        public override string ToString()
        {
            return $"ID: {ID} Name: {Name} SerialNumber: {SerialNumber}";
        }
    }
}