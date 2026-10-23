using Celeste.Input.Devices.Mouse;

namespace Celeste.Input.Runtime
{
    public interface ISourceMInputMouseConstruction
    {
        SourceMouseData CreateMouse(SourceFnaMouse physicalMouse, SourceMInputProcess process);
    }
}
