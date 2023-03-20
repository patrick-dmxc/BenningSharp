using BenningSharp.Objects;
using static BenningSharp.Manager.DatabaseManager;

namespace BenningSharp.Manager
{
    public class DevicesManager : AbstractManager
    {
        private static DevicesManager? instance;
        public static DevicesManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new DevicesManager();
                return instance;
            }
        }
        public override string Name => "Devices Manager";

        private List<Device> devices = new List<Device>();
        public IReadOnlyCollection<Device> Devices { get { return devices.AsReadOnly(); } }

        public event EventHandler<DeviceEventArgs>? DeviceAdded;
        public event EventHandler<DeviceEventArgs>? DeviceRemoved;
        protected DevicesManager() : base()
        {

        }

        protected override void Initialize()
        {
            DatabaseManager.Instance.DatabaseAdded += Instance_DatabaseAdded;
            DatabaseManager.Instance.DatabaseRemoved += Instance_DatabaseRemoved;
        }

        private void Instance_DatabaseAdded(object? sender, DatabaseEventArgs e)
        {
            foreach (Device device in e.Database.Devices)
            {
                devices.Add(device);
                this.DeviceAdded?.Invoke(this, new DeviceEventArgs(device));
            }
        }
        private void Instance_DatabaseRemoved(object? sender, DatabaseEventArgs e)
        {
            foreach (Device device in e.Database.Devices)
            {
                devices.Remove(device);
                this.DeviceRemoved?.Invoke(this, new DeviceEventArgs(device));
            }
        }

        protected override void OnDispose()
        {
        }

        public class DeviceEventArgs : EventArgs
        {
            public readonly Device Device;
            public DeviceEventArgs(Device device)
            {
                Device = device;
            }
        }
    }
}