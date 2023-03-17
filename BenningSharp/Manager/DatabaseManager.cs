namespace BenningSharp.Manager
{
    public class DatabaseManager : AbstractManager
    {
        private static DatabaseManager? instance;
        public static DatabaseManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new DatabaseManager();
                return instance;
            }
        }
        public override string Name => "Database Manager";

        private List<Database> databases = new List<Database>();
        public IReadOnlyCollection<Database> Databases { get { return databases.AsReadOnly(); } }
        protected DatabaseManager() : base()
        {

        }

        protected override void Initialize()
        {
        }

        protected override void OnDispose()
        {
        }

        public Database OpenDatabase(string path)
        {
            if (this.databases.Any(d => string.Equals(d.Path, path)))
                throw new Exception($"There is already a Database with the path: {path}");

            var database = new Database(path);
            this.databases.Add(database);
            return database;
        }
    }
}