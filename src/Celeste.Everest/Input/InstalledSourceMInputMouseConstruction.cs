using Celeste.Input.Devices.Mouse;
using Celeste.Input.Runtime;

namespace Celeste.Everest.Input
{
    public sealed class InstalledSourceMInputMouseConstruction : ISourceMInputMouseConstruction
    {
        public SourceMouseData CreateMouse(SourceFnaMouse physicalMouse, SourceMInputProcess process)
        {
            return new SourceEverestMouseData(physicalMouse, process);
        }
    }
}
