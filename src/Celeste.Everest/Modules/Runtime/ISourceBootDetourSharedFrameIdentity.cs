using System;
using System.Reflection;

namespace Celeste.Everest.Modules.Runtime
{
    public interface ISourceBootDetourSharedFrameIdentity
    {
        IDisposable RegisterSharedHelperFrames(Type actualHelperType);
        bool TryValidateSharedHelperFrame(MethodBase method, out string actualAssemblyIdentity);
    }
}
