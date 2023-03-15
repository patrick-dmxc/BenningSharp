namespace BenningSharp.Manager
{
    public abstract class AbstractManager : IManager
    {
        public abstract string Name { get; }
        public bool IsInitializing { get; private set; }
        public bool IsInitialized { get; private set; }
        public bool IsDisposing { get; private set; }
        public bool IsDisposed { get; private set; }

        protected AbstractManager()
        {
            this.initialize();
        }
        private void initialize()
        {
            try
            {
                this.IsInitializing = true;
                this.Initialize();
                this.IsInitialized = true;
            }
            catch
            {

            }
            finally
            {
                this.IsInitialized = false;
            }
        }
        protected abstract void Initialize();

        protected abstract void OnDispose();
        public void Dispose()
        {
            try
            {
                this.IsDisposing = true;
                this.OnDispose();
            }
            catch
            {

            }
            finally
            {
                this.IsDisposed = true;
                this.IsDisposing = false;
            }
        }
    }
}