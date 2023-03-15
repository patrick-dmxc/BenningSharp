namespace BenningSharp.Manager
{
    public class RunManager : AbstractManager
    {
        private static RunManager? instance;
        public static RunManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new RunManager();
                return instance;
            }
        }
        public override string Name => "Run Manager";

        public List<IManager> managers= new List<IManager> ();
        public IReadOnlyCollection<IManager> Managers { get { return managers.AsReadOnly(); } }

        protected RunManager() : base()
        {

        }

        protected override void Initialize()
        {
            foreach(var type in Tools.GetAssemblies(typeof(IManager)))
            {
                try
                {
                    IManager? manager = Activator.CreateInstance(type) as IManager;
                    if (manager != null)
                        this.managers.Add(manager);
                }
                catch
                {

                }
            }
        }

        protected override void OnDispose()
        {
            this.managers.ForEach(m => m.Dispose());
        }
    }
}