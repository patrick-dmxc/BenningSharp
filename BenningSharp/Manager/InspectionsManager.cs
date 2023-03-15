using BenningSharp.Objects.Inspections;

namespace BenningSharp.Manager
{
    public class InspectionsManager : AbstractManager
    {
        private static InspectionsManager? instance;
        public static InspectionsManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new InspectionsManager();
                return instance;
            }
        }
        public override string Name => "Inspections Manager";

        private List<IInspection> inspections = new List<IInspection>();
        public IReadOnlyCollection<IInspection> Inspections { get { return inspections.AsReadOnly(); } }

        protected InspectionsManager() : base()
        {

        }

        protected override void Initialize()
        {
            foreach (var type in Tools.GetAssemblies(typeof(IInspection)))
            {
                try
                {
                    IInspection? inspection = Activator.CreateInstance(type) as IInspection;
                    if (inspection != null)
                        this.inspections.Add(inspection);
                }
                catch
                {

                }
            }
        }

        protected override void OnDispose()
        {
        }
    }
}