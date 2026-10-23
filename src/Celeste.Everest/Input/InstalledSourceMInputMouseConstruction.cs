using Celeste.Input.Runtime;
using Celeste.Input.Devices.Mouse;

namespace Celeste.Everest.Input
{
    public sealed class InstalledSourceMInputMouseConstruction : ISourceMInputMouseConstruction
    {
        public SourceMouseData CreateMouse(SourceFnaMouse physicalMouse, SourceMInputProcess process)
            => new SourceEverestMouseData(physicalMouse, process);
    }
}
