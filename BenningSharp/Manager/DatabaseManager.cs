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

        protected DatabaseManager() : base()
        {

        }

        protected override void Initialize()
        {
        }

        protected override void OnDispose()
        {
        }
    }
}