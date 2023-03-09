using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using DeviceEntity = BenningSharp.Entity.Device;

namespace BenningSharp.Objects
{
    public class Device
    {
        private readonly Database Database;
        private readonly DeviceEntity Entity;

        public readonly long Index;

        private readonly ConcurrentBag<string> dirtyPropertys= new ConcurrentBag<string>();
        public bool Dirty { get { return !this.dirtyPropertys.IsEmpty; } }
        private void setDirty([CallerMemberName] string? caller=null)
        {
            if (caller != null)
                dirtyPropertys.Add(caller);
        }

        #region Propertys
        private string? id = null;
        public string ID
        {
            get
            {

                return id ?? Entity.ID ?? string.Empty;
            }
            set
            {
                if (string.Equals(this.id, value))
                    return;

                this.id = value;
                this.dirtyPropertys.Add(nameof(ID));
            }
        }

        private string? designation = null;
        public string Designation
        {
            get
            {
                return this.designation ?? this.Entity.Designation ?? string.Empty;
            }
            set
            {
                if (string.Equals(this.designation, value))
                    return;

                this.designation = value;
                this.setDirty();
            }
        }

        private string? remark = null;
        public string Remark
        {
            get
            {
                return this.remark ?? this.Entity.Remark ?? string.Empty;
            }
            set
            {
                if (string.Equals(this.remark, value))
                    return;

                this.remark = value;
                this.setDirty();
            }
        }

        private string? serialNumber = null;
        public string SerialNumber
        {
            get
            {
                return this.serialNumber ?? this.Entity.SerialNumber ?? string.Empty;
            }
            set
            {
                if (string.Equals(this.serialNumber, value))
                    return;

                this.serialNumber = value;
                this.setDirty();
            }
        }

        private string? type = null;
        public string Type
        {
            get
            {
                return this.type ?? this.Entity.Type ?? string.Empty;
            }
            set
            {
                if (string.Equals(this.type, value))
                    return;

                this.type = value;
                this.setDirty();
            }
        }

        private string? modell = null;
        public string Modell
        {
            get
            {
                return this.modell ?? this.Entity.Modell ?? string.Empty;
            }
            set
            {
                if (string.Equals(this.modell, value))
                    return;

                this.modell = value;
                this.setDirty();
            }
        }

        private string? manufacturer = null;
        public string Manufacturer
        {
            get
            {
                return this.manufacturer ?? this.Entity.Manufacturer ?? string.Empty;
            }
            set
            {
                if (string.Equals(this.manufacturer, value))
                    return;

                this.manufacturer = value;
                this.setDirty();
            }
        }

        private string? department = null;
        public string Department
        {
            get
            {
                return this.department ?? this.Entity.Department ?? string.Empty;
            }
            set
            {
                if (string.Equals(this.department, value))
                    return;

                this.department = value;
                this.setDirty();
            }
        }

        private double? lineLength = null;
        public double LineLength
        {
            get
            {
                return this.lineLength ?? Entity.LineLength;
            }
            set
            {
                if (double.Equals(this.lineLength, value))
                    return;

                this.lineLength = value;
                this.setDirty();
            }
        }

        private double? conductorCrossSection = null;
        public double ConductorCrossSection
        {
            get
            {
                return this.conductorCrossSection ?? this.Entity.ConductorCrossSection;
            }
            set
            {
                if (double.Equals(this.conductorCrossSection, value))
                    return;

                this.conductorCrossSection = value;
                this.setDirty();
            }
        }

        private double? ratedPower = null;
        public double RatedPower
        {
            get
            {
                return this.ratedPower ?? this.Entity.RatedPower ?? 0;
            }
            set
            {
                if (double.Equals(this.ratedPower, value))
                    return;

                this.ratedPower = value;
                this.setDirty();
            }
        }

        private int? inspectionInterval = null;
        public int InspectionInterval
        {
            get
            {
                return this.inspectionInterval ?? this.Entity.InspectionInterval ?? 12;
            }
            set
            {
                if (double.Equals(this.inspectionInterval, value))
                    return;

                this.inspectionInterval = value;
                this.setDirty();
            }
        }

        private DateTime? inspectionDate = null;
        public DateTime InspectionDate
        {
            get
            {
                return this.inspectionDate ?? this.Entity.InspectionDate ?? default;
            }
            set
            {
                if (double.Equals(this.inspectionDate, value))
                    return;

                this.inspectionDate = value;
                this.setDirty();
            }
        }

        private DateTime? nextInspectionDate = null;
        public DateTime NextInspectionDate
        {
            get
            {
                return this.nextInspectionDate ?? this.Entity.NextInspectionDate ?? default;
            }
            set
            {
                if (double.Equals(this.nextInspectionDate, value))
                    return;

                this.nextInspectionDate = value;
                this.setDirty();
            }
        }

