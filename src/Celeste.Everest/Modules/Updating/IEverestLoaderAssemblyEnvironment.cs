using Celeste.Everest.Reflection;

namespace Celeste.Everest.Modules.Updating
{
    public interface IEverestLoaderAssemblyEnvironment
    {
        SourceReflectionTypeSafetyState TypeSafety { get; }
    }
}
