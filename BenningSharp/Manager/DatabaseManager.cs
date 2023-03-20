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

        public event EventHandler<DatabaseEventArgs>? DatabaseAdded;
        public event EventHandler<DatabaseEventArgs>? DatabaseRemoved;
        protected DatabaseManager() : base()
        {

        }

        protected override void Initialize()
        {
        }

        protected override void OnDispose()
        {
        }

        public Database OpenOrGetDatabase(string path)
        {
            Database? database = this.databases.FirstOrDefault(d => string.Equals(d.Path, path));
            if (database != null)
                return database;

            database = new Database(path);
            this.databases.Add(database);
            this.DatabaseAdded?.Invoke(this, new DatabaseEventArgs(database));
            return database;
        }
        public bool RemoveDatabase(Database database)
        {
            if (!this.databases.Contains(database))
                return false;

            this.databases.Remove(database);
            this.DatabaseRemoved?.Invoke(this, new DatabaseEventArgs(database));
            return true;
        }

        public class DatabaseEventArgs: EventArgs
        {
            public readonly Database Database;
            public DatabaseEventArgs(Database database)
            {
                Database = database;
            }
        }
    }
}