using BenningSharp.Objects.Inspections.Reading;

namespace BenningSharp.Objects.Inspections
{
    public abstract class AbstractInspections : IInspection
    {
        public InspectionResult? InspectionResult { get; }
        public abstract string Name { get; }
        public abstract EInspectionMajor Type { get; }
        public bool IsTemplate { get; }
        public virtual bool Passed
        {
            get
            {
                if (readings.Count == 0)
                    return false;

                return this.readings.All(r => r.Passed);
            }
        }

        private Collection<IReading> readings = new Collection<IReading>();
        public AbstractInspections(): this(true)
        {

        }
        protected AbstractInspections(bool isTemplate)
        {
            this.IsTemplate = isTemplate;
        }
        protected AbstractInspections(InspectionResult inspectionResult): this(false)
        {
            this.InspectionResult = inspectionResult;
            this.initialize(inspectionResult.Data);
        }
        protected abstract void initialize(IReadOnlyDictionary<string, Entity.KeyValueData> data);

        public IReadOnlyCollection<IReading> Readings
        {
            get { return readings; }
        }

        protected void AddReading(IReading reading)
        {
            if (readings.Any(r=>r.Name.Equals(reading.Name)))
                return;

            this.readings.Add(reading);
        }
    }
}