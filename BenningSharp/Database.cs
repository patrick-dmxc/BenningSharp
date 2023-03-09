using System.Data.SQLite;

namespace BenningSharp
{
    public class Database
    {
        public const string TABLE_LIMITS = "Grenzwerte";
        public const string TABLE_CUSTOMER = "Kunden";
        public const string TABLE_DEPARTMENTS = "Departments";
        public const string TABLE_DEVICES = "Geraete";
        public const string TABLE_INSPECTIONS = "Pruefung";
        public const string TABLE_MANUFACTURERS = "Manufacturers";
        public const string TABLE_INSPECTION_RESULTS = "Ergebnisse";
        public const string TABLE_INSPECTION_RESULT_SEQUENCES = "Sequences";
        public const string TABLE_INSPECTION_RESULT_SEQUENCE_PROCEDURES = "SqProcedures";
        public const string TABLE_INSPECTION_RESULT_SEQUENCE_PROCEDURE_VALUES = "SqProcValues";
        public const string TABLE_INSPECTION_QUESTIONS = "ViewQuestions";
        public const string TABLE_INSPECTION_ANSWERS_ADMIN = "TestResult2Admin2Answers";
        public const string TABLE_INSPECTION_ANSWERS_Customer = "TestResult2Customer2Answers";
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
            limitEntities = await ReadDataAsync<Entity.Limit>($"SELECT * FROM {TABLE_LIMITS}");
            customeEntities = await ReadDataAsync<Entity.Customer>($"SELECT * FROM {TABLE_CUSTOMER}");
            departmentEntities = await ReadDataAsync<Entity.Department>($"SELECT * FROM {TABLE_DEPARTMENTS}");
            deviceEntities = await ReadDataAsync<Entity.Device>($"SELECT * FROM {TABLE_DEVICES}");
            inspectionEntities = await ReadDataAsync<Entity.Inspection>($"SELECT * FROM {TABLE_INSPECTIONS}");
            manufacturerEntities = await ReadDataAsync<Entity.Manufacturer>($"SELECT * FROM {TABLE_MANUFACTURERS}");
            inspectionResultEntities = await ReadDataAsync<Entity.InspectionResult>($"SELECT * FROM {TABLE_INSPECTION_RESULTS}");
            inspectionResultSequenceEntities = await ReadDataAsync<Entity.InspectionResultSequence>($"SELECT * FROM {TABLE_INSPECTION_RESULT_SEQUENCES}");
            inspectionResultSequenceProcedureEntities = await ReadDataAsync<Entity.InspectionResultSequenceProcedure>($"SELECT * FROM {TABLE_INSPECTION_RESULT_SEQUENCE_PROCEDURE_VALUES}");
            inspectionResultSequenceProcedureValueEntities = await ReadDataAsync<Entity.InspectionResultSequenceProcedureValue>($"SELECT * FROM {TABLE_INSPECTION_RESULT_SEQUENCE_PROCEDURE_VALUES}");
            visualInspectionQuestionEntities = await ReadDataAsync<Entity.VisualInspectionQuestion>($"SELECT * FROM {TABLE_INSPECTION_QUESTIONS}");
            visualInspectionAnswerEntities = (await ReadDataAsync<Entity.VisualInspectionAnswer>($"SELECT * FROM {TABLE_INSPECTION_ANSWERS_ADMIN}")).Concat(await ReadDataAsync<Entity.VisualInspectionAnswer>($"SELECT * FROM {TABLE_INSPECTION_ANSWERS_Customer}"));
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

        internal async Task<bool> SetValue<T>(string table, string column,string indexColumn,long index ,T value)
        {
            try
            {
                SQLiteCommand sqlite_cmd;
                sqlite_cmd = sqlite_conn.CreateCommand();
                if (value is string)
                    sqlite_cmd.CommandText = $"UPDATE {table} SET {column} = @value WHERE {indexColumn} = @index;";
                else
                    sqlite_cmd.CommandText = $"UPDATE {table} SET {column} = @value WHERE {indexColumn} = @index;";

                sqlite_cmd.Parameters.AddWithValue("@value", value);
                sqlite_cmd.Parameters.AddWithValue("@index", index);

                int count = await sqlite_cmd.ExecuteNonQueryAsync();
                if (count == 1)
                    return true;
            }
            catch(Exception e)
            {

            }
            return false;
        }
    }
}