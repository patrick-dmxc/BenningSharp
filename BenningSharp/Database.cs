using System.Collections.ObjectModel;
using System.Data.SQLite;

namespace BenningSharp
{
    public class Database
    {
        public bool IsInitialized { get; private set; }
        public readonly string? Path = null;
        private SQLiteConnection? sqlite_conn;
        private IEnumerable<Entity.Limit>? limitEntities;
        private IEnumerable<Entity.Customer>? customeEntities;
        private IEnumerable<Entity.Department>? departmentEntities;
        private IEnumerable<Entity.Device>? deviceEntities;
        private IEnumerable<Entity.Inspection>? inspectionEntities;
        private IEnumerable<Entity.Manufacturer>? manufacturerEntities;
        private IEnumerable<Entity.InspectionResult>? inspectionResultEntities;
        private IEnumerable<Entity.InspectionResultSequence>? inspectionResultSequenceEntities;
        private IEnumerable<Entity.InspectionResultSequenceProcedure>? inspectionResultSequenceProcedureEntities;
        private IEnumerable<Entity.InspectionResultSequenceProcedureValue>? inspectionResultSequenceProcedureValueEntities;
        private IEnumerable<Entity.VisualInspectionQuestion>? visualInspectionQuestionEntities;
        private IEnumerable<Entity.VisualInspectionAnswer>? visualInspectionAnswerEntities;


        private List<Objects.Device> devices = new List<Objects.Device>();
        private List<Objects.InspectionResult> inspectionResults = new List<Objects.InspectionResult>();
        public IReadOnlyCollection<Objects.Device> Devices
        {
            get
            {
                return devices.AsReadOnly();
            }
        }
        public IReadOnlyCollection<Objects.InspectionResult> InspectionResults
        {
            get
            {
                return inspectionResults.AsReadOnly();
            }
        }

        public Database(string path)
        {
            this.Path = path;
            _ = this.initialize();
        }
        private async Task initialize()
        {
            if (this.Path != null)
                sqlite_conn = await CreateConnection(this.Path);

            await LoadDatabase();
            GenerateObjects();

            this.IsInitialized = true;
        }
        private async Task<SQLiteConnection?> CreateConnection(string path)
        {

            SQLiteConnection? sqlite_conn = null;
            // Create a new database connection:
            sqlite_conn = new SQLiteConnection($"DataSource={path}", true);
            // Open the connection:
            try
            {
                await sqlite_conn.OpenAsync();
            }
            catch (Exception ex)
            {

            }
            return sqlite_conn;
        }

        private async Task<IEnumerable<T>> ReadDataAsync<T>(string command)
        {
            if (sqlite_conn == null)
                throw new NullReferenceException();

            SQLiteCommand sqlite_cmd;
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = command;
            var dr = await sqlite_cmd.ExecuteReaderAsync();

            List<T> list = new List<T>();
            while (await dr.ReadAsync())
            {
                try
                {
                    T data = (T)Activator.CreateInstance(typeof(T), dr)!;
                    list.Add(data);
                }
                catch (Exception e)
                {

                }
            }
            dr.Close();
            return list;
        }

        private async Task LoadDatabase()
        {
            limitEntities = await ReadDataAsync<Entity.Limit>("SELECT * FROM Grenzwerte");
            customeEntities = await ReadDataAsync<Entity.Customer>("SELECT * FROM Kunden");
            departmentEntities = await ReadDataAsync<Entity.Department>("SELECT * FROM Departments");
            deviceEntities = await ReadDataAsync<Entity.Device>("SELECT * FROM Geraete");
            inspectionEntities = await ReadDataAsync<Entity.Inspection>("SELECT * FROM Pruefung");
            manufacturerEntities = await ReadDataAsync<Entity.Manufacturer>("SELECT * FROM Manufacturers");
            inspectionResultEntities = await ReadDataAsync<Entity.InspectionResult>("SELECT * FROM Ergebnisse");
            inspectionResultSequenceEntities = await ReadDataAsync<Entity.InspectionResultSequence>("SELECT * FROM Sequences");
            inspectionResultSequenceProcedureEntities = await ReadDataAsync<Entity.InspectionResultSequenceProcedure>("SELECT * FROM SqProcedures");
            inspectionResultSequenceProcedureValueEntities = await ReadDataAsync<Entity.InspectionResultSequenceProcedureValue>("SELECT * FROM SqProcValues");
            visualInspectionQuestionEntities = await ReadDataAsync<Entity.VisualInspectionQuestion>("SELECT * FROM ViewQuestions");
            visualInspectionAnswerEntities = await ReadDataAsync<Entity.VisualInspectionAnswer>("SELECT * FROM TestResult2Admin2Answers");
        }
        private void GenerateObjects()
        {
            if (inspectionResultEntities == null)
                throw new NullReferenceException();
            if (deviceEntities == null)
                throw new NullReferenceException();

            foreach (var ir in inspectionResultEntities)
                inspectionResults.Add(new Objects.InspectionResult(this, ir));

            foreach (var d in deviceEntities)
                devices.Add(new Objects.Device(this, d));

            inspectionResults.ForEach(ir => ir.initialize());
            devices.ForEach(d => d.initialize());
        }
    }
}