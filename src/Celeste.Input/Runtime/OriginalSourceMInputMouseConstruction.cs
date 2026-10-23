using Celeste.Input.Devices.Mouse;

namespace Celeste.Input.Runtime
{
    public sealed class OriginalSourceMInputMouseConstruction : ISourceMInputMouseConstruction
    {
        public SourceMouseData CreateMouse(SourceFnaMouse physicalMouse, SourceMInputProcess process)
            => new SourceMouseData(physicalMouse, process);
    }
}
