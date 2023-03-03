using BenningSharp.Entity;
using System.Data;
using System.Data.SQLite;

namespace BenningSharp
{
    public class Database
    {
        private const string PATH = "C:\\Users\\Patrick\\Desktop\\LAV2022.db";
        private SQLiteConnection? sqlite_conn;
        public Database()
        {
            _ = this.initialize();
        }
        private async Task initialize()
        {
            string path = PATH;
            sqlite_conn = await CreateConnection(path);

            //Console.WriteLine();
            //Console.WriteLine(nameof(ReadLimits));
            //var Limits = await ReadLimits();
            //foreach (var Limit in Limits)
            //    foreach (var kv in Limit.Data)
            //        Console.WriteLine(kv.Value);

            //Console.WriteLine();
            //Console.WriteLine(nameof(ReadCustomers));
            //var customers = await ReadCustomers();
            //foreach (var customer in customers)
            //    Console.WriteLine(customer);

            Console.WriteLine();
            Console.WriteLine(nameof(ReadDevices));
            var Devices = await ReadDevices();
            foreach (var Device in Devices)
                Console.WriteLine(Device);

            //Console.WriteLine();
            //Console.WriteLine(nameof(ReadInspections));
            //var inspections = await ReadInspections();
            //foreach (var inspection in inspections)
            //    Console.WriteLine(inspection);

            //Console.WriteLine();
            //Console.WriteLine(nameof(ReadInspectionResults));
            //var InspectionResults = await ReadInspectionResults();
            //foreach (var InspectionResult in InspectionResults)
            //    foreach (var kv in InspectionResult.Data.Where(d=>d.Value.InspectionMiddleKey== EInspectionMiddle.Conductor))
            //        Console.WriteLine(kv.Value);

            //Console.WriteLine();
            //Console.WriteLine(nameof(ReadInspectionResultSequences));
            //var InspectionResultSequences = await ReadInspectionResultSequences();
            //foreach (var InspectionResultSequence in InspectionResultSequences)
            //    Console.WriteLine(InspectionResultSequence);

            //Console.WriteLine();
            //Console.WriteLine(nameof(ReadInspectionResultSequenceProcedures));
            //var InspectionResultSequenceProcedures = await ReadInspectionResultSequenceProcedures();
            //foreach (var InspectionResultSequenceProcedure in InspectionResultSequenceProcedures)
            //    Console.WriteLine(InspectionResultSequenceProcedure);

            //Console.WriteLine();
            //Console.WriteLine(nameof(ReadInspectionResultSequenceProcedureValues));
            //var InspectionResultSequenceProcedurevalues = await ReadInspectionResultSequenceProcedureValues();
            //foreach (var InspectionResultSequenceProcedureValue in InspectionResultSequenceProcedurevalues)
            //    Console.WriteLine(InspectionResultSequenceProcedureValue);

            //Console.WriteLine();
            //Console.WriteLine(nameof(ReadManufacturers));
            //var manufacturers = await ReadManufacturers();
            //foreach (var manufacturer in manufacturers)
            //    Console.WriteLine(manufacturer);

            //Console.WriteLine();
            //Console.WriteLine(nameof(ReadVisualInspectionQuestions));
            //var visualInspectionQuestions = await ReadVisualInspectionQuestions();
            //foreach (var visualInspectionQuestion in visualInspectionQuestions)
            //    Console.WriteLine(visualInspectionQuestion);

            //Console.WriteLine();
            //Console.WriteLine(nameof(ReadVisualInspectionAnswers));
            //var visualInspectionAnswers = await ReadVisualInspectionAnswers();
            //foreach (var visualInspectionAnswer in visualInspectionAnswers)
            //    Console.WriteLine(visualInspectionAnswer);
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

        private async Task<Limit[]> ReadLimits()
        {
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM Grenzwerte";
            var dr = sqlite_cmd.ExecuteReader();

            List<Limit> limits = new List<Limit>();
            while (dr.Read())
                limits.Add(new Limit(dr));
            dr.Close();
            return limits.ToArray();
        }
        private async Task<Customer[]> ReadCustomers()
        {
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM Kunden";
            var dr = sqlite_cmd.ExecuteReader();

            List<Customer> customers = new List<Customer>();
            while (dr.Read())
                customers.Add(new Customer(dr));
            dr.Close();
            return customers.ToArray();
        }
        private async Task<Device[]> ReadDevices()
        {
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM Geraete";
            var dr = sqlite_cmd.ExecuteReader();

            List<Device> customers = new List<Device>();
            while (dr.Read())
                customers.Add(new Device(dr));
            dr.Close();
            return customers.ToArray();
        }
        private async Task<Inspection[]> ReadInspections()
        {
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM Pruefung";
            var dr = sqlite_cmd.ExecuteReader();

            List<Inspection> inspections = new List<Inspection>();
            while (dr.Read())
                inspections.Add(new Inspection(dr));
            dr.Close();
            return inspections.ToArray();
        }
        private async Task<Manufacturer[]> ReadManufacturers()
        {
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM Manufacturers";
            var dr = sqlite_cmd.ExecuteReader();

            List<Manufacturer> manufacturers = new List<Manufacturer>();
            while (dr.Read())
                manufacturers.Add(new Manufacturer(dr));
            dr.Close();
            return manufacturers.ToArray();
        }
        private async Task<InspectionResult[]> ReadInspectionResults()
        {
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM Ergebnisse";
            var dr = sqlite_cmd.ExecuteReader();

            List<InspectionResult> InspectionResults = new List<InspectionResult>();
            while (dr.Read())
                InspectionResults.Add(new InspectionResult(dr));
            dr.Close();
            return InspectionResults.ToArray();
        }
        private async Task<InspectionResultSequence[]> ReadInspectionResultSequences()
        {
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM Sequences";
            var dr = sqlite_cmd.ExecuteReader();

            List<InspectionResultSequence> InspectionResultSequences = new List<InspectionResultSequence>();
            while (dr.Read())
                InspectionResultSequences.Add(new InspectionResultSequence(dr));
            dr.Close();
            return InspectionResultSequences.ToArray();
        }
        private async Task<InspectionResultSequenceProcedure[]> ReadInspectionResultSequenceProcedures()
        {
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM SqProcedures";
            var dr = sqlite_cmd.ExecuteReader();

            List<InspectionResultSequenceProcedure> InspectionResultSequenceProcedures = new List<InspectionResultSequenceProcedure>();
            while (dr.Read())
                InspectionResultSequenceProcedures.Add(new InspectionResultSequenceProcedure(dr));
            dr.Close();
            return InspectionResultSequenceProcedures.ToArray();
        }
        private async Task<InspectionResultSequenceProcedureValue[]> ReadInspectionResultSequenceProcedureValues()
        {
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM SqProcValues";
            var dr = sqlite_cmd.ExecuteReader();

            List<InspectionResultSequenceProcedureValue> InspectionResultSequenceProcedureValues = new List<InspectionResultSequenceProcedureValue>();
            while (dr.Read())
                InspectionResultSequenceProcedureValues.Add(new InspectionResultSequenceProcedureValue(dr));
            dr.Close();
            return InspectionResultSequenceProcedureValues.ToArray();
        }
        private async Task<VisualInspectionQuestion[]> ReadVisualInspectionQuestions()
        {
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM ViewQuestions";
            var dr = sqlite_cmd.ExecuteReader();

            List<VisualInspectionQuestion> visualInspectionQuestions = new List<VisualInspectionQuestion>();
            while (dr.Read())
                visualInspectionQuestions.Add(new VisualInspectionQuestion(dr));
            dr.Close();
            return visualInspectionQuestions.ToArray();
        }
        private async Task<VisualInspectionAnswer[]> ReadVisualInspectionAnswers()
        {
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM TestResult2Admin2Answers";
            var dr = sqlite_cmd.ExecuteReader();

            List<VisualInspectionAnswer> visualInspectionAnswers = new List<VisualInspectionAnswer>();
            while (dr.Read())
                visualInspectionAnswers.Add(new VisualInspectionAnswer(dr));
            dr.Close();
            sqlite_cmd = sqlite_conn.CreateCommand();

            sqlite_cmd.CommandText = "SELECT * FROM TestResult2Customer2Answers";
            dr = sqlite_cmd.ExecuteReader();

            while (dr.Read())
                visualInspectionAnswers.Add(new VisualInspectionAnswer(dr));
            dr.Close();
            return visualInspectionAnswers.ToArray();
        }
    }
}