        public DateTime ChangeDate
        {
            get;
            private set;
        }
        #endregion

        private List<InspectionResult> inspectionResults = new List<InspectionResult>();
        public IReadOnlyCollection<InspectionResult> InspectionResults
        {
            get
            {
                return inspectionResults.AsReadOnly();
            }
        }

        public Device(Database database, DeviceEntity entity) 
        {
            this.Database = database;
            this.Entity = entity;
            this.Index = entity.Index;
            this.ChangeDate = entity.ChangeDate ?? default;
        }
        internal void initialize()
        {
            this.inspectionResults = this.Database.InspectionResults.Where(ir => ir.DeviceIndex == this.Index).ToList();
            this.inspectionResults.ForEach(ir =>
            {
                string str = ir.ToString();
            });
        }
        public async Task Save()
        {
            if (!this.Dirty)
                return;

            while(!this.dirtyPropertys.IsEmpty)
            {
                string? propertyName = null;
                this.dirtyPropertys.TryTake(out propertyName);

                switch (propertyName)
                {
                    case nameof(this.ID):
                        await this.Database.SetValue(Database.TABLE_DEVICES, DeviceEntity.COLUMN_ID, DeviceEntity.COLUMN_INDEX, this.Index, this.ID);
                        break;
                    case nameof(this.Designation):
                        await this.Database.SetValue(Database.TABLE_DEVICES, DeviceEntity.COLUMN_DESIGNATION, DeviceEntity.COLUMN_INDEX, this.Index, this.Designation);
                        break;
                    case nameof(this.Remark):
                        await this.Database.SetValue(Database.TABLE_DEVICES, DeviceEntity.COLUMN_REMARK, DeviceEntity.COLUMN_INDEX, this.Index, this.Remark);
                        break;
                    case nameof(this.SerialNumber):
                        await this.Database.SetValue(Database.TABLE_DEVICES, DeviceEntity.COLUMN_SERIAL_NUMBER, DeviceEntity.COLUMN_INDEX, this.Index, this.SerialNumber);
                        break;
                    case nameof(this.Type):
                        await this.Database.SetValue(Database.TABLE_DEVICES, DeviceEntity.COLUMN_TYPE, DeviceEntity.COLUMN_INDEX, this.Index, this.Type);
                        break;
                    case nameof(this.Modell):
                        await this.Database.SetValue(Database.TABLE_DEVICES, DeviceEntity.COLUMN_MODELL, DeviceEntity.COLUMN_INDEX, this.Index, this.Modell);
                        break;
                    case nameof(this.LineLength):
                        await this.Database.SetValue(Database.TABLE_DEVICES, DeviceEntity.COLUMN_LINE_LENGTH, DeviceEntity.COLUMN_INDEX, this.Index, this.LineLength);
                        break;
                    case nameof(this.ConductorCrossSection):
                        await this.Database.SetValue(Database.TABLE_DEVICES, DeviceEntity.COLUMN_CONDUCTOR_CROSS_SECTION, DeviceEntity.COLUMN_INDEX, this.Index, this.ConductorCrossSection);
                        break;
                    case nameof(this.RatedPower):
                        await this.Database.SetValue(Database.TABLE_DEVICES, DeviceEntity.COLUMN_RATED_POWER, DeviceEntity.COLUMN_INDEX, this.Index, this.RatedPower);
                        break;
                    case nameof(this.InspectionInterval):
                        await this.Database.SetValue(Database.TABLE_DEVICES, DeviceEntity.COLUMN_INSPECTION_INTERVAL, DeviceEntity.COLUMN_INDEX, this.Index, this.InspectionInterval);
                        break;
                    case nameof(this.InspectionDate):
                        await this.Database.SetValue(Database.TABLE_DEVICES, DeviceEntity.COLUMN_INSPECTION_DATE, DeviceEntity.COLUMN_INDEX, this.Index, this.InspectionDate);
                        break;
                    case nameof(this.NextInspectionDate):
                        await this.Database.SetValue(Database.TABLE_DEVICES, DeviceEntity.COLUMN_NEXT_INSPECTION_DATE, DeviceEntity.COLUMN_INDEX, this.Index, this.NextInspectionDate);
                        break;
                }
            }
            this.ChangeDate = DateTime.Now;
            await this.Database.SetValue(Database.TABLE_DEVICES, DeviceEntity.COLUMN_CHANGE_DATE, DeviceEntity.COLUMN_INDEX, this.Index, this.ChangeDate);
        }

        public override string ToString()
        {
            return $"ID: {ID} Name: {Designation} SerialNumber: {SerialNumber}";
        }
    }
}