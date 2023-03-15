using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenningSharp.Manager
{
    public interface IManager : IDisposable
    {
        string Name { get; }

        bool IsInitializing { get; }
        bool IsInitialized { get; }
        bool IsDisposing { get; }
        bool IsDisposed { get; }
    }
}