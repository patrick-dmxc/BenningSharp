﻿using BenningSharp.Entity;
using BenningSharp.Manager;
using BenningSharp.Objects.Inspections;
using BenningSharp.Objects.Inspections.Reading;

namespace BenningSharp.Objects
{
    public class InspectionResult
    {
        private readonly Database Database;
        private readonly Entity.InspectionResult Entity;

        private List<IInspection> inspections= new List<IInspection>();
        public IReadOnlyCollection<IInspection> Inspections
        {
            get
            {
                return inspections.AsReadOnly();
            }
        }
        public IReadOnlyCollection<IReading>? Readings
        {
            get
            {
                try
                {
                    return inspections.SelectMany(i => i.Readings).ToList().AsReadOnly();
                }
                catch(Exception e)
                {

                }
                return null;
            }
        }

        public readonly long ID;
        public readonly long DeviceIndex;

        public DateTime Date
        {
            get
            {
                return this.Entity.Date;
            }
        }
        public string? ExaminerName
        {
            get
            {
                return this.Entity.ExaminerName;
            }
        }
        public string? MeasuringDevice
        {
            get
            {
                return this.Entity.MeasuringDevice;
            }
        }
        public string? Remark
        {
            get
            {
                return this.Entity.Remark;
            }
        }
        public string? SN_MeasuringInstrument
        {
            get
            {
                return this.Entity.SN_MeasuringInstrument;
            }
        }
        public string? SW_MeasuringInstrument
        {
            get
            {
                return this.Entity.SW_MeasuringInstrument;
            }
        }
        public string? SW_GUI
        {
            get
            {
                return this.Entity.SW_GUI;
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

        public IReadOnlyDictionary<string, KeyValueData> Data
        {
            get
            {
                return this.Entity.Data;
            }
        }

        public bool Passed
        {
            get
            {
                return this.inspections.All(i=>i.Passed);
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
            var allInspectionTemplates = InspectionsManager.Instance.Inspections;
            foreach (var template in allInspectionTemplates)
            {
                if (this.Data.Any(d => d.Value.InspectionMajorKey == template.Type))
                {
                    IInspection? instance = Activator.CreateInstance(template.GetType(), this) as IInspection;
                    if(instance!=null)
                        this.inspections.Add(instance);
                }
            }
        }

        public override string ToString()
        {
            return $"ID: {ID} Date: {Date} Device ID: {Device.ID} Device SN: {Device.SerialNumber} Device Name: {Device.Designation}";
        }
    }
}