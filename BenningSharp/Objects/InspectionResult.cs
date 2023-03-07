using System.Xml.Linq;

namespace BenningSharp.Objects
{
    public class InspectionResult
    {
        private readonly Database Database;
        private readonly Entity.InspectionResult Entity;

        public readonly long ID;
        public readonly long DeviceIndex;

        public DateTime Date
        {
            get
            {
                return this.Entity.Date;
            }
        }

        private Device? device;
        public Device Device
        {
            get
            {
                if(device==null)
                    device= this.Database.Devices.FirstOrDefault(d=>d.Index== this.DeviceIndex);

                return device!;
            }
        }

        public InspectionResult(Database database, Entity.InspectionResult entity) 
        {
            this.Database = database;
            this.Entity = entity;
            this.ID = entity.ID;
            this.DeviceIndex = entity.DeviceIndex;
        }
        internal void initialize()
        {
        }

        public override string ToString()
        {
            return $"ID: {ID} Date: {Date} Device ID: {Device.ID} Device SN: {Device.SerialNumber} Device Name: {Device.Name}";
        }
    }
}