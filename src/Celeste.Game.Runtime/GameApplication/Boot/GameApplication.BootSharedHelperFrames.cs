using System;
using System.Reflection;
using Celeste.Everest.Modules.Runtime;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : ISourceBootDetourSharedFrameIdentity
    {
        private SourceSharedDetourFrameRegistry sharedDetourFrameRegistry;

        IDisposable ISourceBootDetourSharedFrameIdentity.RegisterSharedHelperFrames(Type actualHelperType)
        {
            sharedDetourFrameRegistry ??= new SourceSharedDetourFrameRegistry(
                typeof(GameApplication).Assembly, sourceRuntimeModuleMetadata);
            return sharedDetourFrameRegistry.Register(actualHelperType);
        }

        bool ISourceBootDetourSharedFrameIdentity.TryValidateSharedHelperFrame(
            MethodBase method, out string actualAssemblyIdentity)
        {
            actualAssemblyIdentity = null;
            return sharedDetourFrameRegistry != null &&
                   sharedDetourFrameRegistry.TryValidate(method, out actualAssemblyIdentity);
        }
    }
}
