using Celeste.Input.Runtime;
using Celeste.Input.Devices.Keyboard;

namespace Celeste.Everest.Input
{
    public sealed class InstalledSourceMInputKeyboardConstruction : ISourceMInputKeyboardConstruction
    {
        public SourceKeyboardData CreateKeyboard(SourceFnaKeyboardStateProcess physical,
            ISourceKeyboardDisabledEnvironment disabled)
            => new SourceEverestKeyboardData(physical, disabled);
    }
}
