using BenningSharp;
using BenningSharp.Manager;

namespace BenningSharp_Tests
{
    public class Tests_For_Device
    {
        private static string DB_PATH = "C:\\Users\\Patrick\\Desktop\\LAV2022.db";
        private Database? database = null;
        [SetUp]
        public void Setup()
        {
            database = DatabaseManager.Instance.OpenOrGetDatabase(DB_PATH);
        }
        [Test]
        public async Task ID()
        {
            var device = database?.Devices.First()!;
            var backupID = device.ID;
            Assert.That(device.Dirty, Is.False);

            device.ID = "1000920";
            Assert.That(device.ID, Is.EqualTo("1000920"));
            Assert.That(device.Dirty, Is.True);

            await device.Save();
            Assert.That(device.Dirty, Is.False);

            device.ID = backupID;
            Assert.That(device.Dirty, Is.True);
            Assert.That(device.ID, Is.EqualTo(backupID));

            await device.Save();
            Assert.That(device.Dirty, Is.False);

            Assert.Pass();
        }
        [Test]
        public async Task Designation()
        {
            var device = database?.Devices.First()!;
            var backupDesignation = device.Designation;
            Assert.That(device.Dirty, Is.False);

            device.Designation = "MA-Lighting, grandMA3 FullSize 001";
            Assert.That(device.Designation, Is.EqualTo("MA-Lighting, grandMA3 FullSize 001"));
            Assert.That(device.Dirty, Is.True);

            await device.Save();
            Assert.That(device.Dirty, Is.False);

            device.Designation = backupDesignation;
            Assert.That(device.Dirty, Is.True);
            Assert.That(device.Designation, Is.EqualTo(backupDesignation));

            await device.Save();
            Assert.That(device.Dirty, Is.False);

            Assert.Pass();
        }
        [Test]
        public async Task SerialNumber()
        {
            var device = database?.Devices.First()!;
            var backupSerialNumber = device.SerialNumber;
            Assert.That(device.Dirty, Is.False);

            device.SerialNumber = "SN000222333";
            Assert.That(device.SerialNumber, Is.EqualTo("SN000222333"));
            Assert.That(device.Dirty, Is.True);

            await device.Save();
            Assert.That(device.Dirty, Is.False);

            device.SerialNumber = backupSerialNumber;
            Assert.That(device.Dirty, Is.True);
            Assert.That(device.SerialNumber, Is.EqualTo(backupSerialNumber));

            await device.Save();
            Assert.That(device.Dirty, Is.False);

            Assert.Pass();
        }
        [Test]
        public async Task Type()
        {
            var device = database?.Devices.First()!;
            var backupType = device.Type;
            Assert.That(device.Dirty, Is.False);

            device.Type = "grandMA3";
            Assert.That(device.Type, Is.EqualTo("grandMA3"));
            Assert.That(device.Dirty, Is.True);

            await device.Save();
            Assert.That(device.Dirty, Is.False);

            device.Type = backupType;
            Assert.That(device.Dirty, Is.True);
            Assert.That(device.Type, Is.EqualTo(backupType));

            await device.Save();
            Assert.That(device.Dirty, Is.False);

            Assert.Pass();
        }
        [Test]
        public async Task Modell()
        {
            var device = database?.Devices.First()!;
            var backupModell = device.Modell;
            Assert.That(device.Dirty, Is.False);

            device.Modell = "FullSize";
            Assert.That(device.Modell, Is.EqualTo("FullSize"));
            Assert.That(device.Dirty, Is.True);

            await device.Save();
            Assert.That(device.Dirty, Is.False);

            device.Modell = backupModell;
            Assert.That(device.Dirty, Is.True);
            Assert.That(device.Modell, Is.EqualTo(backupModell));

            await device.Save();
            Assert.That(device.Dirty, Is.False);

            Assert.Pass();
        }
        [Test]
        public async Task Manufacturer()
        {
            var device = database?.Devices.First()!;
            var backupManufacturer = device.Manufacturer;
            Assert.That(device.Dirty, Is.False);

            device.Manufacturer = "Yamaha";
            Assert.That(device.Manufacturer, Is.EqualTo("Yamaha"));
            Assert.That(device.Dirty, Is.True);

            await device.Save();
            Assert.That(device.Dirty, Is.False);

            device.Manufacturer = backupManufacturer;
            Assert.That(device.Dirty, Is.True);
            Assert.That(device.Manufacturer, Is.EqualTo(backupManufacturer));

            await device.Save();
            Assert.That(device.Dirty, Is.False);

            Assert.Pass();
        }
        [Test]
        public async Task Department()
        {
            var device = database?.Devices.First()!;
            var backupDepartment = device.Department;
            Assert.That(device.Dirty, Is.False);

            device.Department = "Light";
            Assert.That(device.Department, Is.EqualTo("Light"));
            Assert.That(device.Dirty, Is.True);

            await device.Save();
            Assert.That(device.Dirty, Is.False);

            device.Department = backupDepartment;
            Assert.That(device.Dirty, Is.True);
            Assert.That(device.Department, Is.EqualTo(backupDepartment));

            await device.Save();
            Assert.That(device.Dirty, Is.False);

            Assert.Pass();
        }
        [Test]
        public async Task Remark()
        {
            var device = database?.Devices.First()!;
            var backupRemark = device.Remark;
            Assert.That(device.Dirty, Is.False);

            device.Remark = "Test-Remark";
            Assert.That(device.Remark, Is.EqualTo("Test-Remark"));
            Assert.That(device.Dirty, Is.True);

            await device.Save();
            Assert.That(device.Dirty, Is.False);

            device.Remark = backupRemark;
            Assert.That(device.Dirty, Is.True);
            Assert.That(device.Remark, Is.EqualTo(backupRemark));

            await device.Save();
            Assert.That(device.Dirty, Is.False);

            Assert.Pass();
        }
        [Test]
        public async Task LineLength()
        {
            var device = database?.Devices.First()!;
            var backupLineLength = device.LineLength;
            Assert.That(device.Dirty, Is.False);

            device.LineLength = 2;
            Assert.That(device.LineLength, Is.EqualTo(2));
            Assert.That(device.Dirty, Is.True);

            await device.Save();
            Assert.That(device.Dirty, Is.False);

            device.LineLength = backupLineLength;
            Assert.That(device.Dirty, Is.True);
            Assert.That(device.LineLength, Is.EqualTo(backupLineLength));

            await device.Save();
            Assert.That(device.Dirty, Is.False);

            Assert.Pass();
        }
        [Test]
        public async Task OutputVoltage()
        {
            var device = database?.Devices.First()!;
            var backupOutputVoltage = device.OutputVoltage;
            Assert.That(device.Dirty, Is.False);

            device.OutputVoltage = 2;
            Assert.That(device.OutputVoltage, Is.EqualTo(2));
            Assert.That(device.Dirty, Is.True);

            await device.Save();
            Assert.That(device.Dirty, Is.False);

            device.OutputVoltage = backupOutputVoltage;
            Assert.That(device.Dirty, Is.True);
            Assert.That(device.OutputVoltage, Is.EqualTo(backupOutputVoltage));

            await device.Save();
            Assert.That(device.Dirty, Is.False);

            Assert.Pass();
        }
        [Test]
        public async Task ConductorCrossSection()
        {
            var device = database?.Devices.First()!;
            var backupConductorCrossSection = device.ConductorCrossSection;
            Assert.That(device.Dirty, Is.False);

            device.ConductorCrossSection = 2;
            Assert.That(device.ConductorCrossSection, Is.EqualTo(2));
            Assert.That(device.Dirty, Is.True);

            await device.Save();
            Assert.That(device.Dirty, Is.False);

            device.ConductorCrossSection = backupConductorCrossSection;
            Assert.That(device.Dirty, Is.True);
            Assert.That(device.ConductorCrossSection, Is.EqualTo(backupConductorCrossSection));

            await device.Save();
            Assert.That(device.Dirty, Is.False);

            Assert.Pass();
        }
        [Test]
        public async Task RatedPower()
        {
            var device = database?.Devices.First()!;
            var backupRatedPower = device.RatedPower;
            Assert.That(device.Dirty, Is.False);

            device.RatedPower = 2;
            Assert.That(device.RatedPower, Is.EqualTo(2));
            Assert.That(device.Dirty, Is.True);

            await device.Save();
            Assert.That(device.Dirty, Is.False);

            device.RatedPower = backupRatedPower;
            Assert.That(device.Dirty, Is.True);
            Assert.That(device.RatedPower, Is.EqualTo(backupRatedPower));

            await device.Save();
            Assert.That(device.Dirty, Is.False);

            Assert.Pass();
        }
        [Test]
        public async Task Class()
        {
            var device = database?.Devices.First()!;
            var backupClass = device.Class;
            Assert.That(device.Dirty, Is.False);

            device.Class = 1;
            Assert.That(device.Class, Is.EqualTo(1));
            Assert.That(device.Dirty, Is.True);

            await device.Save();
            Assert.That(device.Dirty, Is.False);

            device.Class = backupClass;
            Assert.That(device.Dirty, Is.True);
            Assert.That(device.Class, Is.EqualTo(backupClass));

            await device.Save();
            Assert.That(device.Dirty, Is.False);

            Assert.Pass();
        }
        [Test]
        public async Task NumberOfConductors()
        {
            var device = database?.Devices.First()!;
            var backupNumberOfConductors = device.NumberOfConductors;
            Assert.That(device.Dirty, Is.False);

            device.NumberOfConductors = 2;
            Assert.That(device.NumberOfConductors, Is.EqualTo(2));
            Assert.That(device.Dirty, Is.True);

            await device.Save();
            Assert.That(device.Dirty, Is.False);

            device.NumberOfConductors = backupNumberOfConductors;
            Assert.That(device.Dirty, Is.True);
            Assert.That(device.NumberOfConductors, Is.EqualTo(backupNumberOfConductors));

            await device.Save();
            Assert.That(device.Dirty, Is.False);

            Assert.Pass();
        }
        [Test]
        public async Task InspectionInterval()
        {
            var device = database?.Devices.First()!;
            var backupInspectionInterval = device.InspectionInterval;
            Assert.That(device.Dirty, Is.False);

            device.InspectionInterval = 4;
            Assert.That(device.InspectionInterval, Is.EqualTo(4));
            Assert.That(device.Dirty, Is.True);

            await device.Save();
            Assert.That(device.Dirty, Is.False);

            device.InspectionInterval = backupInspectionInterval;
            Assert.That(device.Dirty, Is.True);
            Assert.That(device.InspectionInterval, Is.EqualTo(backupInspectionInterval));

            await device.Save();
            Assert.That(device.Dirty, Is.False);

            Assert.Pass();
        }
        [Test]
        public async Task InspectionDate()
        {
            var device = database?.Devices.First()!;
            var backupInspectionDate = device.InspectionDate;
            Assert.That(device.Dirty, Is.False);

            var time= DateTime.UtcNow;
            device.InspectionDate = time;
            Assert.That(device.InspectionDate, Is.EqualTo(time));
            Assert.That(device.Dirty, Is.True);

            await device.Save();
            Assert.That(device.Dirty, Is.False);

            device.InspectionDate = backupInspectionDate;
            Assert.That(device.Dirty, Is.True);
            Assert.That(device.InspectionDate, Is.EqualTo(backupInspectionDate));

            await device.Save();
            Assert.That(device.Dirty, Is.False);

            Assert.Pass();
        }
        [Test]
        public async Task NextInspectionDate()
        {
            var device = database?.Devices.First()!;
            var backupNextInspectionDate = device.NextInspectionDate;
            Assert.That(device.Dirty, Is.False);

            var time = DateTime.UtcNow;
            device.NextInspectionDate = time;
            Assert.That(device.NextInspectionDate, Is.EqualTo(time));
            Assert.That(device.Dirty, Is.True);

            await device.Save();
            Assert.That(device.Dirty, Is.False);

            device.NextInspectionDate = backupNextInspectionDate;
            Assert.That(device.Dirty, Is.True);
            Assert.That(device.NextInspectionDate, Is.EqualTo(backupNextInspectionDate));

            await device.Save();
            Assert.That(device.Dirty, Is.False);

            Assert.Pass();
        }
    }
}