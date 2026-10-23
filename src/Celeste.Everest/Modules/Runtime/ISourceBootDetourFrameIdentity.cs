using System.Reflection;

namespace Celeste.Everest.Modules.Runtime
{
    // Qualified original source identity or actual external assembly identity for a real stack frame.
    // Missing source binding must throw; a newly split shared DLL is not by itself an original assembly.
    public interface ISourceBootDetourFrameIdentity
    {
        string RequireFrameAssemblyIdentity(MethodBase method, out bool stopAtHostBoundary);
    }
}
