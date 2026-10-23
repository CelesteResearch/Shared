using Celeste.Input.Devices.Keyboard;
using Celeste.Input.Runtime;

namespace Celeste.Everest.Input
{
    public sealed class InstalledSourceMInputKeyboardConstruction : ISourceMInputKeyboardConstruction
    {
        public SourceKeyboardData CreateKeyboard(SourceFnaKeyboardStateProcess physical,
            ISourceKeyboardDisabledEnvironment disabled)
        {
            return new SourceEverestKeyboardData(physical, disabled);
        }
    }
}
